using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFPS : MonoBehaviour
{
    public static float fps;
    public TextMeshProUGUI text;
    private AudioSource Source;
    private void Awake()
    {
        Source = gameObject.GetComponent<AudioSource>();
        AudioManager.Instance.Sounds.Add(Source);
    }
    private void Start()
    {
        StartCoroutine(CheckFPS());
    }
    private void Update()
    {
        fps = Mathf.RoundToInt( 1.0f / Time.deltaTime);
    }
    private IEnumerator CheckFPS()
    {
        text.text = fps.ToString();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CheckFPS());
    }
}