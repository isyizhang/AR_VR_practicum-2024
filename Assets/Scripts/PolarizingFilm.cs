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

    private int _value; // value for level of taste

    public Transform typeOfTaste;

    public Transform text;

    public GameObject slider;

    public Slider sliderInteractable;

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        // slider = GameObject.Find("Slider2D");
        SetValue(_value);
        button.AddListener(() =>
        {
            DestroySlider();
            AddSlider();
            sliderInteractable.onValueChanged.AddListener(delegate
            {
                _value = (int)sliderInteractable.value;
                SetValue(_value);
            });
        });
    }

    // Update is called once per frame
    void Update()
    {

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
