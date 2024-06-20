using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Button : MonoBehaviour, Interactable
{
    public UnityEvent onPointerDownUpEvent;
    public UnityEvent onLongPressEvent;

    public Transform text;

    public GameObject lightBeam;

    public bool isLightButton;
    private bool isPressed = false;
    public bool isInteractable = true;

    private float pressDuration = 0f;
    public float longPressThreshold = 3f;
    private Coroutine longPressCoroutine;

    public void OnPointerDown()
    {
        if (!isInteractable) return;
        if (!isPressed)
        {
            transform.position += new Vector3(0, -0.005f, 0.009f);
            isPressed = true;

            if (lightBeam && isLightButton)
            {
                if (!lightBeam.activeSelf)
                {
                    lightBeam.SetActive(true);
                }
                else
                {
                    lightBeam.SetActive(false);
                }
            }

            longPressCoroutine = StartCoroutine(LongPressDetector());
        }
    }

    public void OnPointerUp(bool isInside)
    {
        if (!isInteractable) return;
        if (isPressed)
        {
            transform.position -= new Vector3(0, -0.005f, 0.009f);
            isPressed = false;

            if (longPressCoroutine != null)
            {
                StopCoroutine(longPressCoroutine);
            }

            if (pressDuration < longPressThreshold)
            {
                // Short press
                if (isInside)
                {
                    onPointerDownUpEvent.Invoke();
                }
            }
            else
            {
                // Long press
                if (isInside)
                {
                    onLongPressEvent.Invoke();
                }
            }

            pressDuration = 0f;
        }
    }

    private IEnumerator LongPressDetector()
    {
        while (true)
        {
            pressDuration += Time.deltaTime;
            if (pressDuration >= longPressThreshold)
            {
                // Invoke long press event and break the loop
                onLongPressEvent.Invoke();
                break;
            }
            yield return null;
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

     public void AddPointerDownUpListener(UnityAction call)
    {
        if (!isInteractable) return;
        //when onPointerDownUpEvent is invoked, all added listeners (call methods) will be executed.
        this.onPointerDownUpEvent.AddListener(call);
    }

    public void AddLongPressListener(UnityAction call)
    {
        if (!isInteractable) return;
        //when onLongPressEvent is invoked, all added listeners (call methods) will be executed.
        this.onLongPressEvent.AddListener(call);
    }
}

