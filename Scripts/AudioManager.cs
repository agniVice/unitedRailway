using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public List<AudioSource> Sounds;
    public List<AudioSource> Music;
    public int IsSoundOn;
    public int IsMusicOn;
    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        Init();
    }
    public void Init()
    {
        if (PlayerPrefs.HasKey("Sound"))
            IsSoundOn = PlayerPrefs.GetInt("Sound");
        else
        {
            IsSoundOn = 1;
            PlayerPrefs.SetInt("Sound", IsSoundOn);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("Music"))
            IsMusicOn = PlayerPrefs.GetInt("Music");
        else
        {
            IsMusicOn = 1;
            PlayerPrefs.SetInt("Music", IsMusicOn);
            PlayerPrefs.Save();
        }
        if (IsSoundOn == 0)
        {
            foreach (AudioSource source in Sounds)
                source.mute = true;
        }
        else
        {
            foreach (AudioSource source in Sounds)
                source.mute = false;
        }
        if (IsMusicOn == 0)
        {
            foreach (AudioSource source in Music)
                source.mute = true;
        }
        else
        {
            foreach (AudioSource source in Music)
                source.mute = false;
        }
    }
    public void ToggleSound()
    {
        if (IsSoundOn == 1)
        {
            IsSoundOn = 0;
            PlayerPrefs.SetInt("Sound", IsSoundOn);
            PlayerPrefs.Save();
            foreach (AudioSource source in Sounds)
                source.mute = true;
        }
        else
        {
            IsSoundOn = 1;
            PlayerPrefs.SetInt("Sound", IsSoundOn);
            PlayerPrefs.Save();
            foreach (AudioSource source in Sounds)
                source.mute = false;
        }
    }
    public void ToggleMusic()
    {
        if (IsMusicOn == 1)
        {
            IsMusicOn = 0;
            PlayerPrefs.SetInt("Music", IsMusicOn);
            PlayerPrefs.Save();
            foreach (AudioSource source in Music)
                source.mute = true;
        }
        else
        {
            IsMusicOn = 1;
            PlayerPrefs.SetInt("Music", IsMusicOn);
            PlayerPrefs.Save();
            foreach (AudioSource source in Music)
                source.mute = false;
        }
    }
    private void Save()
    {
        PlayerPrefs.Save();
    }
}
