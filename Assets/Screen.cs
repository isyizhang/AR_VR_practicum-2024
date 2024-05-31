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

    public int a1;
    public int a2;
    public int a3;
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

    public GameObject greenLightBeam; //Drag the game object named "LightBeamGreen" to the greenLightBeam field in the Unity Editor Inspector.
    GameObject greenLightBeamPart1_1;
    GameObject greenLightBeamPart1_2;
    private Color originalGreenLightBeamColor;


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

        greenLightBeamPart1_1 = greenLightBeam.transform.Find("LightBeam_Part1-1").gameObject;
        originalGreenLightBeamColor = greenLightBeamPart1_1.GetComponent<Renderer>().material.color;
        greenLightBeamPart1_2 = greenLightBeam.transform.Find("LightBeam_Part1-2").gameObject;

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

        Color newGreenLightBeamPart1_2_Color = ChangeColor(originalGreenLightBeamColor, a1/10f);
        greenLightBeamPart1_2.GetComponent<Renderer>().material.color = newGreenLightBeamPart1_2_Color;

    }

    private int DotProduct(int a1, int a2, int a3, int b1, int b2, int b3)
    {
        return a1 * b1 + a2 * b2 + a3 * b3;
    }

     private Color ChangeColor(Color oldColor, float percentage)
    {
    // Clamp the percentage value to the valid range [0, 1]
        percentage = Mathf.Clamp01(percentage);

        // Adjust the alpha (transparency) using the provided percentage
        Color newColor = oldColor;
        newColor.a *= percentage;

        return newColor;
    }

}
