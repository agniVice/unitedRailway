using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using TMPro;
public class UITweenMainMenu : MonoBehaviour
{   
    [Header("Main")]
    [SerializeField] private RectTransform unitedRailway;
    [SerializeField] private RectTransform buttonPlay;
    [SerializeField] private RectTransform buttonSettings;
    [SerializeField] private RectTransform buttonShop;
    [SerializeField] private RectTransform buttonLanguage;
    [SerializeField] private RectTransform panelPlayGames;
    [SerializeField] private RectTransform panelHide;
    [SerializeField] private RectTransform panelMain;
    [Header("Missions")]
    [SerializeField] private RectTransform panelMissions;
    [SerializeField] private RectTransform starsText;
    [SerializeField] private RectTransform starsImage;
    public RectTransform buttonPlayMission;
    public RectTransform buttonNextMap;
    public RectTransform buttonPrevMap;
    [SerializeField] private RectTransform buttonReturnFromMissions;
    [SerializeField] private RectTransform buttonNextLocation;
    [SerializeField] private RectTransform buttonPrevLocation;
    [SerializeField] private RectTransform panelEffect;
    [Space]
    [Header("Settings")]
    [SerializeField] private RectTransform panelSettings;
    [SerializeField] private List<RectTransform> starsRateImage;
    [SerializeField] private RectTransform buttonRate;
    [SerializeField] private RectTransform buttonSound;
    [SerializeField] private RectTransform buttonReturnFromSettings;
    [SerializeField] private RectTransform buttonMusic;
    [SerializeField] private RectTransform buttonShadows;
    [SerializeField] private RectTransform settingsText;

    [SerializeField] private Sprite buttonDisabled;
    [SerializeField] private Sprite buttonEnabled;
    [SerializeField] private Color buttonDisabledColor;
    [SerializeField] private Color buttonEnabledColor;

    [Space]
    [Header("Donate")]
    [SerializeField] private RectTransform panelDonate;
    [SerializeField] private RectTransform buttonReturnFromDonate;
    [SerializeField] private List<RectTransform> buttonDonate;

    [SerializeField] private LocalizeStringEvent ad_panel;
    [SerializeField] private Image ad_panelImage;

    [SerializeField] private Sprite noAdSprite;
    [SerializeField] private Button buttonNoAd;
    [SerializeField] private Button buttonChanceX3;

    [SerializeField] private TextMeshProUGUI tickets;

    [Space]
    public bool _IsMissionsOpen;
    public bool _IsSettingsOpen;
    public bool _IsDonateOpen;

