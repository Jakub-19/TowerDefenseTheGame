using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public GameObject completeLevelUI;
    private bool hasWonAlready = false;
    private AudioSource ambient;
    void Start()
    {
        GameObject music = GameObject.FindGameObjectWithTag("MenuMusic");
        if (music != null)
        {
            music.GetComponent<MainMenuMusic>().StopMusic();
            Destroy(music);
            MusicManagement.isMainMenuMusicPlaying = false;
            return;
        }
        music = GameObject.FindGameObjectWithTag("LevelSelectMusic");
        if (music != null)
        {
            music.GetComponent<LevelSelectMusic>().StopMusic();
            Destroy(music);
            MusicManagement.isMainMenuMusicPlaying = false;
            return;
        }
        
    }
    void Update()
    {
        if(hasWonAlready)
        {
            return;
        }
        else
        {
            if (completeLevelUI.activeInHierarchy)
            {
                ambient = GetComponent<AudioSource>();
                hasWonAlready = true;
                StartCoroutine(LowerVolume());
            }
        }
    }
    IEnumerator LowerVolume()
    {
        ambient.volume = 0.1f;
        if(Time.timeScale == 1f)
            yield return new WaitForSeconds(10f);
        else
            yield return new WaitForSeconds(20f);
        ambient.volume = 1f;
    }
}
