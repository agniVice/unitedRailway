using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneScript : MonoBehaviour
{
    public SceneManagerScript sManager;
    public UnityAnalytics uAnalitycs;
    public TasksSystemScript taskSystem;
    public PlayerData pData;
    public UserInterfaceScript uiScript;
    public TownRawScript townRawScript;
    public RailRoadSystemScript rsScript;
    public GameObject town;
    public Camera cam;
    public CameraController camController;
    public GameObject camRig;
    public PointerManager pManager;
    public PriceListScript plScript;
    public float timeOfLevel;
    public List<TownRawScript> trScript;
    public List<TownRawScript> allTowns;
    public TimerScript timerS;
    [Space]
    [Header("SettingsOfLevel")]
    [SerializeField] private float _damageFromRail;
    [SerializeField] private float _chanceDamageFromRail;
    [SerializeField] private float _extraSpeed;
    [SerializeField] private float _extraWagonSize;
    [SerializeField] private float _extraProductionTime;
    [SerializeField] private float _chanceToGetTicket;
    public string _mapName;
    public Map map;
    public Map mapPrefab;
    [Space]
    public bool isGamePaused;
    public bool isTownRawOpened;
    public bool isTownRawInfoOpened;
    public bool isNewGame = true;
    public bool isBuildRailOpen;
    public bool isDepotOpen;
    public bool isTrainShopOpen;
    public bool isTrainMenuOpen;
    public bool isSelectWayOpen;
    public bool isTrainSelected;
    public IEnumerator camToTargetCoroutine;
    // EXPERIENCE
    [SerializeField] private Image bar_exp;
    [SerializeField] private int lvl;
    [SerializeField] private float _exp;
    [SerializeField] private float _newExp;
    [SerializeField] private float[] _nextExp;//9max +1(0) = 10lvls
    [SerializeField] private float elapsedTimeExp;
    [SerializeField] private float timer = 2f;
    [Space]
    [Header("Shop")]
    [SerializeField] private ShopScript sScript;
    [SerializeField] private int _missionId;
    [Header("Economy")]
    [SerializeField] private float staticRewardMoney;
    [SerializeField] private float staticRewardTickets;
    [SerializeField] private float _multiply;
    [SerializeField] private float[] timeToStar;
    [SerializeField] private int stars;
    public int timeExtraContinue;
    private void Awake()
    {
        uiScript.exp.text = Mathf.RoundToInt(_exp) + "/" + _nextExp[lvl];
    }
    private void Start()
    {

        InterstitialAd.S.LoadAd();
        RewardedAds.S.LoadAd();
        map = Instantiate(mapPrefab);
        map.gameObject.name = _missionId.ToString();
        map.GetComponent<MeshFilter>().mesh = null;


        if (PlayerPrefs.HasKey("ChanceX3"))
        {
            if(PlayerPrefs.GetInt("ChanceX3") == 1)
                ChanceTicketDonate();
        }
    }
    private void Update()
    {
        if (uiScript.idMenu == 999)
        {
            if (_exp != _newExp)
            {
                elapsedTimeExp += Time.deltaTime;
                float perc = elapsedTimeExp / timer;
                _exp = Mathf.Lerp(_exp, _newExp, Mathf.SmoothStep(0, 1, perc));
                uiScript.exp.text = Mathf.RoundToInt(_exp) + "/" + _nextExp[lvl];
            }
            uiScript.fullbarExp.fillAmount = _exp / _nextExp[lvl];
        }
    }
    public void ChanceTicketDonate()
    {
        _chanceToGetTicket = _chanceToGetTicket*3;
    }
    public float GetMultiply()
    {
        return _multiply;
    }
    public float GetStaticReward()
    {
        return staticRewardMoney;
    }
    public float GetStaticRewardTickets()
    {
        return staticRewardTickets;
    }
    public int GetMissionID()
    {
        return _missionId;
    }
    public int GetPlayerLevel()
    {
        return lvl;
    }
    public int GetMissionStars()
    {
        return stars;
    }
    public void GetRewardFromAd()
    {
        pData.StaticMoneyToReward();
    }
    /*public float GetWagonSize()
    {
        return _extraWagonSize;
    }*/
    /*public float GetChanceBroke()
    {
        return _chanceDamageFromRail;
    }
    public float GetProductionTime()
    {
        return _extraProductionTime;
    }
    public float GetSpeed()
    {
        return _extraSpeed;
    }
    public float GetDamage()
    {
        return _damageFromRail;
    }*/
    public void RetryMission()
    {
        sManager.SetDelay(0);
        sManager.LoadMission(_missionId);
    }
    public bool CanIGoNextLvl()
    {
        if (taskSystem.IsAllTasksDone())
            return true;
        else
            return false;
    }
    public float GetChanceForTicket()
    {
        return _chanceToGetTicket;
    }
    public void GameOver(string name)
    {
        Debug.Log("gameover" + name);
        isGamePaused = true;
        if (name == "Success")
        {
            stars = 0;
            if (timerS.currentTimer <= timeToStar[0])
                stars++;
            if (timerS.currentTimer <= timeToStar[1])
                stars++;
            if (timerS.currentTimer <= timeToStar[2])
                stars++;
            uiScript.OpenGameOverSuccess();

            map.timesPlayed++;
            map._stars = stars;
            map._bestTime = Mathf.RoundToInt(timerS.currentTimer);

            SaveSystem.SaveMission(map);

            uAnalitycs.OnMissionSuccess(_missionId);
        }
        else if (name == "Fail")
        {
            stars = 0;
            uiScript.OpenGameOverFail();
            //uAnalitycs.OnMissionFailed(lvl, _missionId);
        }
    }
    public void ExtraAdContinue()
    {
        timerS.currentTimer -= timeExtraContinue;
        isGamePaused = false;
        uiScript.uiTween.OpenMainUI();
        camController.enabled = true;
        timerS.isStopped = false;
        uiScript.canvasGameOver.SetActive(false);

        //UITweenAnimation
    }
    public void GetDataShop(string name, float count)
    {
        switch (name)
        {
            case "Damage":
                {
                    _damageFromRail = count;
                    break;
                }
            case "ChanceDamage":
                {
                    _chanceDamageFromRail = count;
                    break;
                }
            case "ExtraSpeed":
                {
                    _extraSpeed = count;
                    break;
                }
            case "ExtraWagonsSize":
                {
                    _extraWagonSize = count;
                    break;
                }
            case "ExtraProductionTime":
                {
                    _extraProductionTime = count;
                    break;
                }
        }
    }
    public void ChangeExp(float value)
    {
        _newExp += value;
        if (_newExp >= _nextExp[lvl])
        {
            if (_nextExp.Length > lvl)
            {
                lvl++;
                _newExp = 0;
                //uAnalitycs.OnLevelUp(lvl, _missionId);
            }
        }
        elapsedTimeExp = 0;
    }
    public void Upgrade() => townRawScript.Upgrade();
    public void OpenTownRaw() => uiScript.OpenTownRaw();
    public void FollowTarger(GameObject target, float speed = 5)
    {
        camController.newPosition = Vector3.Lerp(camController.newPosition, target.transform.position, speed * Time.deltaTime);
    }
    public IEnumerator CamToTarget(GameObject target, bool isZoom, float zoom, bool isMove = true)
    {
        float elapsedTime = 0;
        float waitTime = 1f;

        Vector3 gotopos = new Vector3(target.transform.position.x, camRig.transform.position.y, target.transform.position.z);

        while (elapsedTime < waitTime)
        {
            if (elapsedTime >= 0.2f)
            {
                if (camController.touchZero.phase == TouchPhase.Moved)
                {
                    /*if (uiScript.tsScript.trainSelected != null)
                        uiScript.tsScript.trainSelected.UnselectTrain();*/
                    StopCoroutine(camToTargetCoroutine);
                    yield return null;
                }
            }
            if (isZoom == true)
            {
                camController.newZoomi = Mathf.Lerp(camController.newZoomi, zoom, (elapsedTime / waitTime));
                if (zoom == camController.zoomMin)
                {
                    camController.newZoom = Vector3.Lerp(camController.newZoom, new Vector3(0, 0, 48), (elapsedTime / waitTime));
                }
                else if (zoom == camController.zoomMax)
                {
                    camController.newZoom = Vector3.Lerp(camController.newZoom, new Vector3(0, 0, 35), (elapsedTime / waitTime));
                }
            }
            if (isMove)
            {
                camController.newPosition = Vector3.Lerp(camController.newPosition, gotopos, (elapsedTime / waitTime));
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if(isMove)
            camController.newPosition = gotopos;
        //if(isZoom == true)
            //camController.newZoom = zoom;
        yield return null;
    }
    private void OnApplicationQuit()
    {
       
    }
}
