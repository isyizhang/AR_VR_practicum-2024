using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextGuidance : MonoBehaviour
{
    public float ThisTextValue;

    public void TextSetActive(float currentTextValue)
    {
        if (currentTextValue == ThisTextValue)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
