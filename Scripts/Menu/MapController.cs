using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapController : MonoBehaviour
{
    [SerializeField] private UITweenMainMenu uiMainScript;
    [SerializeField] private BackgroundController bgController;
    public SceneManagerScript sManager;
    [SerializeField] private List<Map> map;
    public CamController camController;
    public Map selectedMap;

    public bool IsMapSelection;
    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        foreach (Map m in map)
            m.SetPosition();

        gameObject.transform.localScale = Vector3.zero;

        selectedMap = map[0];

        CheckUnlock();
        if (PlayerPrefs.HasKey("Tutorial1"))
        {
            if (PlayerPrefs.GetInt("Tutorial1") == 0)
            {
                DOTween.KillAll();
                sManager.LoadMission(1);
            }
        }
        else
        {
            DOTween.KillAll();
            sManager.LoadMission(1);
        }
    }
    public void SelectMap(Map _map)
    {
        if (selectedMap != null)
            selectedMap.DeselectMap();
        selectedMap = _map;
        selectedMap.SelectMap();

        camController.newPosition = _map._positionGlobal;
        camController.newZoom = _map.newZoom;
    }
    public void OpenMapSelection()
    {
        IsMapSelection = true;
        gameObject.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.6f).SetEase(Ease.OutBack);

        foreach (Map m in map)
            m.Spawn();

        SelectMap(selectedMap);
    }
    public void CloseMapSelection()
    {
        IsMapSelection = false;
        gameObject.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack);
        camController.newZoom = 35;
    }
    public void NextMap()
    {
        if (selectedMap != map[map.Count-1])
            SelectMap(map[map.IndexOf(selectedMap)+1]);
        else
            SelectMap(map[0]);
    }
    public void PrevMap()
    {
        if (selectedMap != map[0])
            SelectMap(map[map.IndexOf(selectedMap) - 1]);
        else
            SelectMap(map[map.Count-1]);
    }
    public void Play()
    {
        if (selectedMap.GetUnlock())
        {
            sManager.SetDelay(0.7f);

            selectedMap.transform.parent = null;

            selectedMap.GetComponent<MeshRenderer>().enabled = false;
            sManager.LoadMission(selectedMap.GetIndex());
        }
        else
            uiMainScript.buttonPlayMission.gameObject.SetActive(false);
    }
    public void CheckUnlock()
    {
        foreach (Map m in map)
        {
            m.CheckUnlock();
        }
    }
    public void UnlockNextMap(Map m)
    {
        map[m._sceneId]._isMapUnlocked = true;
        map[m._sceneId].SaveMap();
    }
}
