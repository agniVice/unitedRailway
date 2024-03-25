using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Localization.Components;
public class TrainScript : MonoBehaviour
{
    [Header("Links")]
    public TasksSystemScript taskSystem;
    public TrainSystemScript tsScript;
    public UserInterfaceScript uiScript;
    public TrainInfo tInfo;
    public ShowCargoInfo scInfo;
    public TargetPointer tPointer;
    [SerializeField] ParticleSystem particleBroke;
    [SerializeField] Outline outline;
    private string lastmsg;
    [Space]
    [Header("Wagons")]
    public GameObject touchPlace;
    public GameObject dir;
    public List<WagonScript> wagon;
    public List<WagonScript> wagonsLoad;
    public GameObject[] placeForWagon;
    public float totalCargoPrice;
    public float wagonsLoadingSpeed;
    public bool isWagonsLoad;
    public bool isWagonsUnload;
    [Space]
    [Header("Settings Train")]
    public string trainName;
    public float maxSpeed;
    public float speed;
    public float maxHealth;
    public float health;
    public string typeTrain;
    public string subNameTrain;
    public float repairCost;
    public float priceTrain;
    public bool isTicketCost;
    public float newRepair;
    public Color newRepairColor;
    public float chanceBroke;
    public bool iBroke;
    public float breakSpeed;
    private IEnumerator lerpcoroutine;
    public float sellPrice;
    public float sellExtraPrice;
    public int trainId;
    [Space]
    [Header("Upgrade")]
    public TrainUpgradeInfo[] tUpgrade;
    public int upgradeLvl;
    public bool isUpgradeTicket;
    public float wagonSizeRatio;
    [Space]
    public bool isTrainSelectDepot;

    public Color colorHealth;
    public Color colorTypeTrain;
    [Space]
    [Header("Way")]
    public List<TownRawScript> way;
    public TownRawScript placeWhereIAm;
    public TownRawScript placeWhereIAmGoing;
    public RailRoadScript road;
    [SerializeField] private int target;
    public bool canIMove;
    public bool displace;
    private Vector3 displacePosition;
    private float elapsedTime;
    private float timer = 15f;
    
    private string directionMovement;
    private Quaternion lookOnLook;


    private bool isSpeedDecrease;
    //public bool isTrainSelected;
    [Space]
    [Header("UI")]
    public Sprite trainSprite;
    public Sprite[] wagonSprite;

    public GameObject pref;
    public GameObject mask;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxHealthText;
    public TextMeshProUGUI trainNameText;

    [SerializeField] private RectTransform canvas;
    [SerializeField] private RectTransform money;
    [SerializeField] private RectTransform tickets;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI ticketsText;
    [SerializeField] private GameObject panelButton;

    [Header("Audio")]
    public AudioSource Source;
    public AudioSource MovementSource;
    public AudioSource OtherSource;
    public AudioClip Starting;
    public AudioClip UpgradeSound;
    public AudioClip WagonSound;

