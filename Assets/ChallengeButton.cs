using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengeButton : MonoBehaviour
{
    
    public void OnChallenge1ButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnChallenge2ButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }
}

