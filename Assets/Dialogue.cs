using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private GameObject ArrowGameObject;
    public GameObject ModelTarget;
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

        if (Value == 2)
        {
            ShowArrowAt(-0.1f, 0.075f, 0.05f);
        }
        else if (Value == 3)
        {
            ShowArrowAt(-0.1f, 0.075f, 0.2f);
        }
    }

    private void ShowArrowAt(float x, float y, float z)
    {
        var preArrow = GameObject.Find("Arrow(Clone)");
        if (preArrow != null)
        {
            GameObject.Destroy(preArrow);
        }
        var arrow = Resources.Load<GameObject>("Arrow");
        ArrowGameObject = Instantiate(arrow, new Vector3(x, y, z), Quaternion.Euler(0, -90, 0));
        ArrowGameObject.transform.SetParent(ModelTarget.transform);
    }

}
