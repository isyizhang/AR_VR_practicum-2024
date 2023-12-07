using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private float Value;
    public GameObject Text1; // assign any text with the script I've made before attached
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Table1;
    void Start()
    {
        Value = 0f;
    }

    public void AddNumber()
    {
        Value += 1f; // Add 1 to the value
        TextGuidance Script1 = Text1.GetComponent<TextGuidance>(); // Get the script of the text
        Script1.TextSetActive(Value); // Use the public method made in the last Script
        TextGuidance Script2 = Text2.GetComponent<TextGuidance>(); // Get the script of the text
        Script2.TextSetActive(Value); // Use the public method made in the last Script
        TextGuidance Script3 = Text3.GetComponent<TextGuidance>(); // Get the script of the text
        Script3.TextSetActive(Value); // Use the public method made in the last Script
        TextGuidance Script3_1 = Table1.GetComponent<TextGuidance>(); // Get the script of the text
        Script3_1.TextSetActive(Value); // Use the public method made in the last Script
    }

}
