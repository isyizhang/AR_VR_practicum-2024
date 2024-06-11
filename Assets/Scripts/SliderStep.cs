using UnityEngine;
using UnityEngine.UI;

public class SliderStep : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChanged(); });
    }

    void ValueChanged()
    {
        // Round the slider value to the nearest step (0.1 in this case)
        float step = 0.1f;
        slider.value = Mathf.Round(slider.value / step) * step;
    }
}
