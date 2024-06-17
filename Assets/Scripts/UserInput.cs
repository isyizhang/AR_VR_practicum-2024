using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    private float attribute1;
    private float attribute2;
    private float attribute3;
    public Screen screen;
    private PolarizingFilm film11;
    private PolarizingFilm film12;
    private PolarizingFilm film13;

    public float[] GetUserInterests()
    {
        return new float[] { attribute1, attribute2, attribute3 };
    }

    void Start() 
    {
        GameObject filmGameObject11 = GameObject.Find("PolarizingFilm_1_1");
        film11 = filmGameObject11.GetComponent<PolarizingFilm>();
        
        GameObject filmGameObject12 = GameObject.Find("PolarizingFilm_1_2");
        film12 = filmGameObject12.GetComponent<PolarizingFilm>();

        GameObject filmGameObject13 = GameObject.Find("PolarizingFilm_1_3");
        film13 = filmGameObject13.GetComponent<PolarizingFilm>();
      
    }


    void Update() {
        // attribute1 = film11.Value;
        // attribute2 = film12.Value;
        // attribute3 = film13.Value;
        if (screen != null)
        {
            attribute1 = screen.A1;
            attribute2 = screen.A2;
            attribute3 = screen.A3;
        }
       //Debug.Log("user a1" + attribute1);
    }
}
