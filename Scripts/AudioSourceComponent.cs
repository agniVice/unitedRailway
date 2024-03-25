using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceComponent : MonoBehaviour
{
    private AudioSource Source;
    private void Start()
    {
        gameObject.SetActive(true);
        Source = gameObject.GetComponent<AudioSource>();
        AudioManager.Instance.Sounds.Add(Source);
        gameObject.SetActive(false);
    }
}