    ////////////////////////////////---------[GENERAL]-------//////////////////////////////////////////
    private void Awake()
    {
        AudioManager.Instance.Sounds.Add(Source);
        AudioManager.Instance.Sounds.Add(MovementSource);
        AudioManager.Instance.Sounds.Add(OtherSource);
        AudioManager.Instance.Init();
        //scInfo = GetComponentInChildren<ShowCargoInfo>();
        tPointer = gameObject.GetComponent<TargetPointer>();
        tsScript = FindObjectOfType<TrainSystemScript>();
        uiScript = tsScript.uiScript;
        taskSystem = uiScript.mainScript.taskSystem;
        trainName = tInfo.trainName;
        trainSprite = tInfo.spriteTrain;
        maxSpeed = tInfo.maxSpeed;
        maxHealth = tInfo.maxHealth;
        health = maxHealth;
        typeTrain = tInfo.typeTrain;
        priceTrain = tInfo.priceTrain;
        chanceBroke = tInfo.chanceBroke;
        wagonsLoadingSpeed = tInfo.loadingSpeed;
        isTicketCost = tInfo.isTicketCost;
        CheckType();
    }
    private void Update()
    {
        /*if (isTrainSelected)
        {
            uiScript.mainScript.camController.newPosition = Vector3.Lerp(uiScript.mainScript.camController.newPosition, gameObject.transform.position, 3f * Time.deltaTime);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = uiScript.mainScript.cam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                RaycastHit _hit;
                if (Physics.Raycast(ray, out _hit))
                {
                    //if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                    //return;
                    if (_hit.collider != gameObject.GetComponent<Collider>())
                        UnselectTrain();
                }
            }
        }*/
        if (!uiScript.mainScript.isGamePaused)
        {
            if (displace == true)
            {
                elapsedTime += Time.deltaTime;
                float perc = elapsedTime / timer;
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, displacePosition, Mathf.SmoothStep(0, 1, perc));
                if (Vector3.Distance(gameObject.transform.position, displacePosition) <= 0.01f)
                {
                    elapsedTime = 0;
                    SpawnWagons();
                    if (wagonsLoad.Count > 0)
                    {
                        Source.clip = WagonSound;
                        Source.Play();
                    }
                    displace = false;
                    gameObject.transform.position = displacePosition;
                }
            }
            MovementSource.pitch = speed / maxSpeed + 0.35f;
            if (MovementSource.pitch <= 0.75f)
            {
                MovementSource.pitch = 0.73f;
                return;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!uiScript.mainScript.isGamePaused)
        {
            if (canIMove == false || iBroke == true)
                return;//Если движение запрещено, возвращаем метод
            float distance = Vector3.Distance(gameObject.transform.position, placeWhereIAmGoing.spawnPoint.transform.position);
            float time = distance / ((speed / 10 * Time.fixedDeltaTime)*50);

            Vector3 dir = placeWhereIAmGoing.spawnPoint.transform.position - transform.position;
            Vector3 forw = transform.forward;
            float angleBetween = Vector3.SignedAngle(dir, forw, Vector3.up);

            if (time <= 3)
            {
                if (angleBetween < 15 && angleBetween > -15)
                {
                    float timeNew = distance / (((speed / 1.55f) / 10 * Time.fixedDeltaTime) * 50);
                    if (timeNew <= 3)
                    {
                        if (!isSpeedDecrease)
                        {
                            isSpeedDecrease = true;
                            if (lerpcoroutine != null)
                                StopCoroutine(lerpcoroutine);
                            lerpcoroutine = LerpSpeed(speed, 1f, time + 1.7f);
                            StartCoroutine(lerpcoroutine);
                        }
                    }
                }
            }
            if (target <= road.point.Count)//Если меток меньше или равно количеству всех меток на пути
            {
                if (directionMovement == "Forward")//Если движение вперед
                {
                    if (target == road.point.Count)//Если цель это последняя точки
                    {
                        lookOnLook = Quaternion.LookRotation(placeWhereIAmGoing.spawnPoint.transform.position - gameObject.transform.position);
                        if (Vector3.Distance(gameObject.transform.position, placeWhereIAmGoing.spawnPoint.transform.position) <= 0.05f)//Если мы близко к метке назначения
                        {
                            canIMove = false;//Запрещаем движение
                            speed = 0;//Скорость = 0
                            UnloadWagons();//Выгружаем вагоны
                        }
                    }
                    if (target < road.point.Count)//Если метка меньше чем количество всех меток
                        lookOnLook = Quaternion.LookRotation(road.point[target].transform.position - gameObject.transform.position); //поварачивем поезд
                }
                else if (directionMovement == "Backward")//Если движение назад
                {
                    if (target == -1)//Если цель это последняя метка
                    {
                        lookOnLook = Quaternion.LookRotation(placeWhereIAmGoing.spawnPoint.transform.position - gameObject.transform.position);
                        if (Vector3.Distance(gameObject.transform.position, placeWhereIAmGoing.spawnPoint.transform.position) <= 0.05f)//Если мы близко к метке назначения
                        {
                            canIMove = false;//Запрещаем движение
                            speed = 0;//Скорость = 0
                            UnloadWagons();//Выгружаем вагоны
                        }

                    }
                    if (target >= 0)//Если метка больше чем 0
                        lookOnLook = Quaternion.LookRotation(road.point[target].transform.position - gameObject.transform.position);//поварачивем поезд
                }
                gameObject.transform.position += transform.forward * (speed / 10) * Time.fixedDeltaTime;//Задаем движение вперед
                gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, (speed / 3) * Time.fixedDeltaTime);//Плавный поворот поезда
            }
        }
    }
    public void Spawn()
    {
        if (placeWhereIAm == null)// Если мы только купили поезд
            placeWhereIAm = way[0];

        isSpeedDecrease = false;
        canIMove = false;//Запрещаем движение
        for (int i = 0; i < wagon.Count; i++)
        {
            wagon[i].spriteCargo = null;
        }
        //Спавним поезд в точке SpawnPoint города в котором поезд находится
        gameObject.transform.SetParent(placeWhereIAm.gameObject.transform);
        gameObject.transform.position = placeWhereIAm.spawnPoint.transform.position;
        gameObject.transform.SetParent(tsScript.gameObject.transform);
        CheckPlace();//Узнать где поезд находится и куда будет ехать
        CheckDirection();//Узнать в какую сторону нужно двигаться
        StartCoroutine(CheckWagons()); //Проверяем есть ли вагоны
    }
    ////////////////////////////////---------[MOVEMENT]-------//////////////////////////////////////////
    private IEnumerator Displace()
    {
        if (!uiScript.mainScript.isGamePaused)
        {
            if (wagonsLoad.Count != 0)
                displacePosition = gameObject.transform.position + gameObject.transform.forward * wagonsLoad[0].bounds.size.z * wagonsLoad.Count;
            else
                displacePosition = gameObject.transform.position;
            displace = true;
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(Displace());
        }
    }
    private void Move()
    {
        MovementSource.pitch = 0.4f;
        MovementSource.Play();
        speed = 0;//Скорость = 0
        for (int b = 0; b<wagon.Count; b++)
        {
            //wagon[b].GetWagonNumber();//Узнаем номер вагона в списке
        }
        canIMove = true;//Разрешаем движение
        Source.clip = Starting;
        Source.Play();
        if(lerpcoroutine != null)
            StopCoroutine(lerpcoroutine);
        lerpcoroutine = LerpSpeed(0, maxSpeed, 1f);
        StartCoroutine(lerpcoroutine);
    }
    private void CheckPlace()
    {
        for (int i = 0; i < road.townraw.Count; i++)
        {
            if (road.townraw[i] != placeWhereIAm)
            {
                placeWhereIAmGoing = road.townraw[i];
                placeWhereIAmGoing.trains.Add(this);
            }
        }
    }
    private void CheckDirection()
    {
        float dist1 = Vector3.Distance(road.camObject.transform.position, placeWhereIAm.directionPoint[0].transform.position);
        float dist2 = Vector3.Distance(road.camObject.transform.position, placeWhereIAm.directionPoint[1].transform.position);
        if (dist1 < dist2)
            gameObject.transform.forward = placeWhereIAm.directionPoint[0].transform.forward;
        else
            gameObject.transform.forward = placeWhereIAm.directionPoint[1].transform.forward;

        if (placeWhereIAmGoing == road.townraw[0])//road.townraw[0] это всегда то место откуда начинаются метки на пути
        {
            target = road.point.Count - 1;//назначаем начальную метку движения
            directionMovement = "Backward";//назначаем куда будет двигаться поезд относительно меткам
        }
        else if (placeWhereIAmGoing == road.townraw[1])//road.townraw[1] это всегда то место где заканчиваются метки на пути
        {
            target = 0;//назначаем начальную метку движения
            directionMovement = "Forward";//назначаем куда будет двигаться поезд относительно меткам
        }
    }
    private IEnumerator LerpSpeed(float currentSpeed, float afterSpeed, float time)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
                speed = Mathf.Lerp(currentSpeed, afterSpeed, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
        }

    }
    ////////////////////////////////---------[WAGONS]-------//////////////////////////////////////////
    private IEnumerator CheckWagons()
    {
        if (!uiScript.mainScript.isGamePaused)
        {
            if (canIMove == false)//Если движение запрещено, тоесть поезд стоит на станции
            {
                if (wagon.Count > 0)// Если вагонов больше чем 0
                {
                    tPointer.Hide();//Прячем индикатор
                    lastmsg = null;
                    LoadWagons();
                    yield return null;
                }
                else
                {
                    if (uiScript.mainScript.isTownRawInfoOpened == false)//Если информация о городе закрыта
                    {
                        if (uiScript.mainScript.isSelectWayOpen == false)//Если выбор маршута закрыт
                        {
                            if (uiScript.idMenu == 999)//Если ид меню = 999, тоесть все меню закрыты
                            {
                                if (tPointer.PointerUI == null)
                                    Msg("NoWagons");
                            }
                        }
                    }
                    yield return new WaitForSeconds(2f);//Ждём 2 секунды
                    StartCoroutine(CheckWagons());//Вызываем корутину опять
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(CheckWagons());
        }
    }
    public void BuyWagon(int typeWagon)
    {
        if (wagon.Count == 0)//Если вагонов было = 0
            tPointer.Hide();//Выключаем индикатор
        var Wagon = Instantiate(tsScript.wagonPref[typeWagon], gameObject.transform);//Создаем вагон
        Wagon.train = this;//Даем вагону знать кто такой train
        wagon.Add(Wagon.GetComponent<WagonScript>());//Добавляем вагон в список вагонов
        Wagon.GetWagonNumber();
        uiScript.buyWagonTrainMenu[Wagon.wagonNum].gameObject.SetActive(false);
        uiScript.wagonTrainMenu[Wagon.wagonNum].gameObject.SetActive(true);
        uiScript.wagonCargoSprite[Wagon.wagonNum].sprite = Wagon.emptySpriteCargo;
        if (typeWagon == 1)
            uiScript.wagonCargoSprite[Wagon.wagonNum].sprite = Wagon.passengersSprite;
        uiScript.wagonTrainMenu[Wagon.wagonNum].sprite = Wagon.wagonSprite;
        Wagon.Hide();//Прячем вагон
        Wagon = null;//Очищаем var
    }
    private void UnloadWagons()
    {
        speed = 0;
        if (wagonsLoad.Count != 0)
        {
            for (int i = 0; i < wagonsLoad.Count; i++)
            {
                wagonsLoad[i].Unload();
            }
        }
        else
            IsWagonsUnload();
    }
    private void LoadWagons()
    {
        float prodraw;//placeWhereIAm.newRaw or placeWhereIAm.newProduct
        float prodraw2;//placeWhereIAmGoing.newRaw
        float prodraw3 = placeWhereIAm.newPeople; ;//placeWhereIAm.newPeople;
        float prodraw4 = placeWhereIAmGoing.newPeople; ;//placeWhereIAmGoing.newPeople;
        if (placeWhereIAm.isTown)
        {
            prodraw = placeWhereIAm.newProduct;
            prodraw2 = placeWhereIAmGoing.newRaw;
            if (typeTrain != "Freight Only!")
            {
                if (placeWhereIAmGoing.isTown == false)
                {
                    for (int k = 0; k < placeWhereIAmGoing.trains.Count; k++)
                    {
                        for (int l = 0; l < placeWhereIAmGoing.trains[k].wagonsLoad.Count; l++)
                        {
                            if (placeWhereIAmGoing.trains[k].wagonsLoad[l].typeOfWagon == "Passenger")
                                prodraw4 += placeWhereIAmGoing.trains[k].wagon[l].newLoadWeight;
                        }
                    }
                }
            }
        }
        else
        {
            prodraw = placeWhereIAm.newRaw;
            prodraw2 = placeWhereIAmGoing.newRaw;
            if(typeTrain != "Pass Only!")
            {
                if (placeWhereIAmGoing.isTown)
                {
                    for (int w = 0; w < placeWhereIAmGoing.trains.Count; w++)
                    {
                        for (int o = 0; o < placeWhereIAmGoing.trains[w].wagonsLoad.Count; o++)
                        {
                            if (placeWhereIAmGoing.trains[w].wagonsLoad[o].typeOfWeight == placeWhereIAmGoing.rawType)
                                prodraw2 += placeWhereIAmGoing.trains[w].wagon[o].newLoadWeight;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < wagon.Count; i++)
        {
            wagon[i].CheckLoadWeight();
            if (wagon[i].typeOfWagon == "Freight")//Freight
            {
                if (placeWhereIAmGoing.isTown == true)
                {
                    if (placeWhereIAm.isTown)
                    {
                        if (prodraw >= wagon[i].maxLoadWeight)
                        {
                            wagonsLoad.Add(wagon[i]);
                            placeWhereIAm.newProduct -= wagon[i].maxLoadWeight;
                            prodraw -= wagon[i].maxLoadWeight;
                        }
                    }
                    else
                    {
                        if (prodraw >= wagon[i].maxLoadWeight)
                        {
                            prodraw2 += wagon[i].maxLoadWeight;
                            if (prodraw2 <= placeWhereIAmGoing.maxStorageRaw)
                            {
                                prodraw -= wagon[i].maxLoadWeight;
                                placeWhereIAm.newRaw -= wagon[i].maxLoadWeight;
                                wagonsLoad.Add(wagon[i]);
                            }
                            else
                                prodraw2 -= wagon[i].maxLoadWeight;      
                        }
                    }
                }

            }
            else//Passenger
            {
                if (placeWhereIAm.isTown == true)
                {
                    if (prodraw3 >= wagon[i].maxLoadWeight)
                    {
                        if (placeWhereIAmGoing.isTown == false)
                        {
                            prodraw4 += wagon[i].maxLoadWeight;
                            if (prodraw4 <= placeWhereIAmGoing.maxPeople)
                            {
                                wagonsLoad.Add(wagon[i]);
                                placeWhereIAm.newPeople -= wagon[i].maxLoadWeight;
                                prodraw3 -= wagon[i].maxLoadWeight;
                            }
                        }
                        else
                        {
                            wagonsLoad.Add(wagon[i]);
                            placeWhereIAm.newPeople -= wagon[i].maxLoadWeight;
                            prodraw3 -= wagon[i].maxLoadWeight;
                        }
                    }
                }
            }
        }
        StartCoroutine(Displace());
    }
    private void SpawnWagons()
    {
        isSpeedDecrease = false;
        if (wagonsLoad.Count != 0)
        {
            for (int b = 0; b < wagonsLoad.Count; b++)
            {
                wagonsLoad[b].Spawn();
                wagonsLoad[b].Load();
            }
        }
        else
            IsWagonsLoad();
    }
    public void IsWagonsLoad()
    {
        isWagonsLoad = true;
        for (int i = 0; i < wagonsLoad.Count; i++)
        {
            if (wagonsLoad[i].isLoaded == false)
                isWagonsLoad = false;
        }
        if (isWagonsLoad == true)
            Move();
    }
    public void IsWagonsUnload()
    {
        isWagonsLoad = false;
        isWagonsUnload = true;
        for (int i = 0; i < wagonsLoad.Count; i++)
        {
            if (wagonsLoad[i].isUnloaded == false)
                isWagonsUnload = false;
        }
        if (isWagonsUnload == true)
        {
            ShowPrice();
            int c = wagonsLoad.Count;
            for (int b = 0; b < c; b++)
            {
                wagonsLoad.Remove(wagonsLoad[0]);
            }
            placeWhereIAmGoing.trains.Remove(this);
            totalCargoPrice = 0;
            Spawn();
        }
    }
    ////////////////////////////////---------[OTHER]-------//////////////////////////////////////////
    /*public void SelectTrain()
    {
        uiScript.CloseMenu();
        uiScript.uiTween.CloseMainMenu();
        uiScript.OpenTrainMenu(this);
        //UnselectTrain();
    }*/
    /*public void UnselectTrain()
    {
        canvas.gameObject.SetActive(false);
        panelButton.gameObject.SetActive(false);
        money.gameObject.SetActive(false);
        tickets.gameObject.SetActive(false);
        outline.enabled = false;
        foreach (WagonScript w in wagon)
        {
            w.outline.enabled = false;
        }
        isTrainSelected = false;
        tsScript.trainSelected = null;
    }*/
    public void Upgrade()
    {
        if (upgradeLvl <= 4)
        {
            if (tUpgrade[upgradeLvl].isTickets)
            {
                if (!tsScript.mainScript.pData.CheckValue(tUpgrade[upgradeLvl].upgradeCost, true))
                {
                    //uiScript.upgradeTrain.interactable = false;
                    uiScript.upgradeTrainPrice.text = FormatNumsHelper.FormatNum(tUpgrade[upgradeLvl].upgradeCost);
                    uiScript.OpenDonateMenu();
                    return;
                }
                else
                    tsScript.mainScript.pData.ChangeTickets(this.gameObject, -tUpgrade[upgradeLvl].upgradeCost);
            }
            else
            {
                if (!tsScript.mainScript.pData.CheckValue(tUpgrade[upgradeLvl].upgradeCost, false))
                {
                    //uiScript.upgradeTrain.interactable = false;
                    uiScript.upgradeTrainPrice.text = FormatNumsHelper.FormatNum(tUpgrade[upgradeLvl].upgradeCost);
                    uiScript.OpenNoMoneyMenu(tUpgrade[upgradeLvl].upgradeCost);
                    return;
                }
                else
                    tsScript.mainScript.pData.ChangeMoney(this.gameObject, -tUpgrade[upgradeLvl].upgradeCost);
            }
            switch (upgradeLvl)
            {
                case 0:
                    {
                        maxSpeed = tUpgrade[0].upgradeCount;
                        breakSpeed = tUpgrade[0].breakSpeed;
                        uiScript.speedTrainTrainMenu.StringReference.Arguments = new[] { maxSpeed.ToString() };
                        uiScript.speedTrainTrainMenu.SetEntry("KM/H");
                        uiScript.speedTrainTrainMenu.RefreshString();
                        break;
                    }
                case 1:
                    {
                        chanceBroke = tUpgrade[1].upgradeCount;
                        break;
                    }
                case 2:
                    {
                        maxHealth = tUpgrade[2].upgradeCount;
                        uiScript.maxHealthTrainTrainMenu.text = maxHealth.ToString();
                        break;
                    }
                case 3:
                    {
                        wagonsLoadingSpeed = tUpgrade[3].upgradeCount;
                        break;
                    }
                case 4:
                    {
                        uiScript.upgradeTrainPrice.transform.SetParent(uiScript.centerUpgradeTrain.transform);
                        uiScript.upgradeTrainPrice.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                        uiScript.upgradeTrain.interactable = false;
                        uiScript.upgradeTrainPrice.GetComponent<LocalizeStringEvent>().SetEntry("MaxLvl");
                        uiScript.upgradeTrainPrice.GetComponent<LocalizeStringEvent>().RefreshString();
                        wagonSizeRatio = tUpgrade[4].upgradeCount;
                        break;
                    }
            }
            uiScript.audioUI.PlaySound(UpgradeSound);
            upgradeLvl++;
            if(upgradeLvl < tUpgrade.Length)
                isUpgradeTicket = tUpgrade[upgradeLvl].isTickets;
        }
        uiScript.uiTween.UpgradeTrain();
        uiScript.CheckTrainUpgrade(this);
    }
    private void ShowPrice()
    {
        if (totalCargoPrice == 0)
            return;
        canvas.gameObject.SetActive(true);
        int i = Random.Range(0, 100);
        if (i < tsScript.mainScript.GetChanceForTicket())
        {
            int b = Random.Range(1, 10);
            tsScript.mainScript.pData.ChangeTickets(this.gameObject, b);
            tickets.gameObject.SetActive(true);
            ticketsText.text = "+" + b;
            tickets.anchoredPosition = new Vector2(0, -0.86f);
            tickets.gameObject.GetComponent<CanvasGroup>().DOFade(1, 1).OnComplete(() => { tickets.gameObject.GetComponent<CanvasGroup>().DOFade(0, 1).SetDelay(1f); });
            tickets.DOAnchorPos(new Vector2(0, 0), 1f).SetEase(Ease.OutCubic).OnComplete(() => { tickets.DOAnchorPos(new Vector2(0, 0.55f), 1f).SetEase(Ease.OutCubic).SetDelay(1f).OnComplete(() => { tickets.gameObject.SetActive(false); }); });
        }
        OtherSource.clip = uiScript.audioUI.MoneyDecreaseSound;
        OtherSource.Play();
        money.anchoredPosition = new Vector2(0, -0.56f);
        money.gameObject.SetActive(true);
        moneyText.text = "+" + totalCargoPrice;
        money.gameObject.GetComponent<CanvasGroup>().DOFade(1, 1).OnComplete(() => { money.gameObject.GetComponent<CanvasGroup>().DOFade(0, 1).SetDelay(1f); });
        money.DOAnchorPos(new Vector2(0,0), 1f).SetEase(Ease.OutCubic).OnComplete(() => { money.DOAnchorPos(new Vector2(0, 0.87f), 1f).SetEase(Ease.OutCubic).SetDelay(1f).OnComplete(() => { money.gameObject.SetActive(false);  /*if(!isTrainSelected) canvas.gameObject.SetActive(false);*/ }); });
    }
    public void SellTrain()
    {
        AudioManager.Instance.Sounds.Remove(Source);
        AudioManager.Instance.Sounds.Remove(MovementSource);
        AudioManager.Instance.Sounds.Remove(OtherSource);
        tsScript.mainScript.pData.ChangeMoney(this.gameObject, +sellPrice + sellExtraPrice);
        int v = wagon.Count;
        tPointer.Destroy();
        uiScript.audioUI.PlaySoundSecond(uiScript.audioUI.MoneyDecreaseSound);
        for (int i = 0; i < v; i++)
        {
            tsScript.priceManager.Sell(wagon[i], wagon[i].loadWeight, wagon[i].typeOfWeight);
            Destroy(wagon[i].gameObject);
        }
        for (int b = 0; b < tsScript.mainScript.allTowns.Count; b++)
        {
            if (tsScript.mainScript.allTowns[b].trains.Contains(this))
                tsScript.mainScript.allTowns[b].trains.Remove(this);
        }
        tsScript.uiScript.trainListDepot.Remove(pref);
        Destroy(pref);
        tsScript.train.Remove(this.gameObject);
        tsScript.uiScript.CloseSellMenuTrain();
        tsScript.uiScript.CloseMenu();
        tsScript.uiScript.OpenDepot();
        tsScript.tScript = null;
        Destroy(gameObject);
    }
    public void ShowHp()
    {
        CheckHealth();
        CheckRepair();
        CalculateSellPrice();
        if (tsScript.mainScript.isDepotOpen == true)
        {
            healthText.text = health.ToString();
            maxHealthText.text = maxHealth.ToString();
        }
        if (tsScript.tScript == this)
        {
            if (tsScript.mainScript.isTrainMenuOpen == true)
            {
                uiScript.healthTrainTrainMenu.color = colorHealth;
                uiScript.healthTrainTrainMenu.text = tsScript.tScript.health.ToString();
                uiScript.imageHealthTrainMenu.color = colorHealth;
                uiScript.maxHealthTrainTrainMenu.text = tsScript.tScript.maxHealth.ToString();
                if (uiScript.isRepairMenuOpen == true)
                    uiScript.UpdateRepairInfo();
                if (uiScript.isSellMenuOpen == true)
                    uiScript.UpdateInfoSellMenuTrain();
            }
        }
    }
    private void ChangeHP(float count)
    {
        health += count;
        ShowHp();
    }
    private void CalculateSellPrice()
    {
        sellPrice = 0;
        if (isTicketCost)
            sellPrice = (health / maxHealth) * priceTrain * 500;
        else
            sellPrice = (health / maxHealth) * priceTrain;
        sellExtraPrice = 0;
        for (int i = 0; i < wagon.Count; i++)
        {
            sellExtraPrice += wagon[i].price * 1.2f;
        }
    }
    private void Damage()
    {
        if (health - road.Damage < 0)
        {
            ChangeHP(-health);
            if (lerpcoroutine != null)
                StopCoroutine(lerpcoroutine);
            lerpcoroutine = (LerpSpeed(speed, 0, 1f));
            StartCoroutine(lerpcoroutine);
            iBroke = true;
            Msg("TrainIsBroken");
            particleBroke.Play();
        }
        else
            ChangeHP(-road.Damage);
    }
    private void RandomBroke()
    {
        float i = Random.Range(0f, 100f);
        if (i <= chanceBroke)
        {
            Damage();
        }
    }
    public void Repair()
    {
        if (tsScript.mainScript.pData.CheckValue(repairCost, false))
        {
            if (iBroke == true)
            {
                iBroke = false;
                tPointer.Hide();
                particleBroke.Stop();
                if (canIMove == true)
                {
                    if (lerpcoroutine != null)
                        StopCoroutine(lerpcoroutine);
                    lerpcoroutine = LerpSpeed(0, maxSpeed, 1f);
                    StartCoroutine(lerpcoroutine);
                }
            }
            tsScript.mainScript.pData.ChangeMoney(gameObject, -repairCost);
            uiScript.audioUI.PlaySoundSecond(uiScript.audioUI.RepairSound);
            ChangeHP(+(newRepair - health));
        }
        else
            uiScript.OpenNoMoneyMenu(repairCost);
    }
    private void CheckRepair()
    {
        float curr;
        if (health + 30 <= maxHealth)
        {
            if (health <= 30)
            {
                if (isTicketCost)
                    repairCost = (priceTrain * 100);
                else
                    repairCost = (priceTrain / 100) * 25;
            }
            else
            {
                if (isTicketCost)
                    repairCost = (priceTrain * 100);
                else
                    repairCost = (priceTrain / 100) * 20;
            }
            newRepair = health + 30;
        }
        else
        {
            curr = maxHealth - health;
            if (isTicketCost)
                repairCost = (priceTrain * 5) * curr;
            else
                repairCost = (priceTrain / 100) * curr;
            newRepair = health + curr;
        }

        if (newRepair >= maxHealth)
            newRepairColor = tsScript.hpcolor[0];
        else if (newRepair / maxHealth >= 0.8f)
            newRepairColor = tsScript.hpcolor[1];
        else if (newRepair / maxHealth >= 0.6f)
            newRepairColor = tsScript.hpcolor[2];
        else if (newRepair / maxHealth >= 0.4f)
            newRepairColor = tsScript.hpcolor[3];
        else if (newRepair / maxHealth >= 0.2f)
            newRepairColor = tsScript.hpcolor[4];
        else if (newRepair / maxHealth < 0.2f)
            newRepairColor = tsScript.hpcolor[5];
    }
    private void CheckType()
    {
        switch (typeTrain)
        {
            case "Universal":
                {
                    colorTypeTrain = tsScript.colorTypeTrain[0];
                    subNameTrain = "(U)";
                    break;
                }
            case "Freight Only!":
                {
                    colorTypeTrain = tsScript.colorTypeTrain[1];
                    subNameTrain = "(F)";
                    break;
                }
            case "Pass Only!":
                {
                    colorTypeTrain = tsScript.colorTypeTrain[2];
                    subNameTrain = "(P)";
                    break;
                }
        }
    }
    private void CheckHealth()
    {
        if (health >= maxHealth)
            colorHealth = tsScript.hpcolor[0];
        else if (health / maxHealth >= 0.8f)
            colorHealth = tsScript.hpcolor[1];
        else if (health / maxHealth >= 0.6f)
            colorHealth = tsScript.hpcolor[2];
        else if (health / maxHealth >= 0.4f)
            colorHealth = tsScript.hpcolor[3];
        else if (health / maxHealth >= 0.2f)
            colorHealth = tsScript.hpcolor[4];
        else if (health / maxHealth < 0.2f)
            colorHealth = tsScript.hpcolor[5];
    }
    public void SelectThis()
    {
        if (!isTrainSelectDepot)
        {
            uiScript.audioUI.PlaySound(uiScript.audioUI.ShortClick);
            CheckHealth();
            tsScript.tScript = this;
            isTrainSelectDepot = true;
            mask = pref.transform.GetChild(0).gameObject;
            mask.SetActive(true);
            uiScript.trainDepotImage.gameObject.SetActive(true);
            uiScript.trainDepotImage.sprite = trainSprite;
            uiScript.nameTrainDepot.gameObject.SetActive(true);
            uiScript.nameTrainDepot.SetEntry(trainName);
            uiScript.speedTrainDepot.gameObject.SetActive(true);
            uiScript.speedTrainDepot.SetEntry("KM/H");
            uiScript.speedTrainDepot.StringReference.Arguments = new[] { maxSpeed.ToString() };
            uiScript.speedTrainDepot.RefreshString();
            uiScript.infoDepot.SetActive(false);
            for (int v = 0; v < uiScript.wagonTrainMenu.Length; v++)
                uiScript.wagonDepot[v].gameObject.SetActive(false);
            for (int i = 0; i < wagon.Count; i++)
            {
                uiScript.wagonDepot[i].gameObject.SetActive(true);
                uiScript.wagonDepot[i].sprite = wagon[i].wagonSprite;
            }
            uiScript.uiTween.SelectTrainDepot();
            maxHealthText.color = tsScript.colorSelect;
            trainNameText.color = Color.white;
            healthText.color = colorHealth;
            healthText.text = health.ToString();
            uiScript.selectTrainDepot.interactable = true;
        }
        else
            CloseElementDepot();
    }
    public void CloseElementDepot()
    {
        isTrainSelectDepot = false;
        mask = pref.transform.GetChild(0).gameObject;
        mask.SetActive(false);
        uiScript.nameTrainDepot.gameObject.SetActive(false);
        uiScript.speedTrainDepot.gameObject.SetActive(false);
        uiScript.uiTween.CloseTrainDepot();
        maxHealthText.color = tsScript.colorNeutral;
        trainNameText.color = tsScript.colorSecondNeutral;
        healthText.color = tsScript.colorNeutral;
        uiScript.selectTrainDepot.interactable = false;
        uiScript.trainDepotImage.gameObject.SetActive(false);
        uiScript.nameTrainDepot.gameObject.SetActive(false);
        uiScript.speedTrainDepot.gameObject.SetActive(false);
        uiScript.infoDepot.SetActive(true);
        for (int v = 0; v < uiScript.wagonDepot.Count; v++)
            uiScript.wagonDepot[v].gameObject.SetActive(false);
    }
    public void AddDepotElement()
    {
        pref = Instantiate(tsScript.prefElementDepot, tsScript.contentDepot.transform);
        tsScript.uiScript.trainListDepot.Add(pref);
        pref.GetComponent<SelectTrainInDepot>().This(this);
        GameObject mxHealth = pref.gameObject.transform.GetChild(2).gameObject;
        maxHealthText = mxHealth.GetComponent<TextMeshProUGUI>();
        maxHealthText.text = maxHealth.ToString();

        GameObject tnt = pref.gameObject.transform.GetChild(1).gameObject;
        trainNameText = tnt.GetComponent<TextMeshProUGUI>();
        var name = trainNameText.gameObject.GetComponent<LocalizeStringEvent>();
        name.SetEntry(trainName);

        GameObject currentHealth = pref.gameObject.transform.GetChild(3).gameObject;
        healthText = currentHealth.GetComponent<TextMeshProUGUI>();
        healthText.text = health.ToString();
    }
    private void Msg(string msg)
    {
        if (lastmsg != msg)
        {
            lastmsg = msg;
            tPointer.Hide();
            tPointer.Spawn(gameObject, msg, true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="City")
        {
            if (other.name == way[0].gameObject.name)
                placeWhereIAm = way[0];
            if (other.name == way[1].gameObject.name)
                placeWhereIAm = way[1];
        }
        if (other.tag == "Point")
        {
            if (road.point.Contains(other.gameObject.transform))
            {
                if (directionMovement == "Forward")
                    target++;
                else if (directionMovement == "Backward")
                    target--;
                RandomBroke();
            }
        }
    }
    private void OnMouseDown()
    {
        if (uiScript.mainScript.isGamePaused)
            return;
        if (uiScript.idMenu != 999)
            return;
        if (uiScript.mainScript.isBuildRailOpen)
            return;
        if (uiScript.mainScript.isSelectWayOpen)
            return;
        //if (tsScript.trainSelected != null)
        //tsScript.trainSelected.UnselectTrain();
        //isTrainSelected = true;
        tsScript.tScript = this;
        uiScript.OpenTrainMenu(this);
        uiScript.uiTween.CloseMainMenu();
        /*canvas.GetComponent<Canvas>().worldCamera = uiScript.mainScript.cam;
        uiScript.mainScript.StopCoroutine(uiScript.mainScript.camToTargetCoroutine);
        uiScript.mainScript.camToTargetCoroutine = uiScript.mainScript.CamToTarget(gameObject, true, 5f, false);
        uiScript.mainScript.StartCoroutine(uiScript.mainScript.camToTargetCoroutine);
        canvas.gameObject.SetActive(true);
        money.gameObject.SetActive(false);
        tickets.gameObject.SetActive(false);
        panelButton.gameObject.SetActive(true);
        outline.enabled = true;
        foreach (WagonScript w in wagon)
        {
            w.outline.enabled = true;
        }*/
    }
}
