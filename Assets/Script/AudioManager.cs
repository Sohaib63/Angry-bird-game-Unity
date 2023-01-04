using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    public void Awake()
    {
        if (instance == null)
        {
            instance=this;
        }
        foreach (var sound in sounds)
        {
            sound.mera_source = gameObject.AddComponent<AudioSource>();
            sound.mera_source.clip = sound.clip;
            sound.mera_source.pitch = sound.pitch;
            sound.mera_source.volume = sound.volume;
            sound.mera_source.loop = sound.loop;
        }
    }

    public void PlayMySound(string name)
    {
        foreach (var sound in sounds)
        {
            if (sound.name == name)
            {
               sound.mera_source.Play();
            }
        }
    }
}
