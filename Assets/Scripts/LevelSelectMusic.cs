using UnityEngine;

public class LevelSelectMusic : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
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

