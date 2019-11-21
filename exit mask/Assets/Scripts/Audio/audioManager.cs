using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static audioManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.ignoreListenerPause = s.ignorePause;
        }
    }


    private void Start()
    {
      
    }

    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.clip.name == name);

        if (s == null) // debugging
        {
            Debug.LogWarning("Sound:" + name + " missing.");
            return;
        }

        s.source.Play();
    }



}