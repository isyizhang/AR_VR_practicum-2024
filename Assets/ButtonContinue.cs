using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinue : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip continueClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        if (audioSource != null && continueClip != null)
        {
            audioSource.PlayOneShot(continueClip);
        }
    }

}
