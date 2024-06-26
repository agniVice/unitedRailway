using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;

public class TownRawScript : MonoBehaviour
{
    public TownInfo townInfo;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
    public TownRawManager trManager;
    public TargetPointer tPointer;
    public Outline outline;
    public RailRoadScript[] road;
    [Space]
    [Header("Train")]
    public GameObject spawnPoint;
    public GameObject[] directionPoint;
    public List<TrainScript> trains;
    [Header("InfoCanvasObjects")]
    public LocalizeStringEvent townNameText;
    public GameObject emptyBar;
    public Image fullBar;
    public Image publicBussinessSprite;
    public Image publicRawSprite;
    public Button openBtn;
    [Space]
    public bool isTown;
    public bool isUnlimitedRaw;
    public int TownNumber;
    public string townName;
    public string businessName;
    public string rawName;
    public string rawType;
    public string productType;
    public Sprite rawSpriteImage;
    public Sprite businessSprite;
    public Sprite rawSprite;
    public float timeForProduct;
    public float timeCurrent = 0;
    public bool isProductReady;
    public bool changeCount;
    private bool isTownRawInfoOpen;
    public bool isCityUnblock;
    public bool isCitySelectWay;
    public bool isCityCanBeSelectWay;
    private IEnumerator MSG;
    private IEnumerator RTP;
    public string lastmsg;

    public float maxStorageProduct;
    public float maxStorageRaw;

    public float[] maxStorageProductNew;
    public float[] maxStorageRawNew;

    public int upgradeLvl;
    public float[] upgradeCost;
    public bool[] isUpgradeTicket;
    public float rawToProduct;
    public float[] newProductFromRaw;
    public float[] newRawToProduct;
    public float[] newTimeForProduct;
    public float productFromRaw;
    public float multiplier;
    public float productCount;
    public float rawCount;
    public float newProduct;
    public float newRaw;
    public int numWay; // 0-start 1-finish
    public bool loadOrUnloadP; //true-load; false-unload;
    public bool loadOrUnloadR; //true-load; false-unload;
    public bool loadOrUnloadPeople; //true-load; false-unload;

    public Sprite currencyMoney;
    public Sprite currencyTicket;
    [Space]
    [Header("Station")]
    public float peopleCount;
    public float newPeople;
    public float maxPeople;
    public float[] maxPeopleNext;
    public float timeForPeople;
    public float[] timeForPeopleNext;
    public float[] peopleForTimeNext;
    public float peopleForTime;
    private bool isPeopleReady;
    public float timeCurrentPeople;
    public Image fullBarPeople;
    public Image emptyBarPeople;

    [Space]
    [Header("RawMenu")]
    public bool isRawReady;
    public bool isSecondStorageOpen;
    public float peopleToRaw;
    public float[] newPeopleToRaw;
    public float timeForRaw;
    public float[] newTimeForRaw;
    public float rawFromPeople;
    public float[] newRawFromPeople;
    public Sprite resourceToRaw;
    public float timeCurrentRaw;
    public int lvlOpenSecondStorage;

