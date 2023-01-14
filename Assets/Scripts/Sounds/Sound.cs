using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [Tooltip("The name which is later on used to reference this clip")]
    public string name;

    public AudioClip clip;

    [Space]

    [Range(0f, 1f)]
    public float volume = 1.0f;
    [Range(.1f, 3f)]
    public float pitch = 1.0f;

    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
