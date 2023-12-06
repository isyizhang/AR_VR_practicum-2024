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

    PolarizingFilm film11;
    PolarizingFilm film12;
    PolarizingFilm film13;
    PolarizingFilm film21;
    PolarizingFilm film22;
    PolarizingFilm film23;


    // Start is called before the first frame update
    void Start()
    {
        GameObject filmGameObject11 = GameObject.Find("PolarizingFilm_1_1");
        film11 = filmGameObject11.GetComponent<PolarizingFilm>();

        GameObject filmGameObject12 = GameObject.Find("PolarizingFilm_1_2");
        film12 = filmGameObject12.GetComponent<PolarizingFilm>();

        GameObject filmGameObject13 = GameObject.Find("PolarizingFilm_1_3");
        film13 = filmGameObject13.GetComponent<PolarizingFilm>();

        GameObject filmGameObject21 = GameObject.Find("PolarizingFilm_2_1");
        film21 = filmGameObject21.GetComponent<PolarizingFilm>();

        GameObject filmGameObject22 = GameObject.Find("PolarizingFilm_2_2");
        film22 = filmGameObject22.GetComponent<PolarizingFilm>();

        GameObject filmGameObject23 = GameObject.Find("PolarizingFilm_2_3");
        film23 = filmGameObject23.GetComponent<PolarizingFilm>();

    }

    // Update is called once per frame
    void Update()
    {
        a1 = film11.Value;
        a2 = film12.Value;
        a3 = film13.Value;
        b1 = film21.Value;
        b2 = film22.Value;
        b3 = film23.Value;
        value = DotProduct(a1, a2, a3, b1, b2, b3);
        text.GetComponent<TextMeshPro>().text = value.ToString();
    }

    private int DotProduct(int a1, int a2, int a3, int b1, int b2, int b3)
    {
        return a1 * b1 + a2 * b2 + a3 * b3;
    }
}
