using UnityEngine.Audio;
using UnityEngine;
using System;

/// <summary>
/// A very simple AudioManager class, which takes care of managing all sounds in one place.
/// This class is implemented as a simple Singleton class which is kept over scenes.
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
public class AudioManager : MonoBehaviour
{
    public const string PlayerPrefsMuteAudio = "mute_audio_flag";

    public Sound[] sounds;
    public static AudioManager instance;

    // Note: Awake is called before the Start() function
    // Read more here: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    void Awake()
    {
        // Note: This is basically a singleton approach
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep the Audiomanager

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        // E.g. play a sound: `Play("Sonar");`
    }

    // Update is called once per frame
    public void Play (string name)
    {
        var muted = PlayerPrefs.GetInt(PlayerPrefsMuteAudio)==1;
        if (muted) return;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogError("Sound not found: " + name);
            return;
        }
        s.source.Play();
    }
}