    private WaitForSeconds twoSeconds;
    public GameObject TownRawCanvas;
    [Header("Audio")]
    public AudioSource Source;
    public AudioClip TownOpen;
    public AudioClip UpgradeSound;
    public AudioClip OpenTownRawInfoSound;
    void Awake()
    {
        Source = gameObject.GetComponent<AudioSource>();
        AudioManager.Instance.Sounds.Add(Source);
        tPointer = gameObject.GetComponent<TargetPointer>();

        //outline.enabled = true;
        twoSeconds = new WaitForSeconds(2f);
        if (isTown == true)
        {
            productType = townInfo.typeProduct;
            businessName = townInfo.businessName;
            businessSprite = townInfo.businessSprite;
            maxStorageProduct = townInfo.maxStorageProduct;
            maxStorageProductNew = townInfo.maxStorageProductNew;
            productFromRaw = townInfo.productFromRaw;
            newProductFromRaw = townInfo.newProductFromRaw;
            newRawToProduct = townInfo.newRawToProduct;
            newTimeForProduct = townInfo.newTimeForProduct;

            publicBussinessSprite.sprite = businessSprite;

            timeForPeople = townInfo.timeForPeople;
            timeForPeopleNext = townInfo.timeForPeopleNext;
            
            peopleForTime = townInfo.peopleForTime;
            peopleForTimeNext = townInfo.peopleForTimeNext;
        }
        else
        {
            lvlOpenSecondStorage = townInfo.lvlOpenSecondStorage;
            rawSpriteImage = townInfo.rawSpriteImage;
            peopleToRaw = townInfo.peopleToRaw;
            newPeopleToRaw = townInfo.newPeopleToRaw;
            timeForRaw = townInfo.timeForRaw;
            newTimeForRaw = townInfo.newTimeForRaw;
            rawFromPeople = townInfo.rawFromPeople;
            newRawFromPeople = townInfo.newRawFromPeople;
            resourceToRaw = townInfo.resourceToRaw;
        }
        maxPeople = townInfo.maxPeople;
        maxPeopleNext = townInfo.maxPeopleNext;

        upgradeCost = townInfo.upgradeCost;
        isUpgradeTicket = townInfo.isUpggradeTicket;
        townName = townInfo.townName;
        rawName = townInfo.rawName;
        maxStorageRaw = townInfo.maxStorageRaw;
        maxStorageRawNew = townInfo.maxStorageRawNew;
        rawSprite = townInfo.rawSprite;
        rawToProduct = townInfo.rawToProduct;
        timeForProduct = townInfo.timeForProduct;
        multiplier = townInfo.multiplier;
        rawType = townInfo.typeRaw;

        townNameText.SetEntry(townName);
        publicRawSprite.sprite = rawSprite;

    }
    private void Start()
    {
        if (isCityUnblock == true)
        {
            if (isTown)
            {
                CheckProductReady();
                CheckPeopleReady();
            }
            else
            {
                /*if (lvlOpenSecondStorage == upgradeLvl)
                {
                    maxStorageRaw = maxStorageRaw * 2;
                }*/
                    
                CheckRawReady();
            }
                
        }  
    }
    private void FixedUpdate()
    {
        if (!mainScript.isGamePaused)
        {
            if (isCityUnblock == true)
            {
                if (isTown == true)
                {
                    if (loadOrUnloadP == true)
                    {
                        productCount = Mathf.Lerp(productCount, newProduct, Time.fixedDeltaTime * 5f);
                        if (newProduct - productCount < 0.5)
                            productCount = newProduct;
                    }
                    else
                    {
                        productCount = Mathf.Lerp(productCount, newProduct, Time.fixedDeltaTime * 5f);
                        if (productCount - newProduct < 0.5)
                            productCount = newProduct;
                    }
                }
                if (loadOrUnloadR == false)
                {
                    rawCount = Mathf.Lerp(rawCount, newRaw, Time.fixedDeltaTime * 5f);
                    if (rawCount - newRaw < 0.5)
                        rawCount = newRaw;
                }
                else
                {
                    rawCount = Mathf.Lerp(rawCount, newRaw, Time.fixedDeltaTime * 5f);
                    if (newRaw - rawCount < 0.5)
                        rawCount = newRaw;
                }
                if (loadOrUnloadPeople == true)
                {
                    if (peopleCount != newPeople)
                    {
                        peopleCount = Mathf.Lerp(peopleCount, newPeople, Time.fixedDeltaTime * 5f);
                        if (newPeople - peopleCount < 0.5)
                            peopleCount = newPeople;
                        if (isTown)
                            CheckPeople();
                    }
                }
                else
                {
                    if (peopleCount != newPeople)
                    {
                        peopleCount = Mathf.Lerp(peopleCount, newPeople, Time.fixedDeltaTime * 5f);
                        if (peopleCount - newPeople < 0.5)
                            peopleCount = newPeople;
                        if (isTown)
                            CheckPeople();
                    }
                }

                if (isProductReady == true)
                {
                    timeCurrent += Time.fixedDeltaTime;
                    if (timeCurrent > timeForProduct)
                    {
                        if (isTown == true)
                        {
                            ChangeProduct(+productFromRaw);
                            mainScript.taskSystem.GetInfo(this, +productFromRaw, productType);
                            ChangeRaw(-rawToProduct);
                            isProductReady = false;
                            timeCurrent = 0;
                            mainScript.ChangeExp(GetExp());
                            CheckProductReady();
                        }
                    }
                }
                if (isRawReady)
                {
                    timeCurrentRaw += Time.fixedDeltaTime;
                    if (timeCurrentRaw > timeForRaw)
                    {
                        ChangeRaw(rawFromPeople);
                        mainScript.taskSystem.GetInfo(this, rawFromPeople, rawType);
                        ChangePeople(-peopleToRaw);
                        mainScript.ChangeExp(GetExp());
                        isRawReady = false;
                        timeCurrentRaw = 0;
                        CheckRawReady();
                    }
                }
                if (isPeopleReady == true)
                {
                    timeCurrentPeople += Time.fixedDeltaTime;
                    if (timeCurrentPeople > timeForPeople)
                    {
                        ChangePeople(+peopleForTime);
                        mainScript.taskSystem.GetInfo(this, +peopleForTime, "Passenger in " + townName);
                        mainScript.ChangeExp(GetExp());
                        isPeopleReady = false;
                        timeCurrentPeople = 0;
                        CheckPeopleReady();
                    }
                }
            }
        }
    }
    private float GetExp()
    {
        int i = Random.Range(2, 10);
        return i;
    }
    private void Update()
    {
        if (isTownRawInfoOpen == true)
        {
            if (isTown)
            {
                fullBar.fillAmount = timeCurrent / timeForProduct;
                fullBarPeople.fillAmount = timeCurrentPeople / timeForPeople;
            }
            else
            {
                fullBar.fillAmount = timeCurrentRaw / timeForRaw;
            }
            if (mainScript.isGamePaused == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = mainScript.cam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                    RaycastHit _hit;
                    if (Physics.Raycast(ray, out _hit))
                    {
                        if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                        {
                            return;
                        }
                        if (_hit.collider.gameObject.name != gameObject.name)
                        {
                            CloseTownRawInfo();
                        }
                    }
                }
            }
        }
    }
    public void Upgrade()
    {
        if (upgradeLvl <= 3)
        {
            if (isUpgradeTicket[upgradeLvl])
            {
                if (mainScript.pData.CheckValue(upgradeCost[upgradeLvl], true))
                    mainScript.pData.ChangeTickets(this.gameObject, -upgradeCost[upgradeLvl]);
                else
                {
                    uiScript.OpenDonateMenu();
                    return;
                }
            }
            else
            {
                if (mainScript.pData.CheckValue(upgradeCost[upgradeLvl], false))
                    mainScript.pData.ChangeMoney(this.gameObject, -upgradeCost[upgradeLvl]);
                else
                {
                    uiScript.OpenNoMoneyMenu(upgradeCost[upgradeLvl]);
                    return;
                }
            }
            upgradeLvl++;
            if (isTown)
            {
                productFromRaw = newProductFromRaw[upgradeLvl];
                rawToProduct = newRawToProduct[upgradeLvl];
                timeForProduct = newTimeForProduct[upgradeLvl];
                maxStorageProduct = maxStorageProductNew[upgradeLvl];
                maxStorageRaw = maxStorageRawNew[upgradeLvl];
                //Station
                maxPeople = maxPeopleNext[upgradeLvl];
                timeForPeople = timeForPeopleNext[upgradeLvl];
                peopleForTime = peopleForTimeNext[upgradeLvl];

                CheckPeople();
                uiScript.currentTimeForProduct.GetComponent<LocalizeStringEvent>().StringReference.Arguments = new[] { newTimeForProduct[upgradeLvl].ToString() };
                uiScript.currentTimeForProduct.GetComponent<LocalizeStringEvent>().StringReference.RefreshString();
                uiScript.rawToProductText.text = FormatNumsHelper.FormatNum((rawToProduct));
                uiScript.productFromRawText.text = FormatNumsHelper.FormatNum((productFromRaw));
                //Station
                uiScript.maxPeopleCurrent.text = FormatNumsHelper.FormatNum((maxPeople));
                uiScript.currentTimeForPeople.GetComponent<LocalizeStringEvent>().StringReference.Arguments = new[] { timeForPeople.ToString() };
                uiScript.currentTimeForPeople.GetComponent<LocalizeStringEvent>().StringReference.RefreshString();
                uiScript.peopleForTime.text = peopleForTime.ToString();
                if (upgradeLvl > 3)
                {
                    uiScript.upgradeTownCurrency.gameObject.SetActive(false);
                    uiScript.upgradeCostText.gameObject.transform.SetParent(uiScript.centerPosTown.transform);
                    uiScript.upgradeCostText.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                    uiScript.upgradeCostText.GetComponent<LocalizeStringEvent>().SetEntry("MaxLvl");
                    uiScript.upgradeCostText.GetComponent<LocalizeStringEvent>().RefreshString();
                }
                else
                {
                    if (isUpgradeTicket[upgradeLvl])
                        uiScript.upgradeTownCurrency.sprite = uiScript.currencyTickets;
                    else
                        uiScript.upgradeTownCurrency.sprite = uiScript.currencyMoney;
                    uiScript.peopleForTimeNext.text = FormatNumsHelper.FormatNum((peopleForTimeNext[upgradeLvl + 1]));
                    uiScript.newTimeForPeople.GetComponent<LocalizeStringEvent>().StringReference.Arguments = new[] { timeForPeopleNext[upgradeLvl + 1].ToString() };
                    uiScript.newTimeForPeople.GetComponent<LocalizeStringEvent>().StringReference.RefreshString();
                    uiScript.maxPeopleNext.text = FormatNumsHelper.FormatNum(maxPeopleNext[upgradeLvl + 1]);

                    uiScript.nextTimeForProduct.GetComponent<LocalizeStringEvent>().StringReference.Arguments = new[] { newTimeForProduct[upgradeLvl + 1].ToString() };
                    uiScript.nextTimeForProduct.GetComponent<LocalizeStringEvent>().StringReference.RefreshString();
                    uiScript.upgradeCostText.text = FormatNumsHelper.FormatNum(upgradeCost[upgradeLvl]);
                    uiScript.newRawToProductText.text = FormatNumsHelper.FormatNum((newRawToProduct[upgradeLvl + 1]));
                    uiScript.newProductFromRawText.text = FormatNumsHelper.FormatNum((newProductFromRaw[upgradeLvl + 1]));
                }
                uiScript.audioUI.PlaySound(UpgradeSound);
                uiScript.uiTween.UpgradeTown();
            }
            else
            {
                maxStorageRaw = maxStorageRawNew[upgradeLvl];
                if (upgradeLvl == lvlOpenSecondStorage)
                {
                    OpenSecondStorage();
                }
                if (upgradeLvl >= lvlOpenSecondStorage)
                {
                    maxStorageRaw = maxStorageRaw * 2;
                }
                peopleToRaw = newPeopleToRaw[upgradeLvl];
                timeForRaw = newTimeForRaw[upgradeLvl];
                rawFromPeople = newRawFromPeople[upgradeLvl];
                maxPeople = maxPeopleNext[upgradeLvl];
                uiScript.currentRawFromPeople.text = FormatNumsHelper.FormatNum((rawFromPeople));
                uiScript.timeToRawCurrent.GetComponent<LocalizeStringEvent>().StringReference.Arguments = new[] { timeForRaw.ToString() };
                uiScript.timeToRawCurrent.GetComponent<LocalizeStringEvent>().StringReference.RefreshString();
                uiScript.currentPeopleToRaw.text = FormatNumsHelper.FormatNum((peopleToRaw));
                if (upgradeLvl > 3)
                {
                    uiScript.upgradeRawCurrency.gameObject.SetActive(false);
                    uiScript.upgradePriceRaw.gameObject.transform.SetParent(uiScript.centerPosRaw.transform);
                    uiScript.upgradePriceRaw.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                    uiScript.upgradePriceRaw.GetComponent<LocalizeStringEvent>().SetEntry("MaxLvl");
                    uiScript.upgradePriceRaw.GetComponent<LocalizeStringEvent>().RefreshString();
                }   
                else
                {
                    if (isUpgradeTicket[upgradeLvl])
                        uiScript.upgradeRawCurrency.sprite = uiScript.currencyTickets;
                    else
                        uiScript.upgradeRawCurrency.sprite = uiScript.currencyMoney;
                    uiScript.nextRawFromPeople.text = FormatNumsHelper.FormatNum((newRawFromPeople[upgradeLvl+1]));
                    uiScript.timeToRawNext.GetComponent<LocalizeStringEvent>().StringReference.Arguments = new[] { newTimeForRaw[upgradeLvl + 1].ToString() };
                    uiScript.timeToRawNext.GetComponent<LocalizeStringEvent>().StringReference.RefreshString();
                    uiScript.upgradePriceRaw.text = FormatNumsHelper.FormatNum(upgradeCost[upgradeLvl]);   
                    uiScript.nextPeopleToRaw.text = FormatNumsHelper.FormatNum((newPeopleToRaw[upgradeLvl+1]));
                }
                uiScript.audioUI.PlaySound(UpgradeSound);
                uiScript.uiTween.UpgradeRaw();
            }
        }
        if (upgradeLvl >= 4)
            Tutorial.Instance.step = 24;
        Tutorial.Instance.GetInfo("TownRawWasUpgraded");
    }
    public void CheckProductReady()
    {
        if (isCityUnblock == true)
        {
            if (isUnlimitedRaw == true)
                newRaw = maxStorageRaw;
            if (isTown == true)
            {
                if (newRaw >= rawToProduct)
                {
                    if (newProduct < maxStorageProduct && newProduct + productFromRaw <= maxStorageProduct)
                    {
                        isProductReady = true;
                        if (mainScript.isSelectWayOpen == false)
                        {
                            tPointer.Hide();
                            lastmsg = null;
                        }
                    }
                    else
                    {
                        isProductReady = false;
                        StartCoroutine(Msg("StorageFull"));
                        StartCoroutine(WaitCheckProduct());
                    }
                }
                else
                {
                    isProductReady = false;
                    StartCoroutine(Msg("RawIsNotEnough"));
                    StartCoroutine(WaitCheckProduct());
                }
            }
        }

    }
    public void CheckRawReady()
    {
        if (isCityUnblock == false)
            return;
        if (isUnlimitedRaw)
            newPeople = maxPeople;
        if (newPeople >= peopleToRaw)
        {
            if (newRaw + rawFromPeople <= maxStorageRaw)
            {
                isRawReady = true;
                if (mainScript.isSelectWayOpen == false)
                {
                    tPointer.Hide();
                    lastmsg = null;
                }
            }
            else
            {
                isRawReady = false;
                StartCoroutine(Msg("StorageFull"));
                StartCoroutine(WaitCheckRaw());
            }
        }
        else
        {
            isProductReady = false;
            StartCoroutine(Msg("PeopleNotEnough"));
            StartCoroutine(WaitCheckRaw());
        }
    }
    public void CheckPeopleReady()
    {
        if (isCityUnblock == false)
            return;
        if (newPeople + peopleForTime <= maxPeople)
            isPeopleReady = true;
        else
        {
            isPeopleReady = false;
            StartCoroutine(WaitCheckPeople());
        }   
    }
    public void ChangeProduct(float value)
    {
        float nP = newProduct;
        nP += value;
        if (nP > newProduct)
            loadOrUnloadP = true;
        else
            loadOrUnloadP = false;
        newProduct += value;
    }
    public void ChangeRaw(float value)
    {
        float nP = newRaw;
        nP += value;
        if (nP > newRaw)
            loadOrUnloadR = true;
        else
            loadOrUnloadR = false;
        newRaw += value;
    }
    public void ChangePeople(float value)
    {
        float nP = newPeople;
        nP += value;
        if (nP > newPeople)
            loadOrUnloadPeople = true;
        else
            loadOrUnloadPeople = false;
        newPeople += value;
    }
    public void CheckPeople()
    {
        float p = peopleCount / maxPeople;
        float k = uiScript.peopleImageTown.Length;
        float c;
        c = Mathf.RoundToInt(p*k);
        if (mainScript.isTownRawOpened == true)
        {
            if (uiScript.townRawScript == this)
            {
                for (int i = 0; i < uiScript.peopleImageTown.Length; i++)
                    uiScript.peopleImageTown[i].sprite = uiScript.peopleImageTownFullSprite;
                for (int b = 0; b < c; b++)
                    uiScript.peopleImageTown[b].sprite = uiScript.peopleImageTownEmptySprite;
            }
        }
    }
    private void OpenSecondStorage()
    {
        isSecondStorageOpen = true;
        uiScript.emptySecondFullBar.gameObject.SetActive(false);
    }
    private IEnumerator Msg(string msg)
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            //Debug.Log("msg " + this);
            if (lastmsg != msg)
            {
                if (mainScript.isSelectWayOpen == false)
                {
                    lastmsg = msg;
                    tPointer.Hide();
                    if(isTown)
                        tPointer.Spawn(gameObject, msg, true, rawSprite);
                    else
                        tPointer.Spawn(gameObject, msg, true, resourceToRaw);
                }
            }
            yield return null;
        }
    }
    private IEnumerator WaitCheckProduct()
    {
        yield return twoSeconds;
        CheckProductReady();
        yield return null;
    }
    private IEnumerator WaitCheckPeople()
    {
        yield return twoSeconds;
        CheckPeopleReady();
        yield return null;
    }
    private IEnumerator WaitCheckRaw()
    {
        yield return twoSeconds;
        CheckRawReady();
        yield return null;
    }
    public void OnMouseDown()
    {
        if (mainScript.isGamePaused == false)
        {
            if (mainScript.isBuildRailOpen == false)
            {
                if (mainScript.isSelectWayOpen == false)
                {
                    if (uiScript.idMenu == 999)
                    {
                        if (mainScript.isTownRawInfoOpened == false)
                        {
                            if (isTownRawInfoOpen == false)
                            {
                                OpenTownRawInfo();
                                Tutorial.Instance.GetInfo(townName);
                            }
                        }
                    }
                }
                else
                {
                    trManager.CheckClick(this);
                    Tutorial.Instance.GetInfo(townName);
                }
            }
        }
    }
    public void CloseTownRawInfo()
    {
        TownRawCanvas.SetActive(false);
        outline.enabled = false;
        mainScript.isTownRawInfoOpened = false;
        isTownRawInfoOpen = false;
        mainScript.StopCoroutine(mainScript.camToTargetCoroutine);
    }
    public void OpenTownRawInfo()
    {
        mainScript.townRawScript = this;
        isTownRawInfoOpen = true;
        mainScript.isTownRawInfoOpened = true;
        outline.enabled = true;
        outline.OutlineColor = Color.white;
        uiScript.townRawScript = this;
        Source.clip = OpenTownRawInfoSound;
        Source.Play();
        mainScript.camToTargetCoroutine = mainScript.CamToTarget(gameObject, true, mainScript.camController.zoomMin);
        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);

        TownRawCanvas.SetActive(true);
        townNameText.SetEntry(townName);
        publicRawSprite.sprite = rawSprite;
        if (isTown == true)
            publicBussinessSprite.sprite = businessSprite;
    }
}
