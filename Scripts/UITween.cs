using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Components;

public class UITween : MonoBehaviour
{
    [SerializeField] SceneManagerScript sManager;
    [SerializeField] public RectTransform
    /*MainMenu*/
    build_mui, tasks_mui, shop_mui, depot_mui, priceList_mui, panelMoney_mui, panelTickets_mui,
    menu_mui, exp_mui, reward_mui, timer_mui, priceGrow_mui, priceDecrease_mui, priceUnknown_mui, vignette_mui, noad_mui;
    [Header("BuildRail")]
    [SerializeField] private RectTransform titleText_brui;
    [SerializeField] public RectTransform buttonCancel_brui;
    [SerializeField] public RectTransform buttonBuild_brui;
    [SerializeField] private RectTransform buttonBuildText_brui;
    [Header("WaySelect")]
    [SerializeField] private CanvasGroup panel_wsui;
    [SerializeField] private RectTransform titleText_wsui;
    [SerializeField] private RectTransform imageFirst_wsui;
    [SerializeField] private RectTransform imageSecond_wsui;
    [SerializeField] public RectTransform buttonCancel_wsui;
    [SerializeField] private RectTransform buttonSet_wsui;
    [Header("BgFB")]
    [SerializeField] private CanvasGroup panel_bgui;
    [SerializeField] private RectTransform ppanel_bgui;
    public RectTransform buttonClose_bgui;
    [SerializeField] private RectTransform buttonMoney_bgui;
    [SerializeField] private RectTransform buttonTickets_bgui;
    [Header("Town")]
    [SerializeField] private CanvasGroup panel_townui;
    [SerializeField] private RectTransform ppanel_townui;
    [SerializeField] private RectTransform button_townui;
    [SerializeField] private RectTransform buttonText_townui;
    [Header("Raw")]
    [SerializeField] private CanvasGroup panel_rawui;
    [SerializeField] private RectTransform ppanel_rawui;
    public RectTransform button_rawui;
    [SerializeField] private RectTransform buttonText_rawui;
    [Header("Tasks")]
    [SerializeField] private CanvasGroup panel_taskui;
    [SerializeField] private RectTransform ppanel_taskui;
    [SerializeField] private RectTransform imageTimer_taskui;
    [SerializeField] private RectTransform imageTasks_taskui;
    [Header("Depot")]
    [SerializeField] private CanvasGroup panel_depotui;
    [SerializeField] private RectTransform ppanel_depotui;
    [SerializeField] private RectTransform button_depotui;
    [SerializeField] public RectTransform buttonShop_depotui;
    [SerializeField] private RectTransform imageTrain_depotui;
    [SerializeField] private RectTransform text_depotui;
    [Header("TrainShop")]
    [SerializeField] private CanvasGroup panel_tshopui;
    [SerializeField] private RectTransform ppanel_tshopui;
    [Header("TrainMenu")]
    [SerializeField] private CanvasGroup panel_tmenuui;
    [SerializeField] private RectTransform ppanel_tmenuui;
    public RectTransform buttonUpgrade_tmenuui;
    [SerializeField] private RectTransform buttonRepair_tmenuui;
    [SerializeField] private RectTransform buttonSell_tmenuui;
    [SerializeField] private RectTransform text_tmenuui;
    [Header("RepairMneu")]
    [SerializeField] private CanvasGroup panel_repui;
    [SerializeField] private RectTransform ppanel_repui;
    [SerializeField] private RectTransform buttonRepair_repui;
    [SerializeField] private RectTransform buttonCancel_repui;
    [SerializeField] private RectTransform titleText_repui;
    [SerializeField] private RectTransform buttonRepairText_repui;
    [Header("SellMenu")]
    [SerializeField] private CanvasGroup panel_sellui;
    [SerializeField] private RectTransform ppanel_sellui;
    [SerializeField] private RectTransform buttonSell_sellui;
    [SerializeField] private RectTransform buttonCancel_sellui;
    [SerializeField] private RectTransform imageTrain_sellui;
    [SerializeField] private RectTransform sellText_sellui;
    [Header("WagonMenu")]
    [SerializeField] private CanvasGroup panel_wagui;
    [SerializeField] private RectTransform ppanel_wagui;
    [SerializeField] private RectTransform imageFreight_wagui;
    [SerializeField] private RectTransform imagePassenger_wagui;
    public RectTransform buttonFreight_wagui;
    public RectTransform buttonPassenger_wagui;
    [SerializeField] private RectTransform buttonFreightText_wagui;
    [SerializeField] private RectTransform buttonPassengerText_wagui;
    [SerializeField] private RectTransform buttonCancel_wagui;
    [Header("PriceList")]
    [SerializeField] private CanvasGroup panel_plistui;
    [SerializeField] private RectTransform ppanel_plistui;
    [SerializeField] private RectTransform time_plistui;
    [SerializeField] private RectTransform timer_plistui;
    [SerializeField] private RectTransform graph_plistui;
    [SerializeField] private RectTransform buttonAd_plistui;
    [SerializeField] private RectTransform button_plistui;
    [SerializeField] private RectTransform buttonText_plistui;
    [Header("Donate")]
    [SerializeField] private CanvasGroup panel_donateui;
    [SerializeField] private RectTransform ppanel_donateui;
    [SerializeField] private RectTransform[] button_donateui;
    [SerializeField] private RectTransform[] buttonText_donateui;
    [SerializeField] private RectTransform buttonExit_donateui;
    [Header("Convert")]
    [SerializeField] private CanvasGroup panel_convertui;
    [SerializeField] private RectTransform ppanel_convertui;
    [SerializeField] private RectTransform buttonExit_convertui;
    [SerializeField] private RectTransform buttonBuy_convertui;
    [SerializeField] private RectTransform buttonConvert_convertui;
    [SerializeField] private RectTransform background_convertui;
    [SerializeField] private CanvasGroup panelEffect_convertui;
    [SerializeField] private RectTransform effect_convertui;
    [Header("NoMoney")]
    [SerializeField] private CanvasGroup panel_nmui;
    [SerializeField] private RectTransform ppanel_nmui;
    [SerializeField] private RectTransform buttonOk_nmui;
    [SerializeField] private RectTransform buttonBuy_nmui;
    [SerializeField] private RectTransform buttonAd_nmui;
    [Header("GameOver")]
    [SerializeField] private Image panel_goui;
    [SerializeField] private RectTransform ppanel_goui;
    [SerializeField] private RectTransform pppanel_goui;
    [SerializeField] private RectTransform[] button_goui;
    [SerializeField] private RectTransform[] star_goui;
    [SerializeField] private Sprite starComplete;
    [SerializeField] private RectTransform tasks_goui;
    [SerializeField] private RectTransform time_goui;
    [SerializeField] private RectTransform[] stats_goui;
    [SerializeField] private RectTransform[] textStats_goui;
    [Header("PauseMenu")]
    [SerializeField] private CanvasGroup panel_pauseui;
    [SerializeField] private RectTransform ppanel_pauseui;
    [SerializeField] private RectTransform buttonResume_pauseui;
    [SerializeField] private RectTransform buttonRetry_pauseui;
    [SerializeField] private RectTransform buttonSettings_pauseui;
    [SerializeField] private RectTransform buttonMenu_pauseui;
    [Header("Settings")]
    [SerializeField] private CanvasGroup panel_settingsui;
    [SerializeField] private RectTransform ppanel_settingsui;
    [SerializeField] private RectTransform buttonReturn_settingsui;
    [SerializeField] private RectTransform buttonSound_settingsui;
    [SerializeField] private RectTransform buttonMusic_settingsui;
    [SerializeField] private RectTransform buttonShadows_settingsui;
    [SerializeField] private RectTransform buttonRate_settingsui;
    private bool isSettingsOpen;
    [Header("Transition")]
    [SerializeField] private GameObject canvasTout;
    [SerializeField] private RectTransform upTout;
    [SerializeField] private RectTransform downTout;
    [SerializeField] private CanvasGroup panelEffectTout;
    [Space]
    [SerializeField] private float speedMainUI = 1;
    [SerializeField] private UserInterfaceScript uiScript;
    [Header("WarningExit")]
    [SerializeField] private CanvasGroup panel_warningExit;
    [SerializeField] private RectTransform ppanel_warningExit;
    [SerializeField] private RectTransform buttonExit_warningExit;
    [SerializeField] private RectTransform buttonNo_warningExit;
    [Header("RewardedAd")]
    [SerializeField] private RectTransform panel_rewardedAd;
    [SerializeField] private GameObject canvasRewardedAd;
    private bool isWarningExitOpen;
    [Header("Audio")]
    public AudioSource[] SourceStars;
    public AudioSource Source;
    public AudioClip[] StarSound;
    private IEnumerator PlayStarsSound(int stars)
    {
        switch (stars)
        {
            case 1:
                {
                    yield return new WaitForSeconds(2.4f);
                    star_goui[0].GetComponent<AudioSource>().enabled = true;
                    break;
                }
            case 2:
                {
                    yield return new WaitForSeconds(2.4f);
                    star_goui[0].GetComponent<AudioSource>().enabled = true;
                    yield return new WaitForSeconds(0.3f);
                    star_goui[1].GetComponent<AudioSource>().enabled = true;
                    break;
                }
            case 3:
                {
                    yield return new WaitForSeconds(2.4f);
                    star_goui[0].GetComponent<AudioSource>().enabled = true;
                    yield return new WaitForSeconds(0.3f);
                    star_goui[1].GetComponent<AudioSource>().enabled = true;
                    yield return new WaitForSeconds(0.3f);
                    star_goui[2].GetComponent<AudioSource>().enabled = true;
                    break;
                }
        }
    }
    private void Awake()
    {
        AudioManager.Instance.Sounds.Add(Source);
        for (int i = 0; i < SourceStars.Length; i++)
            AudioManager.Instance.Sounds.Add(SourceStars[i]);
    }
    private void Start()
    {
        Invoke("OpenMainUI", 1f);
        TransitionOut();
    }
    public void TransitionOut()
    {
        panelEffectTout.alpha = 1f;
        canvasTout.SetActive(true);
        panelEffectTout.DOFade(0, 0.4f);
        upTout.localPosition = new Vector2(-282, 524);
        downTout.localPosition = new Vector2(175, -547);
        upTout.DOAnchorPos(new Vector2(-803, 1614), 1f).SetDelay(0.1f);
        downTout.DOAnchorPos(new Vector2(868, -1486), 1f).SetDelay(0.1f).OnComplete(() => { canvasTout.SetActive(false);});
    }
    public void TransitionIn()
    {
        panelEffectTout.alpha = 0f;
        canvasTout.SetActive(true);
        panelEffectTout.DOFade(1, 0.7f);
        upTout.localPosition = new Vector2(-803, 1614);
        downTout.localPosition = new Vector2(868, -1486);
        upTout.DOAnchorPos(new Vector2(-282, 524), 0.7f).SetDelay(0.1f);
        downTout.DOAnchorPos(new Vector2(175, -547), 0.7f).SetDelay(0.1f).OnComplete(() => { DOTween.KillAll(); Destroy(uiScript.mainScript.map.gameObject); sManager.LoadMission(0); });
    }
    public void OpenMainUI()
    {
        uiScript.canvasMainUI.SetActive(true);
        depot_mui.DOAnchorPos(new Vector2(16, 65), speedMainUI).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasMainUI.SetActive(true); });
        build_mui.DOAnchorPos(new Vector2(325, 145), speedMainUI).SetEase(Ease.OutQuart);
        shop_mui.DOAnchorPos(new Vector2(107, 431), speedMainUI).SetEase(Ease.OutQuart);
        exp_mui.DOAnchorPos(new Vector2(0, 0), speedMainUI).SetEase(Ease.OutQuart);
        tasks_mui.DOAnchorPos(new Vector2(-122, 192), speedMainUI).SetEase(Ease.OutQuart);
        reward_mui.DOAnchorPos(new Vector2(-121, 46), speedMainUI).SetEase(Ease.OutQuart);
        priceList_mui.DOAnchorPos(new Vector2(-97, 270), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOAnchorPos(new Vector2(103, -97), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOLocalRotate(new Vector3(0, 0, -720), speedMainUI).SetEase(Ease.OutQuart);
        timer_mui.DOAnchorPos(new Vector2(289, -77), speedMainUI).SetEase(Ease.OutQuart);
        panelTickets_mui.DOAnchorPos(new Vector2(0, 31), speedMainUI).SetEase(Ease.OutQuart);
        panelMoney_mui.DOAnchorPos(new Vector2(0, -32), speedMainUI).SetEase(Ease.OutQuart);
        if(PlayerPrefs.GetInt("AdDisabled", 0) == 0)
            noad_mui.DOAnchorPos(new Vector2(-50, 530), speedMainUI).SetEase(Ease.OutQuart);
    }
    public void CloseMainMenu()
    {
        depot_mui.DOAnchorPos(new Vector2(-228, 65), speedMainUI).SetEase(Ease.OutQuart);
        build_mui.DOAnchorPos(new Vector2(325, -110), speedMainUI).SetEase(Ease.OutQuart);
        shop_mui.DOAnchorPos(new Vector2(-310, 431), speedMainUI).SetEase(Ease.OutQuart);
        exp_mui.DOAnchorPos(new Vector2(0, -100), speedMainUI).SetEase(Ease.OutQuart);
        tasks_mui.DOAnchorPos(new Vector2(150, 192), speedMainUI).SetEase(Ease.OutQuart);
        reward_mui.DOAnchorPos(new Vector2(140, 46), speedMainUI).SetEase(Ease.OutQuart);
        priceList_mui.DOAnchorPos(new Vector2(250, 270), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOAnchorPos(new Vector2(-80, -97), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOLocalRotate(new Vector3(0, 0, 720), speedMainUI).SetEase(Ease.OutQuart);
        timer_mui.DOAnchorPos(new Vector2(289, 135), speedMainUI).SetEase(Ease.OutQuart);
        panelTickets_mui.DOAnchorPos(new Vector2(500, 31), speedMainUI).SetEase(Ease.OutQuart);
        noad_mui.DOAnchorPos(new Vector2(400, 530), speedMainUI).SetEase(Ease.OutQuart);
        panelMoney_mui.DOAnchorPos(new Vector2(385, -32), speedMainUI).SetEase(Ease.OutQuart).OnComplete(() => 
        {
            if (uiScript.idMenu == 999)
                return;
            uiScript.canvasMainUI.SetActive(false);
        });
    }
    public void OpenBgFB()
    {
        uiScript.canvasBgFB.SetActive(true);
        panel_bgui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasBgFB.SetActive(true); });
        buttonClose_bgui.DOScale(1, speedMainUI * 0.6f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonMoney_bgui.DOScale(0.7f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonTickets_bgui.DOScale(0.7f, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_bgui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void CloseBgFB()
    {
        panel_bgui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu != 999)
                return;
            uiScript.canvasBgFB.SetActive(false);
        });
        buttonClose_bgui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.OutBack);
        buttonMoney_bgui.DOScale(0, speedMainUI * 0.2f).SetEase(Ease.OutBack);
        buttonTickets_bgui.DOScale(0, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        ppanel_bgui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenTown()
    {
        uiScript.canvasTown.SetActive(true);
        panel_townui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasTown.SetActive(true); });
        button_townui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonText_townui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_townui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void UpgradeTown()
    {
        button_townui.localScale = Vector3.zero;
        button_townui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack);
        ppanel_bgui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack);
        ppanel_townui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.0f).OnComplete(() =>
        { ppanel_townui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); ppanel_bgui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); });
    }
    public void CloseTown()
    {
        panel_townui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu == 4)
                return;
            uiScript.canvasTown.SetActive(false);
        });
        button_townui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_townui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenRaw()
    {
        Tutorial.Instance.GetInfo("RawWasOpened");
        uiScript.canvasRaw.SetActive(true);
        panel_rawui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasRaw.SetActive(true); });
        button_rawui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonText_rawui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_rawui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void UpgradeRaw()
    {
        button_rawui.localScale = Vector3.zero;
        button_rawui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack);

        ppanel_bgui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack);
        ppanel_rawui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.0f).OnComplete(() =>
        { ppanel_rawui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); ppanel_bgui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); });
    }
    public void CloseRaw()
    {
        Tutorial.Instance.GetInfo("RawWasClosed");
        panel_rawui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu == 4)
                return;
            uiScript.canvasRaw.SetActive(false);
        });
        button_rawui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_rawui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenTaskMenu()
    {
        Tutorial.Instance.GetInfo("TaskMenuWasOpened");
        uiScript.canvasTaskMenu.SetActive(true);
        panel_taskui.alpha = 0;
        panel_taskui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasTaskMenu.SetActive(true); });
        imageTimer_taskui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        imageTasks_taskui.DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_taskui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        for (int i = 0; i < uiScript.taskSystem.task.Count; i++)
        {
            uiScript.taskSystem.task[i].mask.color = new Color32(255, 255, 255, 0);
            uiScript.taskSystem.task[i].imageTask.GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.InOutBack).SetDelay(speedMainUI * 0.2f); ;
            if (uiScript.taskSystem.task[i].isDone())
            {
                uiScript.taskSystem.task[i].mask.DOColor(new Color32(255, 255, 255, 240), 2f);
                uiScript.taskSystem.task[i].doneImage.GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.InOutBack).SetDelay(speedMainUI * 0.2f); ;
            }
        }
    }
    public void CloseTaskMenu()
    {
        Tutorial.Instance.GetInfo("TaskMenuWasClosed");
        panel_taskui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu != 999)
                return;
            uiScript.canvasTaskMenu.SetActive(false);
        });
        imageTasks_taskui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        imageTimer_taskui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_taskui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        for (int i = 0; i < uiScript.taskSystem.task.Count; i++)
        {
            uiScript.taskSystem.task[i].imageTask.GetComponent<RectTransform>().DOScale(0, Random.Range(0f, 0.3f)).SetEase(Ease.InOutBack);
            if (uiScript.taskSystem.task[i].isDone())
            {
                uiScript.taskSystem.task[i].doneImage.GetComponent<RectTransform>().DOScale(0, Random.Range(0f, 0.3f)).SetEase(Ease.InOutBack);
            }
        }
    }
    public void OpenDepot()
    {
        text_depotui.GetComponent<RectTransform>().localScale = Vector3.zero;
        uiScript.canvasDepot.SetActive(true);
        panel_depotui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasDepot.SetActive(true); });
        button_depotui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonShop_depotui.DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_depotui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        text_depotui.GetComponent<RectTransform>().DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        for (int i = 0; i < uiScript.trainListDepot.Count; i++)
        {
            uiScript.trainListDepot[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.trainListDepot[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        }
    }
    public void SelectTrainDepot()
    {
        imageTrain_depotui.GetComponent<RectTransform>().localScale = Vector3.zero;
        imageTrain_depotui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        button_depotui.localScale = Vector3.zero;
        button_depotui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        for (int i = 0; i < uiScript.wagonDepot.Count; i++)
        {
            uiScript.wagonDepot[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.wagonDepot[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.OutBack);
        }
    }
    public void CloseTrainDepot()
    {
        text_depotui.GetComponent<RectTransform>().localScale = Vector3.zero;
        text_depotui.GetComponent<RectTransform>().DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack);
        imageTrain_depotui.DOScale(0, speedMainUI * 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            if (uiScript.tsScript.tScript != null)
                return;
            imageTrain_depotui.gameObject.SetActive(false);
        });
    }
    public void CloseDepot()
    {
        Tutorial.Instance.GetInfo("DepotWasClosed");
        panel_depotui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnKill(() =>
        {
            if (uiScript.idMenu == 1)
                return;
            uiScript.canvasDepot.SetActive(false);
        });
        button_depotui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        buttonShop_depotui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_depotui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenTrainShop()
    {
        Tutorial.Instance.GetInfo("ShopWasOpened");
        uiScript.canvasTrainShop.SetActive(true);
        panel_tshopui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasTrainShop.SetActive(true); });
        ppanel_tshopui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        for (int i = 0; i < uiScript.trainTrainShop.Count; i++)
        {
            uiScript.buttonBuy[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.buttonBuy[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0.2f, 0.4f)).SetDelay(speedMainUI * 0.3f);
        }
    }
    public void CloseTrainShop()
    {
        Tutorial.Instance.GetInfo("ShopWasClosed");
        panel_tshopui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu == 2)
                return;
            uiScript.canvasTrainShop.SetActive(false);
        });
        ppanel_tshopui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenTrainMenu()
    {
        uiScript.canvasTrainMenu.SetActive(true);
        panel_tmenuui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasTrainMenu.SetActive(true); });
        ppanel_tmenuui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        buttonUpgrade_tmenuui.DOScale(1f, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonSell_tmenuui.DOScale(1f, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.3f);
        buttonRepair_tmenuui.DOScale(1f, speedMainUI * 0.6f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.4f);
        for (int i = 0; i < uiScript.upgradesTrainTrainMenu.Length; i++)
        {
            uiScript.upgradesTrainTrainMenu[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.upgradesTrainTrainMenu[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0, 0.5f)).SetDelay(speedMainUI * 0.2f);
        }
        for (int i = 0; i < uiScript.buyWagonTrainMenu.Length; i++)
        {
            uiScript.buyWagonTrainMenu[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.buyWagonTrainMenu[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0, 0.5f)).SetDelay(speedMainUI * 0.2f);
            uiScript.wagonTrainMenu[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.wagonTrainMenu[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0.2f, 0.4f)).SetDelay(speedMainUI * 0.2f);
        }
    }
    public void CloseTrainMenu()
    {
        Tutorial.Instance.GetInfo("TrainMenuWasClosed");
        buttonUpgrade_tmenuui.localScale = Vector3.zero;
        buttonSell_tmenuui.localScale = Vector3.zero;
        buttonRepair_tmenuui.localScale = Vector3.zero;

        ppanel_tmenuui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        panel_tmenuui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu == 3)
                return;
            uiScript.canvasTrainMenu.SetActive(false);
        });
    }
    public void UpgradeTrain()
    {
        buttonUpgrade_tmenuui.localScale = Vector3.zero;
        buttonUpgrade_tmenuui.DOScale(1f, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);

        ppanel_bgui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack);
        ppanel_tmenuui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.0f).OnComplete(() =>
        { ppanel_tmenuui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); ppanel_bgui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); });
    }
    public void OpenRepairMenu()
    {
        buttonCancel_repui.localScale = Vector3.zero;
        buttonRepair_repui.localScale = Vector3.zero;
        titleText_repui.localScale = Vector3.zero;
        uiScript.canvasRepairTrain.SetActive(true);
        panel_repui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasRepairTrain.SetActive(true); });
        ppanel_repui.DOScale(2.6f, speedMainUI * 0.4f).SetEase(Ease.OutBack);
        buttonCancel_repui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonRepair_repui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        titleText_repui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonRepairText_repui.localScale = new Vector3(1, 1, 1);
    }
    public void CloseRepairMenu()
    {
        uiScript.isRepairMenuOpen = false;
        ppanel_repui.DOScale(0, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        panel_repui.DOFade(0, speedMainUI * 0.3f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.isRepairMenuOpen)
                return;
            uiScript.canvasRepairTrain.SetActive(false);
        });
    }
    public void OpenSellMenu()
    {
        buttonCancel_sellui.localScale = Vector3.zero;
        buttonSell_sellui.localScale = Vector3.zero;
        imageTrain_sellui.localScale = Vector3.zero;
        uiScript.canvasSellTrainMenu.SetActive(true);
        panel_sellui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasSellTrainMenu.SetActive(true); });
        ppanel_sellui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack);
        buttonCancel_sellui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonSell_sellui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        imageTrain_sellui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        sellText_sellui.localScale = new Vector3(1, 1, 1);
        for (int i = 0; i < uiScript.wagonImageSellMenu.Length; i++)
        {
            uiScript.wagonImageSellMenu[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.wagonImageSellMenu[i].GetComponent<RectTransform>().DOScale(0.3f, Random.Range(0.1f, 0.4f)).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        }
    }
    public void CloseSellMenu()
    {
        uiScript.isSellMenuOpen = false;
        ppanel_sellui.DOScale(0, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        panel_sellui.DOFade(0, speedMainUI * 0.3f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.isSellMenuOpen)
                return;
            uiScript.canvasSellTrainMenu.SetActive(false);
        });
    }
    public void OpenWagonMenu()
    {
        Tutorial.Instance.GetInfo("WagonMenuWasOpened");
        buttonCancel_wagui.localScale = Vector3.zero;
        buttonFreight_wagui.localScale = Vector3.zero;
        buttonPassenger_wagui.localScale = Vector3.zero;
        imageFreight_wagui.localScale = Vector3.zero;
        imagePassenger_wagui.localScale = Vector3.zero;
        uiScript.canvasWagonBuy.SetActive(true);
        panel_wagui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasWagonBuy.SetActive(true); });
        ppanel_wagui.DOScale(2.43f, speedMainUI * 0.4f).SetEase(Ease.OutBack);
        buttonCancel_wagui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonFreight_wagui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.3f);
        buttonPassenger_wagui.DOScale(1f, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.4f);
        imageFreight_wagui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        imagePassenger_wagui.DOScale(1f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.3f);
        buttonFreightText_wagui.localScale = new Vector3(1, 1, 1);
        buttonPassengerText_wagui.localScale = new Vector3(1, 1, 1);
    }
    public void CloseWagonMenu()
    {
        uiScript.isWagonBuyMenuOpen = false;
        ppanel_wagui.DOScale(0, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        panel_wagui.DOFade(0, speedMainUI * 0.3f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.isWagonBuyMenuOpen)
                return;
            uiScript.canvasWagonBuy.SetActive(false);
        });
    }
    public void OpenBuildRail()
    {
        uiScript.canvasBuildRail.SetActive(true);
        titleText_brui.localScale = Vector3.zero;
        buttonBuild_brui.localScale = Vector3.zero;
        buttonCancel_brui.localScale = Vector3.zero;
        titleText_brui.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
        buttonBuild_brui.DOScale(1.5f, 0.2f).SetEase(Ease.OutBack);
        buttonCancel_brui.DOScale(1.5f, 0.4f).SetEase(Ease.OutBack);
        buttonBuildText_brui.localScale = new Vector3(1f, 1f, 1f);
    }
    public void CloseBuildRail()
    {
        uiScript.mainScript.isBuildRailOpen = false;
        titleText_brui.DOScale(0f, 0.3f).SetEase(Ease.InOutBack).OnComplete(() =>
        {
            if (uiScript.mainScript.isBuildRailOpen)
                return;
            uiScript.canvasBuildRail.SetActive(false);
        });
        buttonBuild_brui.DOScale(0f, 0.2f).SetEase(Ease.InOutBack);
        buttonCancel_brui.DOScale(0f, 0.2f).SetEase(Ease.InOutBack);
    }
    public void OpenWaySelect()
    {

    }
    public void CloseWaySelect()
    {

    }
    public void RepairTrain()
    {

    }
    public void SellTrain()
    {

    }
    public void BuyWagon()
    {

    }
    public void PriceGrow()
    {
        priceGrow_mui.anchoredPosition = new Vector2(69, -169);
        priceGrow_mui.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        vignette_mui.GetComponent<Image>().color = new Color32(88, 255, 90, 0);
        priceGrow_mui.gameObject.SetActive(true);
        vignette_mui.gameObject.SetActive(true);
        priceGrow_mui.GetComponent<Image>().DOFade(1, 1f);
        vignette_mui.GetComponent<Image>().DOFade(0.7f, 1f);
        priceGrow_mui.DOAnchorPosY(-51, 1f).SetEase(Ease.OutQuad).OnComplete(() => {
            priceGrow_mui.DOAnchorPosY(164, 1f).SetEase(Ease.InQuad).SetDelay(1f);
            vignette_mui.GetComponent<Image>().DOFade(0, 1f).SetDelay(1f);
            priceGrow_mui.GetComponent<Image>().DOFade(0, 1f).SetDelay(1f).OnComplete(() => {
                priceGrow_mui.gameObject.SetActive(false); vignette_mui.gameObject.SetActive(false); });
        });
    }
    public void PriceDecrease()
    {
        priceDecrease_mui.anchoredPosition = new Vector2(69, 166);
        priceDecrease_mui.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        vignette_mui.GetComponent<Image>().color = new Color32(255, 90, 90, 0);
        priceDecrease_mui.gameObject.SetActive(true);
        vignette_mui.gameObject.SetActive(true);
        priceDecrease_mui.GetComponent<Image>().DOFade(1, 1f);
        vignette_mui.GetComponent<Image>().DOFade(0.7f, 1f);
        priceDecrease_mui.DOAnchorPosY(-51, 1f).SetEase(Ease.OutQuad).OnComplete(() => {
            priceDecrease_mui.DOAnchorPosY(-164, 1f).SetEase(Ease.InQuad).SetDelay(1f);
            vignette_mui.GetComponent<Image>().DOFade(0, 1f).SetDelay(1f);
            priceDecrease_mui.GetComponent<Image>().DOFade(0, 1f).SetDelay(1f).OnComplete(() => {
                priceDecrease_mui.gameObject.SetActive(false); vignette_mui.gameObject.SetActive(false); });
        });
    }
    public void PriceUnknown()
    {
        priceUnknown_mui.anchoredPosition = new Vector2(69, -169);
        priceUnknown_mui.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        vignette_mui.GetComponent<Image>().color = new Color32(180, 90, 255, 0);
        priceUnknown_mui.gameObject.SetActive(true);
        vignette_mui.gameObject.SetActive(true);
        priceUnknown_mui.GetComponent<Image>().DOFade(1, 1f);
        vignette_mui.GetComponent<Image>().DOFade(0.7f, 1f);
        priceUnknown_mui.DOAnchorPosY(-51, 1f).SetEase(Ease.OutQuad).OnComplete(() => {
            priceUnknown_mui.DOAnchorPosY(164, 1f).SetEase(Ease.InQuad).SetDelay(1f);
            vignette_mui.GetComponent<Image>().DOFade(0, 1f).SetDelay(1f);
            priceUnknown_mui.GetComponent<Image>().DOFade(0, 1f).SetDelay(1f).OnComplete(() => {
                priceUnknown_mui.gameObject.SetActive(false); vignette_mui.gameObject.SetActive(false); });
        });
    }
    public void OpenPriceList()
    {
        timer_plistui.localScale = Vector3.zero;
        time_plistui.localScale = Vector3.zero;
        graph_plistui.localScale = Vector3.zero;
        uiScript.canvasPriceList.SetActive(true);
        panel_plistui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasPriceList.SetActive(true); });
        buttonAd_plistui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        button_plistui.DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_plistui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        timer_plistui.DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.3f);
        time_plistui.DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        graph_plistui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonText_plistui.localScale = new Vector3(1, 1, 1);
    }
    public void ClosePriceList()
    {
        panel_plistui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu == 5)
                return;
            uiScript.canvasPriceList.SetActive(false);
        });
        button_plistui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        buttonAd_plistui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_plistui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void UpgradePriceList()
    {
        button_plistui.localScale = Vector3.zero;
        button_plistui.DOScale(1f, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);

        ppanel_bgui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack);
        ppanel_plistui.DOScale(1.2f, speedMainUI * 0.2f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.0f).OnComplete(() =>
        { ppanel_plistui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); ppanel_bgui.DOScale(1.5f, speedMainUI * 0.4f).SetEase(Ease.OutBack); buttonText_plistui.localScale = new Vector3(1, 1, 1); });
    }
    public void OpenDonateMenu()
    {
        uiScript.canvasDonate.SetActive(true);
        panel_donateui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasDonate.SetActive(true); });
        ppanel_donateui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        buttonExit_donateui.localScale = Vector3.zero;
        buttonExit_donateui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
        float time = 0.2f;
        foreach (RectTransform button in button_donateui)
        {
            button.localScale = Vector3.zero;
            button.DOScale(1, 0.2f).SetEase(Ease.OutBack).SetDelay(time);
            time += 0.08f;
        }
    }
    public void CloseDonateMenu()
    {
        panel_donateui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu == 8)
                return;
            uiScript.canvasDonate.SetActive(false);
        });
        ppanel_donateui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenConvertMenu()
    {
        uiScript.canvasConvert.SetActive(true);
        panel_convertui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasConvert.SetActive(true); });
        ppanel_convertui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        buttonExit_convertui.localScale = Vector3.zero;
        buttonExit_convertui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
        buttonBuy_convertui.localScale = Vector3.zero;
        buttonBuy_convertui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.2f);
        buttonConvert_convertui.localScale = Vector3.zero;
        buttonConvert_convertui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
        background_convertui.localScale = Vector3.zero;
        background_convertui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.2f);
    }
    public void CloseConvertMenu()
    {
        panel_convertui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu == 9)
                return;
            uiScript.canvasConvert.SetActive(false);
        });
        ppanel_convertui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void Convert()
    {
        panelEffect_convertui.gameObject.SetActive(true);
        panelEffect_convertui.alpha = 0;
        panelEffect_convertui.DOFade(1, 0.2f).OnComplete(() => { panelEffect_convertui.DOFade(0f, 0.7f).OnComplete(() => { panelEffect_convertui.gameObject.SetActive(false); }); });
        effect_convertui.anchoredPosition = new Vector3(0, -1050, 0);
        effect_convertui.DOAnchorPos(new Vector3(-3330, -6228, 0), 1f).SetEase(Ease.InOutSine);
    }
    public void OpenNoMoney()
    {
        uiScript.isNoMoneyOpen = true;
        uiScript.canvasNoMoney.SetActive(true);
        panel_nmui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasNoMoney.SetActive(true); });
        ppanel_nmui.DOScale(2.6f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        buttonOk_nmui.localScale = Vector3.zero;
        buttonOk_nmui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
        buttonBuy_nmui.localScale = Vector3.zero;
        buttonBuy_nmui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.2f);
        buttonAd_nmui.localScale = Vector3.zero;
        buttonAd_nmui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
    }
    public void CloseNoMoney()
    {
        uiScript.isNoMoneyOpen = false;
        panel_nmui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.isNoMoneyOpen)
                return;
            uiScript.canvasNoMoney.SetActive(false);
        });
        ppanel_nmui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenGameOver(bool isSuccess)
    {
        uiScript.CloseMenu();
        if (uiScript.mainScript.isBuildRailOpen)
            CloseBuildRail();
        if (uiScript.mainScript.isSelectWayOpen)
            CloseWaySelect();
        CloseRepairMenu();
        CloseSellMenu();
        CloseWagonMenu();
        CloseNoMoney();
        CloseMainMenu();

        uiScript.canvasGameOver.SetActive(true);
        uiScript.resultGame.GetComponent<RectTransform>().localScale = Vector3.zero;
        uiScript.resultGame.GetComponent<RectTransform>().DOScale(2, 1).SetEase(Ease.OutQuart).SetDelay(0.6f).OnComplete(() => { uiScript.resultGame.GetComponent<RectTransform>().DOScale(1, 1).SetEase(Ease.OutQuart).SetDelay(0.2f); });
        if(isSuccess)
            panel_goui.color = new Color32(110, 255, 255, 0);
        else
            panel_goui.color = new Color32(222, 82, 82, 0);
        ppanel_goui.anchoredPosition = new Vector2(-2000, 0);
        uiScript.mainScript.camRig.GetComponent<CameraController>().enabled = false;
        uiScript.mainScript.isGamePaused = true;
        panel_goui.DOFade(0.8f, speedMainUI * 0.7f).SetEase(Ease.OutQuart).OnComplete(() => { ppanel_goui.DOAnchorPos(new Vector2(0, 0), speedMainUI * 1.5f).SetEase(Ease.OutBack); });
        pppanel_goui.DOScale(1.7f, 0.4f).SetEase(Ease.OutQuart).SetDelay(2.5f).OnComplete(() => { pppanel_goui.DOScale(1.5f, 0.4f).SetEase(Ease.OutQuart); });
        tasks_goui.localScale = Vector3.zero;
        time_goui.localScale = Vector3.zero;
        tasks_goui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(2f);
        time_goui.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(2.3f);


        float times = 2f;

        foreach (RectTransform stat in textStats_goui)
        {
            stat.localScale = Vector3.zero;
            stat.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(times);
            times += 0.4f;
        }

        stats_goui[0].DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(2f);
        stats_goui[1].DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(2.5f);
        stats_goui[2].DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(2.9f);
        stats_goui[3].DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(3.55f);
        foreach (RectTransform stat in stats_goui)
            stat.localScale = Vector3.zero;
        float del = 0.5f;

        foreach (RectTransform button in button_goui)
        {
            button.localScale = Vector3.zero;
            button.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(1.7f + del);
            del += 0.1f;
        }

        for (int i = 0; i < uiScript.mainScript.GetMissionStars(); i++)
            star_goui[i].GetComponent<Image>().sprite = starComplete;

        float time = 2.5f;
        for (int i = 0; i < star_goui.Length; i++)
        {
            star_goui[i].gameObject.SetActive(true);
            star_goui[i].GetComponent<AudioSource>().enabled = false;
            star_goui[i].localScale = Vector3.zero;
            star_goui[i].DOScale(1, 0.4f).SetEase(Ease.OutQuart).SetDelay(time);
            time += 0.3f;
        }
        StartCoroutine(PlayStarsSound(uiScript.mainScript.GetMissionStars()));
    }
    public void CloseGameOver()
    {
            RewardedAdManager.S.RewardType = "";
            RewardedAds.S.ShowAd();
            pppanel_goui.DOScale(0f, 0.8f).SetEase(Ease.OutQuart);
            ppanel_goui.DOAnchorPos(new Vector2(11300, 0), speedMainUI * 1.5f).SetEase(Ease.InQuad).OnComplete(() => { DOTween.KillAll(); sManager.LoadMission(0);});
    }
    public void GoNextMission()
    {
        RewardedAdManager.S.RewardType = "";
        RewardedAds.S.ShowAd();
        if (uiScript.mainScript.taskSystem.IsAllTasksDone())
        {
            pppanel_goui.DOScale(0f, 0.8f).SetEase(Ease.OutQuart);
            if(SceneManager.GetActiveScene().buildIndex != 9)
                ppanel_goui.DOAnchorPos(new Vector2(11300, 0), speedMainUI * 1.5f).SetEase(Ease.InQuad).OnComplete(() => { DOTween.KillAll(); /*Destroy(uiScript.mainScript.map.gameObject)*/; sManager.LoadMission(SceneManager.GetActiveScene().buildIndex+1); });
            else
                ppanel_goui.DOAnchorPos(new Vector2(11300, 0), speedMainUI * 1.5f).SetEase(Ease.InQuad).OnComplete(() => { DOTween.KillAll(); /*Destroy(uiScript.mainScript.map.gameObject)*/; sManager.LoadMission(0); });
        }
    }
    public void OpenWarningExit()
    {
        isWarningExitOpen = true;
        panel_warningExit.gameObject.SetActive(true);
        buttonExit_warningExit.localScale = Vector3.zero;
        buttonNo_warningExit.localScale = Vector3.zero;

        ppanel_warningExit.localScale = Vector3.zero;
        panel_warningExit.alpha = 0;

        panel_warningExit.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { /*uiScript.canvasPause.SetActive(true);*/ });
        buttonExit_warningExit.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonNo_warningExit.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_warningExit.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void CloseWarningExit()
    {
        isWarningExitOpen = false;
        panel_warningExit.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (isWarningExitOpen)
                return;
            panel_warningExit.gameObject.SetActive(false);
        });
        ppanel_warningExit.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenPauseMenu()
    {
        uiScript.canvasPause.SetActive(true);
        buttonResume_pauseui.localScale = Vector3.zero;
        buttonRetry_pauseui.localScale = Vector3.zero;
        buttonSettings_pauseui.localScale = Vector3.zero;
        buttonMenu_pauseui.localScale = Vector3.zero;
        ppanel_pauseui.localScale = Vector3.zero;
        panel_pauseui.alpha = 0;

        panel_pauseui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasPause.SetActive(true); });
        buttonResume_pauseui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonRetry_pauseui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonSettings_pauseui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonMenu_pauseui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_pauseui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void ClosePauseMenu()
    {
        panel_pauseui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.mainScript.isGamePaused)
                return;
            uiScript.canvasPause.SetActive(false);
        });
        ppanel_pauseui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenSettings()
    {
        ClosePauseMenu();
        isSettingsOpen = true;
        uiScript.canvasSettings.SetActive(true);
        buttonReturn_settingsui.localScale = Vector3.zero;
        buttonSound_settingsui.localScale = Vector3.zero;
        buttonMusic_settingsui.localScale = Vector3.zero;
        buttonShadows_settingsui.localScale = Vector3.zero;
        buttonRate_settingsui.localScale = Vector3.zero;
        ppanel_settingsui.localScale = Vector3.zero;
        panel_settingsui.alpha = 0;

        panel_settingsui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasSettings.SetActive(true); });
        buttonReturn_settingsui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonSound_settingsui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonMusic_settingsui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.25f);
        buttonShadows_settingsui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.3f);
        buttonRate_settingsui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.35f);
        ppanel_settingsui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);


        if (AudioManager.Instance.IsSoundOn == 1)
        {
            buttonSound_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonActive;
            buttonSound_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonActiveColor;
            buttonSound_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
        }
        else
        {
            buttonSound_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonInactive;
            buttonSound_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonInactiveColor;
            buttonSound_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
        }


        if (AudioManager.Instance.IsMusicOn == 1)
        {
            buttonMusic_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonActive;
            buttonMusic_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonActiveColor;
            buttonMusic_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
        }
        else
        {
            buttonMusic_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonInactive;
            buttonMusic_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonInactiveColor;
            buttonMusic_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
        }
        if (QalityManager.Instance.IsShadowsOn == 1)
        {
            buttonShadows_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonActive;
            buttonShadows_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonActiveColor;
            buttonShadows_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
        }
        else
        {
            buttonShadows_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonInactive;
            buttonShadows_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonInactiveColor;
            buttonShadows_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
        }
    }
    public void CloseSettings()
    {
        OpenPauseMenu();
        isSettingsOpen = false;
        panel_settingsui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (isSettingsOpen)
                return;
            uiScript.canvasSettings.SetActive(false);
        });
        ppanel_settingsui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void ToggleSound()
    {
        buttonSound_settingsui.localScale = Vector3.zero;
        buttonSound_settingsui.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        AudioManager.Instance.ToggleSound();
        if (AudioManager.Instance.IsSoundOn == 0)
        {
            buttonSound_settingsui.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonSound_settingsui.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonInactiveColor;
            buttonSound_settingsui.GetComponent<Image>().sprite = uiScript.buttonInactive;
        }
        else
        {
            buttonSound_settingsui.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonSound_settingsui.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonActiveColor;
            buttonSound_settingsui.GetComponent<Image>().sprite = uiScript.buttonActive;
        }
    }
    public void ToggleMusic()
    {
        buttonMusic_settingsui.localScale = Vector3.zero;
        buttonMusic_settingsui.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        AudioManager.Instance.ToggleMusic();
        if (AudioManager.Instance.IsMusicOn == 0)
        {
            buttonMusic_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonMusic_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonInactiveColor;
            buttonMusic_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonInactive;
        }
        else
        {
            buttonMusic_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonMusic_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonActiveColor;
            buttonMusic_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonActive;
        }
    }
    public void ToggleShadows()
    {
        buttonShadows_settingsui.localScale = Vector3.zero;
        buttonShadows_settingsui.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        QalityManager.Instance.ToggleShadows();
        if (QalityManager.Instance.IsShadowsOn == 0)
        {
            buttonShadows_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("Off_Settings");
            buttonShadows_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonInactiveColor;
            buttonShadows_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonInactive;
        }
        else
        {
            buttonShadows_settingsui.gameObject.GetComponentInChildren<LocalizeStringEvent>().SetEntry("On_Settings");
            buttonShadows_settingsui.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = uiScript.buttonActiveColor;
            buttonShadows_settingsui.gameObject.GetComponent<Image>().sprite = uiScript.buttonActive;
        }
    }
    public void HideRewardButton()
    {
        reward_mui.gameObject.SetActive(false);
    }
    public void ShowRewardButton()
    {
        reward_mui.gameObject.SetActive(true);
        if (uiScript.idMenu == 0)
        {
            reward_mui.anchoredPosition = new Vector3(400, 46, 0);
            reward_mui.DOAnchorPos(new Vector3(-118, 46, 0), 1f).SetEase(Ease.InOutBack);
        }
    }
    public void RewardedAdWasShowed()
    {
        panel_rewardedAd.GetComponent<CanvasGroup>().alpha = 0;
        canvasRewardedAd.SetActive(true);
        panel_rewardedAd.GetComponent<CanvasGroup>().DOFade(1, 1).SetEase(Ease.OutCubic);
        panel_rewardedAd.GetComponent<CanvasGroup>().DOFade(0, 0.5f).SetEase(Ease.OutCubic).SetDelay(1f).OnComplete(() => {canvasRewardedAd.SetActive(false);});
    }
}
