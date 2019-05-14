using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Music {
    TITLEMUSIC, GAMEPLAYMUSIC, TUTORIALMUSIC
}

public class MusicTrigger : MonoBehaviour
{
    public Music trackName;
    private AudioManagerController am;
    private float timer = 0.05f;
    private bool done = false;

    private void Update()
    {
        //This is an incredibly rough workaround that lets the duplicate AudioManager get destroyed before changing the music
        if(!done){
            timer -= Time.deltaTime;
            if(timer < 0){
                done = true;
                am = FindObjectOfType<AudioManagerController>();
                switch (trackName)
                {
                    case Music.TITLEMUSIC:
                        am.Stop("TutorialMusic");
                        am.Stop("GameplayMusic");
                        if (!am.IsPlaying("TitleMusic")) am.Play("TitleMusic");
                        break;
                    case Music.GAMEPLAYMUSIC:
                        am.Stop("TutorialMusic");
                        am.Stop("TitleMusic");
                        if (!am.IsPlaying("GameplayMusic")) am.Play("GameplayMusic");
                        break;
                    case Music.TUTORIALMUSIC:
                        am.Stop("TitleMusic");
                        am.Stop("GameplayMusic");
                        if (!am.IsPlaying("TutorialMusic")) am.Play("TutorialMusic");
                        break;
                    default:
                        am.Stop("TitleMusic");
                        am.Stop("GameplayMusic");
                        am.Stop("TutorialMusic");
                        break;
                }
            }
        }
    }
}
