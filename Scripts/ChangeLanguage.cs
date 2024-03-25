using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ChangeLanguage : MonoBehaviour
{
    public static ChangeLanguage Instance;
    private bool _isActive = false;
    private int _id;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StartCoroutine(SetLocale(0));
        if (PlayerPrefs.HasKey("Language"))
            StartCoroutine(SetLocale(PlayerPrefs.GetInt("Language")));
        else
        {
            switch (Application.systemLanguage)
            {
                case SystemLanguage.Ukrainian:
                {
                    StartCoroutine(SetLocale(2));
                    break;
                }
                case SystemLanguage.Russian:
                {
                    StartCoroutine(SetLocale(1));
                    break;
                }
                default:
                {
                    StartCoroutine(SetLocale(0));
                    break;
                }
            }
        }
    }
    public void ChangeLocale()
    {
        if (_isActive)
            return;
        _id++;
        if (_id >= 3)
            _id = 0;
        StartCoroutine(SetLocale(_id));
    }
    IEnumerator SetLocale(int _localeID)
    {
        _isActive = true;
        yield return LocalizationSettings.InitializationOperation;
        PlayerPrefs.SetInt("Language", _localeID);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        _isActive = false;
    }
}
