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
    //public bool isChallenge1 = false;

    private float pressDuration = 0f;
    private float longPressThreshold = 1f;
    private Coroutine longPressCoroutine;

    public AudioSource audioSource;
    public AudioClip turnOnLightClip;
    public AudioClip turnOffLightClip;
    public AudioClip buttonClickClip;
    public AudioClip longPressClip;

    public void OnPointerDown()
    {
        if (!isInteractable) return;
        if (!isPressed)
        {
            //Debug.Log("Button pressed down.");
            transform.position += new Vector3(0, -0.005f, 0.009f);
            isPressed = true;

            if (lightBeam && isLightButton)
            {
                bool isLightActive = lightBeam.activeSelf;
                lightBeam.SetActive(!isLightActive);
                if (audioSource != null)
                {
                    if (!isLightActive && turnOnLightClip != null)
                    {
                        audioSource.PlayOneShot(turnOnLightClip);
                    }
                    else if (isLightActive && turnOffLightClip != null)
                    {
                        audioSource.PlayOneShot(turnOffLightClip);
                    }
                }
            }
            if(!isLightButton){
                 if (audioSource != null && buttonClickClip != null)
                {
                    audioSource.PlayOneShot(buttonClickClip);
                }
            }

            pressDuration = 0f;
            longPressCoroutine = StartCoroutine(LongPressDetector());
        }
    }

    public void OnPointerUp(bool isInside)
    {
        if (!isInteractable) return;
        if (isPressed)
        {
            //Debug.Log("Button released.");
            transform.position -= new Vector3(0, -0.005f, 0.009f);
            isPressed = false;

            if (longPressCoroutine != null)
            {
                StopCoroutine(longPressCoroutine);
                longPressCoroutine = null;
            }

            if (pressDuration < longPressThreshold)
            {
                if (isInside)
                {
                    Debug.Log("Short press detected.");
                    onPointerDownUpEvent.Invoke();
                }
            }

            pressDuration = 0f;
        }
    }

    private IEnumerator LongPressDetector()
    {
        Debug.Log("LongPressDetector started.");
        while (true)
        {
            pressDuration += Time.deltaTime;
            //Debug.Log("Press Duration: " + pressDuration + " / Threshold: " + longPressThreshold);

            if (pressDuration >= longPressThreshold)
            {
                Debug.Log("Long press detected.");
                if (audioSource != null && longPressClip != null && IsChallengeManager.isChallenge1)
                {
                    audioSource.PlayOneShot(longPressClip);
                }
                onLongPressEvent.Invoke();
                yield break; // Exit the coroutine after detecting a long press
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
        this.onPointerDownUpEvent.AddListener(call);
    }

    public void AddPointerDownUpListener(UnityAction call)
    {
        if (!isInteractable) return;
        this.onPointerDownUpEvent.AddListener(call);
    }

    public void AddLongPressListener(UnityAction call)
    {
        if (!isInteractable) return;
        if(!IsChallengeManager.isChallenge1) return;
        this.onLongPressEvent.AddListener(call);
    }
}
