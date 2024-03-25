using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RailRoadSystemScript : MonoBehaviour
{
    public GameObject[] road;
    public RailRoadScript roadSelected;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
    public AudioSource Source;
    public AudioClip BuyRailClip;
    public AudioClip SelectRailSound;
    [SerializeField] private GameObject camObject;
    private void Awake()
    {
        Source = gameObject.GetComponent<AudioSource>();
        AudioManager.Instance.Sounds.Add(Source);
    }
    public int GetRailroadCount()
    {
        int c = 0;
        foreach (GameObject r in road)
        {
            if (r.GetComponent<RailRoadScript>().isRailBuild)
                c++;
        }
        return c;
    }
    public void BuyRail()
    {
        if (roadSelected == null)
            return;
        if (!mainScript.pData.CheckValue(roadSelected.price, false))
        {
            mainScript.uiScript.OpenNoMoneyMenu(roadSelected.price);
            return;
        }
        Source.clip = BuyRailClip;
        Source.Play();
        mainScript.pData.Source.clip = mainScript.pData.SoundMoneyDecrease;
        mainScript.pData.Source.Play();
        mainScript.pData.ChangeMoney(this.gameObject, -roadSelected.price);
        roadSelected.isRailBuild = true;

        foreach (MeshRenderer m in roadSelected.meshRenderer)
            m.material = roadSelected.mat[0];
        foreach (RoadChildCollider c in roadSelected.child)
            c.gameObject.SetActive(false);

        roadSelected.gameObject.transform.DOLocalMove(new Vector3(roadSelected.normalPosition.x, roadSelected.normalPosition.y, roadSelected.normalPosition.z), 1f).SetEase(Ease.OutCubic);
        uiScript.buyRail.SetActive(false);
        roadSelected = null;
        mainScript.taskSystem.GetInfo(this);
        Tutorial.Instance.GetInfo("RailWasBought");
        CloseBuild();
    }
    public void OpenBuild()
    {
        Tutorial.Instance.GetInfo("BuildWasOpened");
        /*if (uiScript.tsScript.trainSelected != null)
            uiScript.tsScript.trainSelected.UnselectTrain();*/
        if (mainScript.isTownRawInfoOpened == true)
            mainScript.townRawScript.CloseTownRawInfo();
        uiScript.uiTween.CloseMainMenu();
        mainScript.isBuildRailOpen = true;
        for (int i = 0; i < road.Length; i++)
        {
            if (!road[i].GetComponent<RailRoadScript>().isRailBuild)
            {
                road[i].GetComponent<RailRoadScript>().Spawn(1);
                uiScript.uiTween.OpenBuildRail();
                uiScript.buyRail.SetActive(false);
                RailRoadScript rss;
                for (int r = 0; r < road.Length; r++)
                {
                    if (!road[r].GetComponent<RailRoadScript>().isRailBuild)
                    {
                        rss = road[r].GetComponent<RailRoadScript>();
                        rss.RoadSelect();
                        /*mainScript.camToTargetCoroutine = mainScript.CamToTarget(rs.camObject, true, 15f);
                        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);*/
                        return;
                    }
                }
                mainScript.camToTargetCoroutine = mainScript.CamToTarget(mainScript.camRig, true, mainScript.camController.zoomMax);
                mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
                return;
            }
        }
        uiScript.uiTween.OpenBuildRail();
        uiScript.buyRail.SetActive(false);

        RailRoadScript rs;
        for (int r = 0; r < road.Length; r++)
        {
            if (!road[r].GetComponent<RailRoadScript>().isRailBuild)
            {
                rs = road[r].GetComponent<RailRoadScript>();
                rs.RoadSelect();
                /*mainScript.camToTargetCoroutine = mainScript.CamToTarget(rs.camObject, true, 15f);
                mainScript.StartCoroutine(mainScript.camToTargetCoroutine);*/
                return;
            }
        }
        mainScript.camToTargetCoroutine = mainScript.CamToTarget(mainScript.camRig, true, mainScript.camController.zoomMax);
        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
    }
    public void CloseBuild()
    {
        Tutorial.Instance.GetInfo("BuildWasClosed");
        uiScript.uiTween.OpenMainUI();
        for (int i = 0; i < road.Length; i++)
        {
            if (road[i].GetComponent<RailRoadScript>().isRailBuild == false)
                road[i].GetComponent<RailRoadScript>().Hide();
        }
        if (roadSelected != null)
            roadSelected.CloseSelect();
        uiScript.uiTween.CloseBuildRail();
        mainScript.StopCoroutine(mainScript.camToTargetCoroutine);
    }
}
