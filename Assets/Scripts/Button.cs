using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using TMPro;


public class Button : MonoBehaviour, Interactable
{
    public UnityEvent onPointerDownUpEvent;

    public Transform text;

    public GameObject lightBeam;
    private bool isPressed = false;

    public void OnPointerDown()
    {
        if (!isPressed)
        {
            transform.position += new Vector3(0, -0.005f, 0.009f);
            isPressed = true;

            if (!lightBeam.activeSelf)
            {
                lightBeam.SetActive(true);
                Debug.Log("active");
            }
            else
            {
                lightBeam.SetActive(false);
                Debug.Log("Inactive");
            }
        }
    }
    public void OnPointerUp(bool isInside)
    {
        if (isPressed)
        {
            transform.position -= new Vector3(0, -0.005f, 0.009f);
            isPressed = false;
            if (isInside)
            {
                onPointerDownUpEvent.Invoke();
            }
        }
    }
    public void OnPointerDragged(Vector2 oldPointerPosition, Vector2 newPointerPosition) { }

    private void SetText(string text)
    {
        this.text.GetComponent<TextMeshPro>().text = text;
    }

    public string GetText()
    {
        return text.GetComponent<TextMeshPro>().text;
    }
}