    public void Start()
    {
        Invoke("OpenHomeScreen", 1f);
        StartCoroutine(Init());
    }
    private IEnumerator Init()
    {
        yield return new WaitForSeconds(0.1f);
        if (AudioManager.Instance.IsSoundOn == 1)
        {
            buttonSound.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonSound.GetComponentInChildren<TextMeshProUGUI>().color = buttonEnabledColor;
            buttonSound.GetComponent<Image>().sprite = buttonEnabled;
        }
        else
        {
            buttonSound.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonSound.GetComponentInChildren<TextMeshProUGUI>().color = buttonDisabledColor;
            buttonSound.GetComponent<Image>().sprite = buttonDisabled;
        }
        if (AudioManager.Instance.IsMusicOn == 0)
        {
            buttonMusic.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonMusic.GetComponentInChildren<TextMeshProUGUI>().color = buttonDisabledColor;
            buttonMusic.GetComponent<Image>().sprite = buttonDisabled;
        }
        else
        {
            buttonMusic.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonMusic.GetComponentInChildren<TextMeshProUGUI>().color = buttonEnabledColor;
            buttonMusic.GetComponent<Image>().sprite = buttonEnabled;
        }
        if (QalityManager.Instance.IsShadowsOn == 0)
        {
            buttonShadows.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonShadows.GetComponentInChildren<TextMeshProUGUI>().color = buttonDisabledColor;
            buttonShadows.GetComponent<Image>().sprite = buttonDisabled;
        }
        else
        {
            buttonShadows.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonShadows.GetComponentInChildren<TextMeshProUGUI>().color = buttonEnabledColor;
            buttonShadows.GetComponent<Image>().sprite = buttonEnabled;
        }
        yield return null;
    }
    public void OpenMissioonsMenu()
    {
        _IsMissionsOpen = true;
        panelMain.DOAnchorPos(new Vector2(-1500,0), 0.7f).SetEase(Ease.OutCubic);
        panelPlayGames.DOAnchorPos(new Vector2(0,-230), 0.7f).SetEase(Ease.OutCubic);
        panelMissions.gameObject.SetActive(true);
        panelMissions.DOAnchorPos(new Vector2(0,0), 0.7f).SetEase(Ease.OutCubic).OnComplete(() => { if (_IsMissionsOpen) {panelMain.gameObject.SetActive(false); panelPlayGames.gameObject.SetActive(false);}});
    }
    public void CloseMissionsMenu()
    {
        _IsMissionsOpen = false;
        panelMain.gameObject.SetActive(true);
        panelMain.DOAnchorPos(new Vector2(0, 0), 0.7f).SetEase(Ease.OutCubic);
        panelPlayGames.gameObject.SetActive(true);
        panelPlayGames.DOAnchorPos(new Vector2(0,0), 0.7f).SetEase(Ease.OutCubic);
        panelMissions.DOAnchorPos(new Vector2(1500, 0), 0.7f).SetEase(Ease.OutCubic).OnComplete(() => { if (!_IsMissionsOpen) {panelMissions.gameObject.SetActive(false);}});
    }
    public void OpenHomeScreen()
    {
        unitedRailway.localScale = Vector3.zero;
        buttonPlay.localScale = Vector3.zero;
        buttonSettings.localScale = Vector3.zero;
        buttonShop.localScale = Vector3.zero;
        buttonLanguage.localScale = Vector3.zero;
        panelPlayGames.localScale = Vector3.zero;
        panelHide.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() => { panelHide.gameObject.SetActive(false); });
        panelEffect.gameObject.SetActive(false);
        unitedRailway.DOScale(0.75f, 0.3f).SetEase(Ease.OutBack).SetDelay(0);
        buttonPlay.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
        buttonSettings.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.4f);
        buttonShop.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.5f);
        buttonLanguage.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.4f);
        panelPlayGames.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.5f);
    }
    public void OpenSettings()
    {
        _IsSettingsOpen = true;
        panelMain.DOAnchorPos(new Vector2(1500, 0), 0.7f).SetEase(Ease.OutCubic);

        buttonSound.localScale = Vector2.zero;
        buttonMusic.localScale = Vector2.zero;
        buttonShadows.localScale = Vector2.zero;
        buttonSound.DOScale(1f, 0.2f).SetEase(Ease.OutBack).SetDelay(0.5f);
        buttonMusic.DOScale(1f, 0.2f).SetEase(Ease.OutBack).SetDelay(0.58f);
        buttonShadows.DOScale(1f, 0.2f).SetEase(Ease.OutBack).SetDelay(0.64f);

        panelPlayGames.DOAnchorPos(new Vector2(0, -230), 0.7f).SetEase(Ease.OutCubic);
        panelSettings.gameObject.SetActive(true);
        panelSettings.DOAnchorPos(new Vector2(0, 0), 0.7f).SetEase(Ease.OutCubic).OnComplete(() => { if (_IsSettingsOpen) { panelMain.gameObject.SetActive(false); panelPlayGames.gameObject.SetActive(false); } });
    }
    public void CloseSettings()
    {
        _IsSettingsOpen = false;
        panelMain.gameObject.SetActive(true);
        panelMain.DOAnchorPos(new Vector2(0, 0), 0.7f).SetEase(Ease.OutCubic);
        panelPlayGames.gameObject.SetActive(true);
        panelPlayGames.DOAnchorPos(new Vector2(0, 0), 0.7f).SetEase(Ease.OutCubic);
        panelSettings.DOAnchorPos(new Vector2(-1500, 0), 0.7f).SetEase(Ease.OutCubic).OnComplete(() => { if (!_IsSettingsOpen) { panelSettings.gameObject.SetActive(false); } });
    }
    public void OpenDonate()
    {
        tickets.text = FindObjectOfType<PlayerData>().GetTickets().ToString();
        _IsDonateOpen = true;
        panelMain.DOAnchorPos(new Vector2(0, 2000), 0.7f).SetEase(Ease.OutCubic);
        panelPlayGames.DOAnchorPos(new Vector2(0, -230), 0.7f).SetEase(Ease.OutCubic);
        panelDonate.gameObject.SetActive(true);
        panelDonate.DOAnchorPos(new Vector2(0, 0), 0.7f).SetEase(Ease.OutCubic).OnComplete(() => { if (_IsDonateOpen) { panelMain.gameObject.SetActive(false); panelPlayGames.gameObject.SetActive(false); } });

        float time = 0.4f;
        foreach (RectTransform button in buttonDonate)
        {
            button.localScale = Vector2.zero;
            button.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(time);
            time += 0.08f;
            //button.GetComponentInChildren<RectTransform>().localScale = new Vector2(1, 1);
        }
        buttonReturnFromDonate.localScale = Vector2.zero;
        buttonReturnFromDonate.DOScale(1f, 0.3f).SetEase(Ease.OutBack).SetDelay(0.4f);
        RefreshDonateMenu();
    }
    public void RefreshDonateMenu()
    {
        tickets.text = FindObjectOfType<PlayerData>().GetTickets().ToString();
        if (PlayerPrefs.HasKey("AdDisabled"))
        {
            if (PlayerPrefs.GetInt("AdDisabled") == 1)
            {
                ad_panel.SetEntry("NoAD_DonateMenu");
                ad_panel.StringReference.RefreshString();

                ad_panelImage.sprite = noAdSprite;

                buttonNoAd.interactable = false;
                buttonNoAd.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
        if (PlayerPrefs.HasKey("ChanceX3"))
        {
            if (PlayerPrefs.GetInt("ChanceX3") == 1)
            {
                buttonChanceX3.interactable = false;
                buttonChanceX3.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
    public void CloseDonate()
    {
        _IsDonateOpen = false;
        panelMain.gameObject.SetActive(true);
        panelMain.DOAnchorPos(new Vector2(0, 0), 0.7f).SetEase(Ease.OutCubic);
        panelPlayGames.gameObject.SetActive(true);
        panelPlayGames.DOAnchorPos(new Vector2(0, 0), 0.7f).SetEase(Ease.OutCubic);
        panelDonate.DOAnchorPos(new Vector2(0, -2000), 0.7f).SetEase(Ease.OutCubic).OnComplete(() => { if (!_IsDonateOpen) { panelDonate.gameObject.SetActive(false); } });
    }
    public void Play()
    {
        buttonPlayMission.DOScale(0.7f, 0.15f).SetEase(Ease.OutBack);
        buttonPlayMission.GetComponent<Button>().interactable = false;
        buttonPlayMission.DOScale(0f, 0.2f).SetEase(Ease.OutBack).SetDelay(0.15f).OnComplete(() => 
        {
            panelEffect.gameObject.SetActive(true);
            panelEffect.GetComponent<Image>().DOColor(new Color32(0, 0, 0, 255), 0.3f).SetEase(Ease.OutCubic);
            panelEffect.DOScale(new Vector3(20, 30, 30), 0.5f).SetEase(Ease.OutBack).OnComplete(() => { DOTween.KillAll(); });
        });
    }
    public void ToggleSound()
    {
        buttonSound.localScale = Vector3.zero;
        buttonSound.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        AudioManager.Instance.ToggleSound();
        if (AudioManager.Instance.IsSoundOn == 0)
        {
            buttonSound.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonSound.GetComponentInChildren<TextMeshProUGUI>().color = buttonDisabledColor;
            buttonSound.GetComponent<Image>().sprite = buttonDisabled;
        }
        else
        {
            buttonSound.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonSound.GetComponentInChildren<TextMeshProUGUI>().color = buttonEnabledColor;
            buttonSound.GetComponent<Image>().sprite = buttonEnabled;
        }
    }
    public void ToggleMusic()
    {
        buttonMusic.localScale = Vector3.zero;
        buttonMusic.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        AudioManager.Instance.ToggleMusic();
        if (AudioManager.Instance.IsMusicOn == 0)
        {
            buttonMusic.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonMusic.GetComponentInChildren<TextMeshProUGUI>().color = buttonDisabledColor;
            buttonMusic.GetComponent<Image>().sprite = buttonDisabled;
        }
        else
        {
            buttonMusic.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonMusic.GetComponentInChildren<TextMeshProUGUI>().color = buttonEnabledColor;
            buttonMusic.GetComponent<Image>().sprite = buttonEnabled;
        }
    }
    public void ToggleShadows()
    {
        buttonShadows.localScale = Vector3.zero;
        buttonShadows.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        QalityManager.Instance.ToggleShadows();
        if (QalityManager.Instance.IsShadowsOn == 0)
        {
            buttonShadows.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonShadows.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = buttonDisabledColor;
            buttonShadows.gameObject.GetComponent<Image>().sprite = buttonDisabled;
        }
        else
        {
            buttonShadows.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonShadows.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = buttonEnabledColor;
            buttonShadows.gameObject.GetComponent<Image>().sprite = buttonEnabled;
        }
    }
}
