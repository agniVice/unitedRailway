using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Components;

public class Map : MonoBehaviour
{
    [SerializeField] public int _sceneId;
    [SerializeField] private UITweenMainMenu uiMainScript;
    [SerializeField] private MapController mapController;
    [SerializeField] private AudioUI audioUI;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _neutralColor;
    [SerializeField] private Vector3 _position;
    [SerializeField] private GameObject _canvas;
    [SerializeField] public bool _isMapUnlocked;
    [SerializeField] public int _stars;
    [SerializeField] private string _mapName;
    [SerializeField] private int _mapTime;
    [SerializeField] public int _bestTime;
    [SerializeField] public int timesPlayed;
    public Vector3 _positionGlobal;

    [Space]
    [Header("UI")]
    [SerializeField] private GameObject _maskLock;
    [SerializeField] private RectTransform[] _starsImage;
    [SerializeField] private LocalizeStringEvent _mapNameText;
    [SerializeField] private TextMeshProUGUI _mapTimeText;
    [SerializeField] private TextMeshProUGUI _bestTimeText;

    [SerializeField] private Sprite _emptyStarSprite;
    [SerializeField] private Sprite _fullStarSprite;
    //[SerializeField] private Color[] colorTime;

    public float newZoom;

    private Outline outline;
    private void Awake()
    {
        LoadMap();
    }
    private void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        outline.OutlineWidth = 10f;
        outline.OutlineColor = _neutralColor;
        _canvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mapController != null)
            {
                Ray ray = mapController.camController.cam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                RaycastHit _hit;
                if (Physics.Raycast(ray, out _hit))
                {
                    if (_hit.collider.gameObject.tag == "Map")
                    {
                        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                            return;
                        if (_hit.collider.gameObject.GetComponent<Map>() == this)
                        {
                            if (uiMainScript._IsMissionsOpen)
                                mapController.SelectMap(this);
                        }
                    }
                }
            }
        }
    }
    public void SetPosition()
    {
        _position = gameObject.transform.localPosition;
        _positionGlobal = gameObject.transform.position;
    }
    public void Spawn()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Random.Range(gameObject.transform.localPosition.y + 100f, gameObject.transform.localPosition.y + 300f), gameObject.transform.localPosition.z);
        if (this != mapController.selectedMap)
            gameObject.transform.DOLocalMove(_position, 1.5f).SetEase(Ease.OutCubic);
        else
            gameObject.transform.localPosition = _position;
        if (_isMapUnlocked)
            outline.OutlineColor = _selectedColor;
        else
            outline.OutlineColor = _neutralColor;
    }
    public bool GetUnlock()
    {
        if (_isMapUnlocked)
            return true;
        else
            return false;
    }
    public int GetIndex()
    {
        return _sceneId;
    }
    public void SelectMap()
    {
        _canvas.SetActive(true);
        audioUI.PlaySound(audioUI.CloseMenu);
        foreach (RectTransform star in _starsImage)
        {
            star.localScale = Vector3.zero;
            star.GetComponent<Image>().sprite = _emptyStarSprite;
        }

        if (_isMapUnlocked)
        {
            _maskLock.SetActive(false);
            _bestTimeText.gameObject.SetActive(true);
            _mapTimeText.gameObject.SetActive(true);

            for (int i = 0; i < _stars; i++)
                _starsImage[i].GetComponent<Image>().sprite = _fullStarSprite;

            _starsImage[0].DOScale(0.08f, 0.3f).SetEase(Ease.OutBack);
            _starsImage[1].DOScale(0.08f, 0.3f).SetEase(Ease.OutBack).SetDelay(0.15f);
            _starsImage[2].DOScale(0.08f, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
            uiMainScript.buttonPlayMission.localScale = Vector3.zero;
            uiMainScript.buttonPlayMission.DOScale(1, 0.3f).SetEase(Ease.OutBack);

            CheckTime();

            _bestTimeText.rectTransform.DOScale(0.2f, 0.3f).SetEase(Ease.OutBack);
            _mapTimeText.rectTransform.DOScale(0.2f, 0.3f).SetEase(Ease.OutBack).SetDelay(0.2f); 
        }
        else
        {
            _maskLock.SetActive(true);
            _mapTimeText.gameObject.SetActive(false);
            _bestTimeText.gameObject.SetActive(false);


            uiMainScript.buttonPlayMission.DOScale(0, 0.3f).SetEase(Ease.InOutBack);
        }
        _mapNameText.SetEntry(_mapName);
        _mapNameText.gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
        _mapNameText.gameObject.GetComponent<RectTransform>().DOScale(0.2f, 0.3f).SetEase(Ease.OutBack).SetDelay(0.1f);

        gameObject.transform.DOLocalMove(new Vector3(gameObject.transform.localPosition.x, _position.y + 55f, gameObject.transform.localPosition.z), 1.5f).SetEase(Ease.OutCubic);
    }
    private void CheckTime()
    {
        if (timesPlayed == 0)
            _bestTimeText.text = "n/a";
        else
        {
            float minutesBest = Mathf.FloorToInt(_bestTime) / 60;
            float secondsBest = Mathf.FloorToInt((_bestTime) % 60);
            if (secondsBest >= 10)
                _bestTimeText.text = minutesBest + ":" + secondsBest;
            else
                _bestTimeText.text = minutesBest + ":0" + secondsBest;
        }

        float minutesMap = Mathf.FloorToInt(_mapTime) / 60;
        float secondsMap = Mathf.FloorToInt((_mapTime) % 60);
        if (secondsMap >= 10)
            _mapTimeText.text = minutesMap + ":" + secondsMap;
        else
            _mapTimeText.text = minutesMap + ":0" + secondsMap;

        _bestTimeText.rectTransform.localScale = Vector3.zero;
        _mapTimeText.rectTransform.localScale = Vector3.zero;
    }
    public int GetTime()
    {
        return _bestTime;
    }
    public void DeselectMap()
    {
        _canvas.SetActive(false);
        gameObject.transform.DOLocalMove(_position, 1.5f).SetEase(Ease.OutCubic);
    }
    private void OnMouseDown()
    {
        
    }
    public void SaveMap()
    {
        SaveSystem.SaveMission(this);
    }
    public void LoadMap()
    {
        MissionData data = SaveSystem.LoadMission(this);

        _stars = data.CountStars;
        _bestTime = data.BestTime;
        timesPlayed = data.CountPlays;

        if (data.IsMapUnlocked == 1)
            _isMapUnlocked = true;
        else
            _isMapUnlocked = false;
    }
    public void CheckUnlock()
    {
        if (_stars >= 1)
            mapController.UnlockNextMap(this);
    }
}
