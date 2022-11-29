using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip audioFile;
    
    [Range(0f, 1f)]
    public float volume;
    
    [Range(.1f, 2f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
