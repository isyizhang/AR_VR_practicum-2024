using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using TMPro;


public class ButtonAddDelete : MonoBehaviour, Interactable
{
    public UnityEvent onPointerDownUpEvent;

    public Transform text;
    public bool isAdd;

    private bool isPressed = false;
    public bool isInteractable = true;

    public GameObject largeLens;
    public GameObject lightPath1; //left 1

    public GameObject lightPath2;  //right 1

    public GameObject lightPath3; //left 2
    public GameObject lightPath4; //right 2

    public GameObject userFigure;
    public void OnPointerDown()
    {
        if (!isInteractable) return;
        if (!isPressed)
        {
            transform.position += new Vector3(0, -0.005f, 0.009f);
            isPressed = true;

            if (isAdd)
            {
                if (!lightPath1.activeSelf)
                {
                    lightPath1.SetActive(true);
                }
                else if (!lightPath2.activeSelf)
                {
                    lightPath2.SetActive(true);
                }
                else if (!lightPath3.activeSelf)
                {
                    lightPath3.SetActive(true);
                }
                else if (!lightPath4.activeSelf)
                {
                    lightPath4.SetActive(true);
                }
            }
            else
            {
                if (lightPath4.activeSelf)
                {
                    lightPath4.SetActive(false);
                }
                else if (lightPath3.activeSelf)
                {
                    lightPath3.SetActive(false);
                }
                else if (lightPath2.activeSelf)
                {
                    lightPath2.SetActive(false);
                }
                else if (lightPath1.activeSelf)
                {
                    lightPath1.SetActive(false);
                }
            }

        }
    }
    public void OnPointerUp(bool isInside)
    {
        if (!isInteractable) return;
        if (isPressed)
        {
            transform.position -= new Vector3(0, -0.005f, 0.009f);
            isPressed = false;
            if (isInside)
            {
                onPointerDownUpEvent.Invoke();
            }
        }


        if (!lightPath1.activeSelf && !lightPath2.activeSelf)
        {
            largeLens.transform.localScale = new Vector3(0.2f, 0.02f, 0.2f);
            userFigure.transform.localPosition = new Vector3(10.0f, 5.0f, -1.0f);
        }
        else if (!lightPath3.activeSelf && !lightPath4.activeSelf)
        {
            largeLens.transform.localScale = new Vector3(0.4f, 0.02f, 0.4f);
            userFigure.transform.localPosition = new Vector3(-150.0f, 5.0f, -1.0f);
        }
        else
        {
            largeLens.transform.localScale = new Vector3(0.6f, 0.02f, 0.6f);
            userFigure.transform.localPosition = new Vector3(-300.0f, 5.0f, -1.0f);
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

    public void AddListener(UnityAction call)
    {
        if (!isInteractable) return;
        //when onPointerDownUpEvent is invoked, all added listeners (call methods) will be executed.
        this.onPointerDownUpEvent.AddListener(call);
    }
}

