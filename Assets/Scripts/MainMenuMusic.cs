using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!MusicManagement.isMainMenuMusicPlaying)
        {
            DontDestroyOnLoad(transform.gameObject);
            audioSource.enabled = true;
            MusicManagement.isMainMenuMusicPlaying = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) 
            return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
