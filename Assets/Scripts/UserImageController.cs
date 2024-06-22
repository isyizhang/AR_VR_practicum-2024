using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UserImageController : MonoBehaviour
{
    public Image userImage; // UI Image to display the user image
    private int currentIndex = 0;

    void DisplayUser(string userName)
    {
        Sprite userSprite = Resources.Load<Sprite>(userName);
        if (userSprite != null)
        {
            userImage.sprite = userSprite;
        }
        else
        {
            Debug.LogError("Failed to load sprite: " + userName);
        }
    }

    public void ShowNextUserImage()
    {
        if (UserDatabase.userNames != null && UserDatabase.userNames.Count > 0)
        {
            currentIndex = (currentIndex + 1) % UserDatabase.userNames.Count;
            DisplayUser(UserDatabase.userNames[currentIndex]);
            Debug.Log("ShowNextUserImage is called " + currentIndex);
        }
    }

    public void ShowPreviousUserImage()
    {
        if (UserDatabase.userNames != null && UserDatabase.userNames.Count > 0)
        {
            currentIndex = (currentIndex - 1 + UserDatabase.userNames.Count) % UserDatabase.userNames.Count;
            DisplayUser(UserDatabase.userNames[currentIndex]);
            Debug.Log("ShowPreviousUserImage is called " + currentIndex);
        }
    }
}
