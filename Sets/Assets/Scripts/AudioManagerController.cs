using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManagerController : MonoBehaviour
{
	public Sound[] sounds;

    public static AudioManagerController instance;

    void Awake()
    {
        if(instance== null){
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name){
        Sound s = GetSound(name);
        s.source.Play();
    }

    public void Stop(string name){
        Sound s = GetSound(name);
        s.source.Stop();
    }

    private Sound GetSound(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return null;
        }
        return s;
    }
}
