using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
    public AudioSource[] Source;
    public AudioClip CloseMenu;
    public AudioClip ShortClick;
    public AudioClip RepairSound;
    public AudioClip MoneyDecreaseSound;
    public AudioClip ConvertMoney;
    public AudioClip TaskComplete;
    private void Awake()
    {
        for (int i = 0; i < Source.Length; i++)
            AudioManager.Instance.Sounds.Add(Source[i]);
    }
    public void PlaySound(AudioClip clip)
    {
        Source[0].clip = clip;
        Source[0].Play();
    }
    public void PlaySoundSecond(AudioClip clip)
    {
        Source[1].clip = clip;
        Source[1].Play();
    }
    public void PlaySoundThird(AudioClip clip)
    {
        Source[2].clip = clip;
        Source[2].Play();
    }
}
