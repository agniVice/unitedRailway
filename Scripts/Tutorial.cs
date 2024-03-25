using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private UnityAnalytics uAnalytics;
    [SerializeField] private UserInterfaceScript uiScript;
    [SerializeField] private UITween uiTween;
    public static Tutorial Instance;

    public int IsTutorialComplete;
    public int step;
    [SerializeField] private RectTransform ghostButton;
    [SerializeField] private RectTransform ghostCursor;


    [SerializeField] private Tweener tween1;
    [SerializeField] private Tweener tween2;
    [SerializeField] private Tweener tween3;
    [SerializeField] private Tweener tween4;
    [SerializeField] private Tweener tween5;
    [SerializeField] private Tweener tween6;

    [SerializeField] private GameObject canvasTutorial;
    [SerializeField] private GameObject canvasTutorialClamento;
    [SerializeField] private GameObject canvasTutorialCenester;
    [SerializeField] private GameObject canvasTutorialSodrin;
    [SerializeField] private CanvasGroup panel_1;
    [SerializeField] private CanvasGroup panel_2;
    [SerializeField] private Button button_1;
    [SerializeField] private Button button_2;

    [SerializeField] private Button[] donate_convert;
    [SerializeField] private GameObject panelTip;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            IsTutorialComplete = 0;
            if (PlayerPrefs.HasKey("Tutorial1"))
                IsTutorialComplete = PlayerPrefs.GetInt("Tutorial1");

            if (IsTutorialComplete == 0)
            {
                uiTween.build_mui.gameObject.SetActive(false);
                uiTween.tasks_mui.gameObject.SetActive(false);
                uiTween.depot_mui.gameObject.SetActive(false);
                uiTween.priceList_mui.gameObject.SetActive(false);
                uiTween.reward_mui.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                uiTween.timer_mui.gameObject.SetActive(false);
                uiTween.menu_mui.gameObject.SetActive(false);

                uiTween.buttonClose_bgui.gameObject.SetActive(false);

                uiTween.buttonCancel_wsui.gameObject.SetActive(false);
                uiTween.buttonCancel_brui.gameObject.SetActive(false);
                uiTween.menu_mui.gameObject.SetActive(false);

                donate_convert[0].interactable = false;
                donate_convert[1].interactable = false;
                donate_convert[2].interactable = false;
                donate_convert[3].interactable = false;
                donate_convert[4].gameObject.SetActive(false);
                donate_convert[5].interactable = false;
                donate_convert[6].interactable = false;

                Step1();
            }
            return;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Step1();
        }
        IsTutorialComplete = 1;
        PlayerPrefs.SetInt("Tutorial1", 1);

    }
    private void FixedUpdate()
    {
        if (IsTutorialComplete == 0)
        {
            ghostCursor.anchoredPosition3D = Vector3.zero;
        }
    }
    public void GetInfo(string info)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            switch (info)
            {
                case "BuildWasOpened":
                    if (step == 1)
                    {
                        uAnalytics.OnEventCompleted("buildWasOpened_3");
                        Step2();
                    }
                    break;
                case "RailWasBought":
                    if (step == 2)
                    {
                        if (ghostButton != null)
                            DeleteButton(ghostButton.gameObject);
                        uiTween.build_mui.gameObject.SetActive(true);
                    }
                    break;
            }
        }
        if (IsTutorialComplete == 0)
        {
            switch (info)
            {
                case "BuildWasOpened":
                    if (step == 1)
                    {
                        uAnalytics.OnEventCompleted("buildWasOpened_1");
                        Step2();
                    }
                    if (step == 27)
                    {
                        uAnalytics.OnEventCompleted("buildWasOpened_2");
                        Step2();
                        step = 28;
                    }
                    break;
                case "RailWasBought":
                    if (step == 2)
                    {
                        uAnalytics.OnEventCompleted("railWasBought_1");
                        Step3();
                    }
                    if (step == 28)
                    {
                        uAnalytics.OnEventCompleted("railWasBought_2");
                        Step3();
                        step = 29;
                    }
                    break;
                case "DepotWasOpened":
                    if (step == 3)
                    {
                        uAnalytics.OnEventCompleted("depotWasOpened_1");
                        Step4();
                    }
                    if (step == 16)
                    {
                        uAnalytics.OnEventCompleted("depotWasOpened_2");
                        Step4();
                        step = 17;
                    }
                    if (step == 29)
                    {
                        uAnalytics.OnEventCompleted("depotWasOpened_3");
                        Step4();
                        step = 30;
                    }
                    break;
                case "ShopWasOpened":
                    if (step == 4)
                    {
                        uiScript.buttonBuy[0].GetComponent<Button>().interactable = true;
                        uiScript.buttonBuy[1].SetActive(false);
                        uAnalytics.OnEventCompleted("shopWasOpened_1");
                        Step5();
                    }
                    if (step == 17)
                    {
                        uiScript.buttonBuy[1].SetActive(true);
                        uiScript.buttonBuy[0].GetComponent<Button>().interactable = false;
                        uiScript.buttonBuy[1].GetComponent<Button>().interactable = true;
                        uAnalytics.OnEventCompleted("shopWasOpened_2");
                        Step17();
                    }
                    if (step == 30)
                    {
                        uiScript.buttonBuy[0].GetComponent<Button>().interactable = true;
                        uiScript.buttonBuy[1].GetComponent<Button>().interactable = false;
                        uAnalytics.OnEventCompleted("shopWasOpened_3");
                        Step5();
                        step = 31;
                    }
                    break;
                case "SetWayOpened":
                    if (step == 5)
                    {
                        uAnalytics.OnEventCompleted("setWayOpened_1");
                        Step6();
                    }
                    if (step == 17)
                    {
                        Step6();
                        uAnalytics.OnEventCompleted("setWayOpened_2");
                        step = 17;
                    }
                    if (step == 31)
                    {
                        Step6();
                        uAnalytics.OnEventCompleted("setWayOpened_3");
                        step = 32;
                    }
                    break;
                case "Clamento":
                    {
                        if (step == 6)
                        {
                            uAnalytics.OnEventCompleted("clamento_1");
                            Step6_1();
                        }
                        if (step == 17)
                        {
                            Step6_1();
                            uAnalytics.OnEventCompleted("clamento_2");
                            step = 18;
                        }
                        if (step == 32)
                        {
                            Step6_1_2();
                            uAnalytics.OnEventCompleted("clamento_3");
                            step = 33;
                        }
                        break;
                    }
                case "Sodrin":
                    {
                        if (step == 33)
                        {
                            Step6_2();
                            uAnalytics.OnEventCompleted("sodrin");
                            step = 34;
                        }
                        break;
                    }
                case "Cenester":
                    {
                        if (step == 6)
                        {
                            uAnalytics.OnEventCompleted("cenester_1");
                            Step6_2();
                        }
                        if (step == 21)
                        {
                            uAnalytics.OnEventCompleted("cenester_2");
                            Step13();
                            step = 22;
                        }
                        if (step == 18)
                        {
                            uAnalytics.OnEventCompleted("cenester_3");
                            Step6_2();
                            step = 19;
                        }
                        break;
                    }
                case "WayWasSetted":
                    if (step == 3 || step == 6)
                    {
                        uAnalytics.OnEventCompleted("wayWasSetted_1");
                        Step3();
                        uiScript.mainScript.camToTargetCoroutine = uiScript.mainScript.CamToTarget(uiScript.mainScript.allTowns[0].gameObject, true, uiScript.mainScript.camController.zoomMax);
                        uiScript.mainScript.StartCoroutine(uiScript.mainScript.camToTargetCoroutine);
                        step = 16;
                    }
                    if (step == 19)
                    {
                        uAnalytics.OnEventCompleted("wayWasSetted_2");
                        Step12_1();
                        step = 21;
                    }
                    if (step == 34)
                    {
                        uAnalytics.OnEventCompleted("wayWasSetted_3");
                        CloseTip();
                        step = 35;
                    }
                    break;
                case "TaskMenuWasOpened":
                    if (step == 26)
                    {
                        uAnalytics.OnEventCompleted("taskMenuWasOpened");
                        Step12();
                        step = 27;
                    }
                    break;
                case "TaskMenuWasClosed":
                    if (step == 27)
                    {
                        uAnalytics.OnEventCompleted("taskMenuWasClosed");
                        uiTween.tasks_mui.gameObject.SetActive(false);
                        Step1();
                        step = 27;
                    }
                    break;
                case "RawWasOpened":
                    if (step == 22)
                    {
                        uAnalytics.OnEventCompleted("rawWasOpened");
                        Step14();
                        step = 23;
                    }
                    break;
                case "TownRawWasUpgraded":
                    if (step == 23)
                    {
                        Step14();
                        step = 23;
                    }
                    if (step == 24)
                    {
                        uAnalytics.OnEventCompleted("rawWasUpgraded");
                        Step12();
                        step = 25;
                    }
                    break;
                case "RawWasClosed":
                    if (step == 25)
                    {
                        uAnalytics.OnEventCompleted("rawWasClosed");
                        Step11();
                        step = 26;
                    }
                    break;
            }
        }
    }
    public void Step1()
    {
        uiTween.build_mui.gameObject.SetActive(true);

        if (ghostButton != null)
        DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.build_mui;
        ButtonScaling(ghostButton, new Vector3(0.8f, 0.8f, 0.8f), new Vector3(0.7f, 0.7f, 0.7f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        ghostCursor.anchoredPosition = Vector2.zero;
        step = 1;
    }
    public void Step2()
    {
        uiTween.build_mui.gameObject.SetActive(false);

        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);
        ghostButton = uiTween.buttonBuild_brui;
        ButtonScaling(ghostButton, new Vector3(1.5f, 1.5f, 1.5f), new Vector3(0.7f, 0.7f, 0.7f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 2;
    }
    public void Step3()
    {
        uiTween.depot_mui.gameObject.SetActive(true);

        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.depot_mui;
        ButtonScaling(ghostButton, new Vector3(0.8f, 0.8f, 0.8f), new Vector3(0.7f, 0.7f, 0.7f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 3;
    }
    public void Step4()
    {
        uiTween.depot_mui.gameObject.SetActive(false);
        uiTween.buttonShop_depotui.gameObject.SetActive(true);

        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.buttonShop_depotui;
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.4f, 0.4f, 0.4f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 4;
    }
    public void Step5()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiScript.buttonBuy[0].GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.4f, 0.4f, 0.4f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 5;
    }
    public void Step6()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = canvasTutorialClamento.GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(1.2f, 1.2f, 1.2f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        /*uiScript.mainScript.camToTargetCoroutine = uiScript.mainScript.CamToTarget(uiScript.mainScript.allTowns[0].gameObject, true, uiScript.mainScript.camController.zoomMax);
        uiScript.mainScript.StartCoroutine(uiScript.mainScript.camToTargetCoroutine);*/
        step = 6;
    }
    public void Step6_1()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = canvasTutorialCenester.GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(1.2f, 1.2f, 1.2f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        uiScript.mainScript.StopCoroutine(uiScript.mainScript.camToTargetCoroutine);
        uiScript.mainScript.camToTargetCoroutine = uiScript.mainScript.CamToTarget(uiScript.mainScript.allTowns[2].gameObject, true, uiScript.mainScript.camController.zoomMax);
        uiScript.mainScript.StartCoroutine(uiScript.mainScript.camToTargetCoroutine);

        step = 6;
    }
    public void Step6_1_2()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = canvasTutorialSodrin.GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(1.2f, 1.2f, 1.2f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        uiScript.mainScript.StopCoroutine(uiScript.mainScript.camToTargetCoroutine);
        uiScript.mainScript.camToTargetCoroutine = uiScript.mainScript.CamToTarget(uiScript.mainScript.allTowns[1].gameObject, true, uiScript.mainScript.camController.zoomMax);
        uiScript.mainScript.StartCoroutine(uiScript.mainScript.camToTargetCoroutine);

        step = 6;
    }
    public void Step6_2()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiScript.goSelectWay.GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1.5f, 1.5f, 1.5f), new Vector3(0.7f, 0.7f, 0.7f));
        ghostCursor.transform.SetParent(ghostButton.transform);

        step = 6;
    }
    public void Step7()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiScript.buyWagonTrainMenu[3].GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.6f, 0.6f, 0.6f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 7;
    }
    public void Step8()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.buttonFreight_wagui;
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.3f, 0.3f, 0.3f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 8;
    }
    public void Step9()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.buttonUpgrade_tmenuui;
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.7f, 0.7f, 0.7f));
        ghostCursor.transform.SetParent(ghostButton.transform);
    }
    public void Step10()
    {
        uiTween.buttonClose_bgui.gameObject.SetActive(true);
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.buttonClose_bgui;
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.5f, 0.5f, 0.5f));
        ghostCursor.transform.SetParent(ghostButton.transform);
    }
    public void Step11()
    {
        uiTween.depot_mui.gameObject.SetActive(false);
        uiTween.tasks_mui.gameObject.SetActive(true);
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.tasks_mui;
        ButtonScaling(ghostButton, new Vector3(0.8f, 0.8f, 0.8f), new Vector3(0.7f, 0.7f, 0.7f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 11;
    }
    public void Step12()
    {
        uiTween.buttonClose_bgui.gameObject.SetActive(true);
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);
        ghostButton = uiTween.buttonClose_bgui;
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.5f, 0.5f, 0.5f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 12;
    }
    public void Step12_1()
    {
        uiTween.buttonClose_bgui.gameObject.SetActive(false);
        uiTween.tasks_mui.gameObject.SetActive(false);
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        uiScript.mainScript.camToTargetCoroutine = uiScript.mainScript.CamToTarget(canvasTutorialCenester.GetComponentInParent<TownRawScript>().gameObject, true, uiScript.mainScript.camController.zoomMin);
        uiScript.mainScript.StartCoroutine(uiScript.mainScript.camToTargetCoroutine);
        ghostButton = canvasTutorialCenester.GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.4f, 0.4f, 0.4f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 12;
    }
    public void Step13()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        uiScript.mainScript.allTowns[2].OpenTownRawInfo();
        ghostButton = uiScript.mainScript.allTowns[2].openBtn.GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.4f, 0.4f, 0.4f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 13;
    }
    public void Step14()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiTween.button_rawui;
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.4f, 0.4f, 0.4f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 14;
    }
    public void Step15()
    {
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        uiTween.CloseMainMenu();
        uiScript.mainScript.isGamePaused = true;
        uiScript.mainScript.camRig.GetComponent<CameraController>().enabled = false;
        IsTutorialComplete = 1;
        PlayerPrefs.SetInt("Tutorial1", 1);
        canvasTutorial.SetActive(true);
        panel_1.gameObject.SetActive(true);
        panel_1.alpha = 0;
        panel_1.DOFade(1, 0.6f);
        button_1.GetComponent<RectTransform>().localScale = Vector3.zero;
        button_1.GetComponentInChildren<TextMeshProUGUI>().gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button_1.GetComponent<RectTransform>().DOScale(1, 0.3f).SetDelay(1f).SetEase(Ease.OutBack);
    }
    public void Step16()
    {
        panel_1.gameObject.SetActive(false);
        panel_2.gameObject.SetActive(true);
        panel_2.alpha = 0;
        panel_2.DOFade(1, 0.6f);
        button_2.GetComponent<RectTransform>().localScale = Vector3.zero;
        button_2.GetComponentInChildren<TextMeshProUGUI>().gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button_2.GetComponent<RectTransform>().DOScale(1, 0.3f).SetDelay(1f).SetEase(Ease.OutBack);
    }
    public void Step17()
    {
        /*uiTween.CloseMainMenu();
        uAnalytics.OnEventCompleted("tutorial_1_completed");

        panelTip.transform.localScale = Vector3.zero;
        panelTip.gameObject.SetActive(true);
        panelTip.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.4f);*/
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);

        ghostButton = uiScript.buttonBuy[1].GetComponent<RectTransform>();
        ButtonScaling(ghostButton, new Vector3(1, 1, 1), new Vector3(0.4f, 0.4f, 0.4f));
        ghostCursor.transform.SetParent(ghostButton.transform);
        step = 17;
    }
    
    public void CloseTip()
    {
        uiScript.buttonBuy[0].GetComponent<Button>().interactable = true;
        uiScript.buttonBuy[1].GetComponent<Button>().interactable = true;
        if (ghostButton != null)
            DeleteButton(ghostButton.gameObject);
        IsTutorialComplete = 1;
        PlayerPrefs.SetInt("Tutorial1", 1);
        donate_convert[0].interactable = true;
        donate_convert[1].interactable = true;
        donate_convert[2].interactable = true;
        donate_convert[3].interactable = true;
        donate_convert[4].gameObject.SetActive(true);
        donate_convert[5].interactable = true;
        donate_convert[6].interactable = true;

        uiTween.build_mui.gameObject.SetActive(true);
        uiTween.tasks_mui.gameObject.SetActive(true);
        uiTween.depot_mui.gameObject.SetActive(true);
        uiTween.priceList_mui.gameObject.SetActive(true);
        uiTween.reward_mui.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        uiTween.timer_mui.gameObject.SetActive(true);
        uiTween.menu_mui.gameObject.SetActive(true);

        uiTween.buttonClose_bgui.gameObject.SetActive(true);

        uiTween.buttonCancel_wsui.gameObject.SetActive(true);
        uiTween.buttonCancel_brui.gameObject.SetActive(true);
        uiTween.menu_mui.gameObject.SetActive(true);
        uiScript.mainScript.camRig.GetComponent<CameraController>().enabled = true;
        uiScript.mainScript.isGamePaused = false;
        uiScript.mainScript.camToTargetCoroutine = uiScript.mainScript.CamToTarget(uiScript.mainScript.allTowns[0].gameObject, true, uiScript.mainScript.camController.zoomMax);
        uiScript.mainScript.StartCoroutine(uiScript.mainScript.camToTargetCoroutine);
        panelTip.transform.DOScale(Vector3.zero, 0.4f).OnComplete(() => { panelTip.SetActive(false); });
        canvasTutorial.SetActive(false);
        uiTween.OpenMainUI();
    }
    public void DeleteButton(GameObject button)
    {
        ghostCursor.transform.SetParent(gameObject.transform);

        if (tween1 != null)
            tween1.Kill();
        if (tween2 != null)
            tween2.Kill();
        if (tween3 != null)
            tween3.Kill();
        if (tween4 != null)
            tween4.Kill();

        ghostButton = null;
    }
    public void ButtonScaling(RectTransform button, Vector3 scale, Vector3 scaleCursor)
    {
        tween1 = button.DOScale(scale, 0.6f).SetEase(Ease.OutBack).OnKill(() => { button.localScale = scale; });
        tween1.SetAutoKill(false);
        ghostCursor.localScale = Vector3.zero;

        tween2 = ghostCursor.DOScale(scaleCursor, 0.8f).OnComplete(() =>
        {
            tween3 = ghostCursor.DOScale(new Vector3(0, 0, 0), 0.2f);
            tween3.SetAutoKill(false);
            tween4 = button.DOScale(scale*1.2f, 0.7f).OnKill(() => { button.localScale = scale; }).OnComplete(() => { ButtonScaling(button, scale, scaleCursor); });
            tween4.SetAutoKill(false);
        });
        tween2.SetAutoKill(false);
    }
    public void CursorScaling(Vector3 scaleCursor)
    {
        ghostCursor.localScale = Vector3.zero;
        tween2 = ghostCursor.DOScale(scaleCursor, 0.8f).OnComplete(() =>
        {
            tween3 = ghostCursor.DOScale(new Vector3(0, 0, 0), 0.2f).OnComplete(() => { CursorScaling(scaleCursor); }); ;
            tween3.SetAutoKill(false);
        });
        tween2.SetAutoKill(false);
    }
}
