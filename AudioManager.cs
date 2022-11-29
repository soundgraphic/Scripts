using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Audio[] audios;
    public static AudioManager instancia;

    float volumeValue;
    float lastVolumeValue;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
           
        else
        {
            Destroy(gameObject);
        }
        
        foreach (Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.audioFile;
            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
        }
    }
    private void Start()
    {
        volumeValue = volumeSlider.value;
        Play("Musica");
    }

    private void Update()
    {
        volumeValue = volumeSlider.value;

        if (volumeValue != lastVolumeValue)
        {
            ChangeVolume();
        }
        lastVolumeValue = volumeValue;
    }

    public void Play(string name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);

        if (a == null)
        {
            Debug.LogWarning("El nombre del Audio " + name + " no existe");
            return;
        }
        a.source.Play();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeValue;
    }
}
