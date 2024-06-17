using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using TMPro;

public class PolarizingFilm : MonoBehaviour
{
    public GameObject canvasObject;
    public Button button;

    private float _value; // value for level of taste

    public Transform typeOfTaste;

    public Transform text;

    public GameObject slider;

    public Slider sliderInteractable;

    public float Value //the number
    {
        get { return _value; }
        set { _value = value; }
    }

    private Coroutine sliderDisappearCoroutine;
    public float sliderDisappearDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // slider = GameObject.Find("Slider2D");
        SetValue(_value);
        button.AddListener(() =>
        {
            ResetSliderTimer(); // Reset timer when button is clicked
            //the fllowing will be excuted when button onPointerDownUpEvent is invoked
            DestroySlider();
            AddSlider();
            sliderInteractable.onValueChanged.AddListener(delegate
            {
                _value = sliderInteractable.value; 
                SetValue(_value);
                ResetSliderTimer();// Reset timer when button is clicked
            });
        });

        // Start coroutine to hide slider after delay
        StartSliderDisappearTimer();
        
    }

     void Update()
    {
        // Example: Check for user interaction to reset timer
        if (Input.GetMouseButtonDown(0) && slider != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
            
            // Check if user interacts with slider or its UI components
            if (hit.collider != null && hit.collider.gameObject == slider)
            {
                ResetSliderTimer(); // Reset timer when user interacts with slider
            }
        }
    }

    private void StartSliderDisappearTimer()
    {
        // Start coroutine to hide slider after delay
        sliderDisappearCoroutine = StartCoroutine(SliderDisappearCoroutine());
    }

    private void ResetSliderTimer()
    {
        // Reset or restart coroutine if slider exists
        if (sliderDisappearCoroutine != null)
        {
            StopCoroutine(sliderDisappearCoroutine);
        }
        sliderDisappearCoroutine = StartCoroutine(SliderDisappearCoroutine());
    }

    private IEnumerator SliderDisappearCoroutine()
    {
        yield return new WaitForSeconds(sliderDisappearDelay);

        // Destroy slider if it exists after delay
        if (slider != null)
        {
            DestroySlider();
        }
    }

    private void AddSlider()
    {
        var slider2D = Resources.Load<GameObject>("Slider2D");
        slider = Instantiate(slider2D, new Vector3(-600f, -175f, 0.0f), Quaternion.identity);
        slider.transform.SetParent(canvasObject.transform, false);
        sliderInteractable = slider.GetComponent<Slider>();
        sliderInteractable.value = _value;
        GameObject sliderText = slider.transform.Find("Text").gameObject;
        sliderText.GetComponent<TextMeshProUGUI>().SetText(typeOfTaste.GetComponent<TextMeshPro>().text);
    }

    private void DestroySlider()
    {
        slider = GameObject.Find("Slider2D(Clone)");
        if (slider != null)
        {
            GameObject.Destroy(slider);
        }
    }

    public void ValueChangeCheck()
    {
        Debug.Log(sliderInteractable.value);
    }

    public void SetValue(float value)
    {
        text.GetComponent<TextMeshPro>().text = value.ToString();
    }
}
