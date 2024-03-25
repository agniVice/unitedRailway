using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QalityManager : MonoBehaviour
{
    public static QalityManager Instance;
    public Light SceneLight;
    public int IsShadowsOn;
    private void Awake()
    {
        Instance = this;
        Init();
    }
    public void Init()
    {
        if (PlayerPrefs.HasKey("Shadows"))
            IsShadowsOn = PlayerPrefs.GetInt("Shadows");
        else
        {
            IsShadowsOn = 1;
            PlayerPrefs.SetInt("Shadows", IsShadowsOn);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetInt("Shadows") == 0)
            SceneLight.shadowStrength = 0;
        else
            SceneLight.shadowStrength = 0.8f;
    }
    public void ToggleShadows()
    {
        SceneLight = FindObjectOfType<Light>();

        if (IsShadowsOn == 1)
        {
            IsShadowsOn = 0;
            PlayerPrefs.SetInt("Shadows", IsShadowsOn);
            PlayerPrefs.Save();
            SceneLight.shadowStrength = 0f;
        }
        else
        {
            IsShadowsOn = 1;
            PlayerPrefs.SetInt("Shadows", IsShadowsOn);
            PlayerPrefs.Save();
            SceneLight.shadowStrength = 0.9f;
        }
    }
}
