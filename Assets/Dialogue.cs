using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //private GameObject ArrowGameObject;
    public GameObject ModelTarget;
    private float Value;
    public GameObject Text1; // assign any text with the script I've made before attached
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;

    void Start()
    {
        Value = 1f;
        TextGuidance Script1 = Text1.GetComponent<TextGuidance>(); // Get the script of the text
        Script1.TextSetActive(Value);
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
        TextGuidance Script4 = Text4.GetComponent<TextGuidance>(); // Get the script of the text
        Script4.TextSetActive(Value); // Use the public method made in the last Script
        TextGuidance Script5 = Text5.GetComponent<TextGuidance>(); // Get the script of the text
        Script5.TextSetActive(Value); // Use the public method made in the last Script
        TextGuidance Script6 = Text6.GetComponent<TextGuidance>(); // Get the script of the text
        Script6.TextSetActive(Value); // Use the public method made in the last Script
        TextGuidance Script7 = Text7.GetComponent<TextGuidance>(); // Get the script of the text
        Script7.TextSetActive(Value); // Use the public method made in the last Scri

        // if (Value == 1)
        // {
        //     DestroyArrow();
        //     ChangeButtonText("Continue");
        // }
        // else if (Value == 2 || Value == 5)
        // {
        //     ShowArrowAt(-0.1f, -0.05f, 0.075f);
        // }
        // else if (Value == 4)
        // {
        //     ShowArrowAt(-0.1f, -0.3f, 0.075f);
        // }
        // else if (Value == 3 || Value == 6)
        // {
        //     ShowArrowAt(-0.1f, -0.2f, 0.075f);
        // }
        // else if (Value == 7)
        // {
        //     DestroyArrow();
        //     ChangeButtonText("End Tutorial");
        //     Value = -1f;
        // }else if (Value == 0){
        //     ChangeButtonText("Start Tutorial");
        // }

        if(Value == 0){
            ChangeButtonText("Start Tutorial");
        }
        else if(Value == 1){
            ChangeButtonText("Continue");
        }
        else if (Value == 7)
        {
            ChangeButtonText("End Tutorial");
            Value = -1f;
        }
    }

    // private void ShowArrowAt(float x, float y, float z)
    // {
    //     DestroyArrow();
    //     var arrow = Resources.Load<GameObject>("Arrow");
    //     ArrowGameObject = Instantiate(arrow) as GameObject;
    //     ArrowGameObject.transform.SetParent(ModelTarget.transform);
    //     ArrowGameObject.transform.localPosition = new Vector3(x, y, z);
    //     ArrowGameObject.transform.localRotation = Quaternion.Euler(0, -90, -90);
    // }

    // private void DestroyArrow()
    // {
    //     var preArrow = GameObject.Find("Arrow(Clone)");
    //     if (preArrow != null)
    //     {
    //         GameObject.Destroy(preArrow);
    //     }
    // }

    private void ChangeButtonText(string txt)
    {
        GameObject buttonContinue = GameObject.Find("ButtonContinue");
        GameObject buttonText = buttonContinue.transform.Find("Text").gameObject;
        buttonText.GetComponent<TextMeshProUGUI>().SetText(txt);
    }
}
