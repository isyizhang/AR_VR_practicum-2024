using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    public Transform text;
    public float value;

    public float a1; // green
    public float a2; // blue
    public float a3; // red
    public float b1;
    public float b2;
    public float b3;

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

    public Image lightDot;
    public Image itemImage;

    // Store the original scales
    private Vector3 originalScalePart1_2;
    private Vector3 originalScalePart1_3;
    private Vector3 originalScalePart2;

    public float A1
    {
        get { return a1; }
    }

    public float A2
    {
        get { return a2; }
    }

    public float A3
    {
        get { return a3; }
    }



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

        //the following is controlling the scale
        // Cache the original scales of the parts
        originalScalePart1_2 = greenLightBeamPart1_2.transform.localScale; 
        originalScalePart1_3 = greenLightBeamPart1_3.transform.localScale;
        originalScalePart2 = greenLightBeamPart2.transform.localScale;
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
        float alpha = value * 255 / 300;
        text.GetComponent<TextMeshPro>().faceColor = new Color32(225, 135, 0, Convert.ToByte(alpha));
    
        // Change color of individual LightBeam_Part1-2 based on values
        ChangeLightBeamColor(greenLightBeamPart1_2, originalGreenLightBeamColor, a1 );
        ChangeLightBeamColor(blueLightBeamPart1_2, originalBlueLightBeamColor, a2 );
        ChangeLightBeamColor(redLightBeamPart1_2, originalRedLightBeamColor, a3 );

        //Change color of LightBeam_Part1-3 and LightBeam_Part2 based on the product of values
        ChangeLightBeamColor(greenLightBeamPart1_3, originalGreenLightBeamColor, (a1 ) * (b1 ));
        ChangeLightBeamColor(blueLightBeamPart1_3, originalBlueLightBeamColor, (a2 ) * (b2 ));
        ChangeLightBeamColor(redLightBeamPart1_3, originalRedLightBeamColor, (a3 ) * (b3 ));
        ChangeLightBeamColor(greenLightBeamPart2, originalGreenLightBeamColor, (a1 ) * (b1 ));
        ChangeLightBeamColor(blueLightBeamPart2, originalBlueLightBeamColor, (a2 ) * (b2 ));
        ChangeLightBeamColor(redLightBeamPart2, originalRedLightBeamColor, (a3 ) * (b3 ));

        //the following is controlling the scale
        // Calculate new diameters based on a1, a2, a3 values for Part1_2
        float newDiameterGreenPart1_2 = CalculateNewDiameter(a1 , originalScalePart1_2.x);
        float newDiameterBluePart1_2 = CalculateNewDiameter(a2 , originalScalePart1_2.x);
        float newDiameterRedPart1_2 = CalculateNewDiameter(a3 , originalScalePart1_2.x);

        // Calculate new diameters based on a1, a2, a3 * b1, b2, b3 values for Part1_3 and Part2
        float newDiameterGreenPart1_3 = CalculateNewDiameter((a1 ) * (b1 ), originalScalePart1_3.x);
        float newDiameterBluePart1_3 = CalculateNewDiameter((a2 ) * (b2 ), originalScalePart1_3.x);
        float newDiameterRedPart1_3 = CalculateNewDiameter((a3 ) * (b3 ), originalScalePart1_3.x);
        
        float newDiameterGreenPart2 = newDiameterGreenPart1_3; // Using the same new diameter as Part1_3
        float newDiameterBluePart2 = newDiameterBluePart1_3; // Using the same new diameter as Part1_3
        float newDiameterRedPart2 = newDiameterRedPart1_3; 

        // Apply the new diameters to the respective cylinders
        UpdateCylinderDiameter(greenLightBeamPart1_2, newDiameterGreenPart1_2);
        UpdateCylinderDiameter(blueLightBeamPart1_2, newDiameterBluePart1_2);
        UpdateCylinderDiameter(redLightBeamPart1_2, newDiameterRedPart1_2);

        UpdateCylinderDiameter(greenLightBeamPart1_3, newDiameterGreenPart1_3);
        UpdateCylinderDiameter(blueLightBeamPart1_3, newDiameterBluePart1_3);
        UpdateCylinderDiameter(redLightBeamPart1_3, newDiameterRedPart1_3);

        UpdateConeBaseDiameter(greenLightBeamPart2, newDiameterGreenPart2);
        UpdateConeBaseDiameter(blueLightBeamPart2, newDiameterBluePart2);
        UpdateConeBaseDiameter(redLightBeamPart2, newDiameterRedPart2);

        // Get the colors of the three LightBeamPart2
        Color greenColorPart2 = greenLightBeamPart2.GetComponent<Renderer>().material.color;
        Color blueColorPart2 = blueLightBeamPart2.GetComponent<Renderer>().material.color;
        Color redColorPart2 = redLightBeamPart2.GetComponent<Renderer>().material.color;
        Color lightdotColor = lightDot.color;
        //change the color of lightdot - may need a more complex function
        lightdotColor.a = Mathf.Min(1, Mathf.Max(0, greenColorPart2.a + blueColorPart2.a + redColorPart2.a - 0.3f));
        lightDot.color = lightdotColor;
        Color itemImageColor = itemImage.color;
        itemImageColor.a = Mathf.Min(1, Mathf.Max(0, greenColorPart2.a + blueColorPart2.a + redColorPart2.a - 0.3f));
        itemImage.color = itemImageColor;

        // // Debug logs to verify color values
        // // Debug logs to verify individual color values
        // Debug.Log($"Green Color Part2 - R: {greenColorPart2.r}, G: {greenColorPart2.g}, B: {greenColorPart2.b}");
        // Debug.Log($"Blue Color Part2 - R: {blueColorPart2.r}, G: {blueColorPart2.g}, B: {blueColorPart2.b}");
        // Debug.Log($"Red Color Part2 - R: {redColorPart2.r}, G: {redColorPart2.g}, B: {redColorPart2.b}");

        // // Blend the colors
        // Color blendedColor = BlendColors(greenColorPart2, blueColorPart2, redColorPart2);
        // Debug.Log($"Blended Color - R: {blendedColor.r}, G: {blendedColor.g}, B: {blendedColor.b}");
    }

    private float DotProduct(float a1, float a2, float a3, float b1, float b2, float b3)
    {
        return (a1 * b1 + a2 * b2 + a3 * b3);
    }

     private void ChangeLightBeamColor(GameObject lightBeamPart, Color originalColor, float percentage)
    {
        percentage = Mathf.Clamp01(percentage);
        Color newColor = originalColor;
        newColor.a *= percentage;
        lightBeamPart.GetComponent<Renderer>().material.color = newColor;
    }

    float CalculateNewDiameter(float percentage, float originalDiameter)
    {
        // Ensure percentage is within bounds
        percentage = Mathf.Clamp01(percentage);

        // Calculate the new diameter based on the desired area
        float originalRadius = originalDiameter / 2f;
        float originalArea = Mathf.PI * originalRadius * originalRadius;
        float newArea = percentage * originalArea;
        float newRadius = Mathf.Sqrt(newArea / Mathf.PI);
        float newDiameter = 2f * newRadius;

        return newDiameter;
    }

    void UpdateCylinderDiameter(GameObject cylinder, float newDiameter)
    {
        // Adjust the scale based on the new diameter
        Vector3 newScale = cylinder.transform.localScale;
        newScale.x = newDiameter;
        newScale.z = newDiameter; // Assuming uniform scaling for the cylinder

        cylinder.transform.localScale = newScale;
    }

    void UpdateConeBaseDiameter(GameObject cone, float newDiameter)
    {
        // Adjust the scale based on the new diameter
        Vector3 newScale = cone.transform.localScale;
        newScale.x = newDiameter;

        cone.transform.localScale = newScale;
    }


    //this function is better
    // private Color BlendColors(Color color1, Color color2, Color color3)
    // {
    //     // Initialize counters for the sum of each color component
    //     float sumR = 0f;
    //     float sumG = 0f;
    //     float sumB = 0f;

    //     // Initialize a count of non-transparent colors
    //     int count = 0;

    //     // Add the RGB components of each color to the sum if the alpha value is greater than zero
    //     if (color1.a > 0)
    //     {
    //         sumR += color1.r;
    //         sumG += color1.g;
    //         sumB += color1.b;
    //         count++;
    //     }
    //     if (color2.a > 0)
    //     {
    //         sumR += color2.r;
    //         sumG += color2.g;
    //         sumB += color2.b;
    //         count++;
    //     }
    //     if (color3.a > 0)
    //     {
    //         sumR += color3.r;
    //         sumG += color3.g;
    //         sumB += color3.b;
    //         count++;
    //     }

    //     // Calculate the new alpha value by taking the minimum alpha value among the input colors and reducing it by half
    //     //float alpha = count > 0 ? Mathf.Max(color1.a, color2.a, color3.a) : 0f;
    //     float alpha = Mathf.Min(1, color1.a + color2.a + color3.a);

    //     // Create and return the blended color with the summed RGB values and smaller alpha value
    //     return new Color(sumR, sumG, sumB, alpha);
    // }


}
