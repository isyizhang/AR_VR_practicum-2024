using UnityEngine;
public class IsChallengeManager : MonoBehaviour
{
    public static bool isChallenge1 = false;

    private void Awake()
    {
        // Ensure this object is not destroyed on scene load
        DontDestroyOnLoad(gameObject);
    }

    public static void SetChallenge1State(bool state)
    {
        isChallenge1 = state;
    }
}
