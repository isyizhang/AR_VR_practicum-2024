using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeCompleteListener : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip completeClip;
    private Image itemImage;
    private bool hasPlayedSound;

    void Start()
    {
        itemImage = GetComponent<Image>();
        if (itemImage == null)
        {
            Debug.LogError("ItemImageController: No Image component found on this GameObject.");
        }

        if (audioSource == null)
        {
            Debug.LogError("ItemImageController: No AudioSource component found on this GameObject.");
        }
        hasPlayedSound = false;
    }

    void Update()
    {
        if (itemImage != null && audioSource != null && completeClip != null)
        {
            Color color = itemImage.color;
            float alpha = color.a;
             if(alpha <= 150f / 255f){
                hasPlayedSound = false;
             }

            // Check if the alpha value exceeds the threshold
            if (alpha >= 150f / 255f && alpha <= 180f /255f && !hasPlayedSound)
            {
                PlayCompleteClip();
                hasPlayedSound = true;
            }
        }
    }

    private void PlayCompleteClip()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(completeClip);
        }
    }
}
