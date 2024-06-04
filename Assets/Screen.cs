using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    public Transform text;
    public int value;

    public int a1; // green
    public int a2; // blue
    public int a3; // red
    public int b1;
    public int b2;
    public int b3;

    private PolarizingFilm film11;
    private PolarizingFilm film12;
    private PolarizingFilm film13;
    private PolarizingFilm film21;
    private PolarizingFilm film22;
    private PolarizingFilm film23;

    private Button buttonSweetness;
    private Button buttonSalinity;
    private Button buttonGreasiness;

    //the following is controlling light color
    public GameObject greenLightBeam;
    private Color originalGreenLightBeamColor;
    private GameObject greenLightBeamPart1_1;
    private GameObject greenLightBeamPart1_2;
    private GameObject greenLightBeamPart1_3;
    private GameObject greenLightBeamPart2;
   

    public GameObject blueLightBeam; 
    private Color originalBlueLightBeamColor;
    private GameObject blueLightBeamPart1_1;
    private GameObject blueLightBeamPart1_2;
    private GameObject blueLightBeamPart1_3;
    private GameObject blueLightBeamPart2;


    public GameObject redLightBeam;
    private Color originalRedLightBeamColor;
    private GameObject redLightBeamPart1_1;
    private GameObject redLightBeamPart1_2;
    private GameObject redLightBeamPart1_3;
    private GameObject redLightBeamPart2;


    // Start is called before the first frame update
    void Start()
    {
        GameObject filmGameObject11 = GameObject.Find("PolarizingFilm_1_1");
        film11 = filmGameObject11.GetComponent<PolarizingFilm>();
        GameObject button11 = filmGameObject11.transform.Find("ButtonSweetness").gameObject;
        buttonSweetness = button11.GetComponent<Button>();

        GameObject filmGameObject12 = GameObject.Find("PolarizingFilm_1_2");
        film12 = filmGameObject12.GetComponent<PolarizingFilm>();
        GameObject button12 = filmGameObject12.transform.Find("ButtonSalinity").gameObject;
        buttonSalinity = button12.GetComponent<Button>();

        GameObject filmGameObject13 = GameObject.Find("PolarizingFilm_1_3");
        film13 = filmGameObject13.GetComponent<PolarizingFilm>();
        GameObject button13 = filmGameObject13.transform.Find("ButtonGreasiness").gameObject;
        buttonGreasiness = button13.GetComponent<Button>();

        GameObject filmGameObject21 = GameObject.Find("PolarizingFilm_2_1");
        film21 = filmGameObject21.GetComponent<PolarizingFilm>();

        GameObject filmGameObject22 = GameObject.Find("PolarizingFilm_2_2");
        film22 = filmGameObject22.GetComponent<PolarizingFilm>();

        GameObject filmGameObject23 = GameObject.Find("PolarizingFilm_2_3");
        film23 = filmGameObject23.GetComponent<PolarizingFilm>();

        //the following is controlling light color change
        greenLightBeamPart1_1 = greenLightBeam.transform.Find("LightBeam_Part1-1").gameObject;
        greenLightBeamPart1_2 = greenLightBeam.transform.Find("LightBeam_Part1-2").gameObject;
        greenLightBeamPart1_3 = greenLightBeam.transform.Find("LightBeam_Part1-3").gameObject;
        greenLightBeamPart2 = greenLightBeam.transform.Find("LightBeam_Part2").gameObject;
        originalGreenLightBeamColor = greenLightBeamPart1_1.GetComponent<Renderer>().material.color;
        
        blueLightBeamPart1_1 = blueLightBeam.transform.Find("LightBeam_Part1-1").gameObject;
        blueLightBeamPart1_2 = blueLightBeam.transform.Find("LightBeam_Part1-2").gameObject;
        blueLightBeamPart1_3 = blueLightBeam.transform.Find("LightBeam_Part1-3").gameObject;
        blueLightBeamPart2 = blueLightBeam.transform.Find("LightBeam_Part2").gameObject;
        originalBlueLightBeamColor = blueLightBeamPart1_1.GetComponent<Renderer>().material.color;

        redLightBeamPart1_1 = redLightBeam.transform.Find("LightBeam_Part1-1").gameObject;
        redLightBeamPart1_2 = redLightBeam.transform.Find("LightBeam_Part1-2").gameObject;
        redLightBeamPart1_3 = redLightBeam.transform.Find("LightBeam_Part1-3").gameObject;
        redLightBeamPart2 = redLightBeam.transform.Find("LightBeam_Part2").gameObject;
        originalRedLightBeamColor = redLightBeamPart1_1.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonSweetness.lightBeam.activeSelf)
        {
            a1 = film11.Value;
        }
        else { a1 = 0; }
        if (buttonSalinity.lightBeam.activeSelf)
        {
            a2 = film12.Value;
        }
        else { a2 = 0; }
        if (buttonGreasiness.lightBeam.activeSelf)
        {
            a3 = film13.Value;
        }
        else { a3 = 0; }
        b1 = film21.Value;
        b2 = film22.Value;
        b3 = film23.Value;
        value = DotProduct(a1, a2, a3, b1, b2, b3);
        text.GetComponent<TextMeshPro>().text = value.ToString();
        int alpha = value * 255 / 300;
        text.GetComponent<TextMeshPro>().faceColor = new Color32(225, 135, 0, Convert.ToByte(alpha));
    
        // Change color of individual LightBeam_Part1-2 based on values
        ChangeLightBeamColor(greenLightBeamPart1_2, originalGreenLightBeamColor, a1 / 10f);
        ChangeLightBeamColor(blueLightBeamPart1_2, originalBlueLightBeamColor, a2 / 10f);
        ChangeLightBeamColor(redLightBeamPart1_2, originalRedLightBeamColor, a3 / 10f);

        //Change color of LightBeam_Part1-3 and LightBeam_Part2 based on the product of values
        ChangeLightBeamColor(greenLightBeamPart1_3, originalGreenLightBeamColor, (a1 / 10f) * (b1 / 10f));
        ChangeLightBeamColor(blueLightBeamPart1_3, originalBlueLightBeamColor, (a2 / 10f) * (b2 / 10f));
        ChangeLightBeamColor(redLightBeamPart1_3, originalRedLightBeamColor, (a3 / 10f) * (b3 / 10f));
        ChangeLightBeamColor(greenLightBeamPart2, originalGreenLightBeamColor, (a1 / 10f) * (b1 / 10f));
        ChangeLightBeamColor(blueLightBeamPart2, originalBlueLightBeamColor, (a2 / 10f) * (b2 / 10f));
        ChangeLightBeamColor(redLightBeamPart2, originalRedLightBeamColor, (a3 / 10f) * (b3 / 10f));
    }

    private int DotProduct(int a1, int a2, int a3, int b1, int b2, int b3)
    {
        return a1 * b1 + a2 * b2 + a3 * b3;
    }

     private void ChangeLightBeamColor(GameObject lightBeamPart, Color originalColor, float percentage)
    {
        percentage = Mathf.Clamp01(percentage);
        Color newColor = originalColor;
        newColor.a *= percentage;
        lightBeamPart.GetComponent<Renderer>().material.color = newColor;
    }

}
