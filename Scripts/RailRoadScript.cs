using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using SplineMesh;
public class RailRoadScript : MonoBehaviour
{
    public RailRoadSystemScript rsScript;
    public MainSceneScript mainScript;
    public Material[] mat; // 0 - normal material, 1 - neutral material 2- selected material;
    public bool isRailBuild;
    public bool isRailSelected;
    public int trainsCountOnRail;
    public int trainsCountOnRailMax;
    public float Damage;
    public List<Transform> point;
    public List<TownRawScript> townraw; // 0 - start   1 - finish
    public List<MeshRenderer> meshRenderer;
    public SplineMeshTiling spline;
    public GameObject camObject;
    public Vector3 normalPosition;
    public List<RoadChildCollider> child;

    public string path;
    public float price;

    [Header("Audio")]
    public AudioClip SelectRailSound;

    private void Awake()
    {
        normalPosition = gameObject.transform.localPosition;
        MeshRenderer[] meshRendererr = gameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshRendererr.Length; i++)
            meshRenderer.Add(meshRendererr[i]);
        spline = gameObject.GetComponentInChildren<SplineMeshTiling>();
    }
    /*private void Update()
    {
        if (mainScript.isBuildRailOpen == true)
        {
            if (isRailSelected == true)
            {
                if (isRailBuild == false)
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
                            if (_hit.collider.gameObject.transform.parent.name != this.gameObject.name)
                            {
                                Debug.Log('1');
                                CloseSelect();
                            }
                        }
                    }
                }
            }
        }
    }*/
    public void Spawn(int colorNumber)
    {
        gameObject.SetActive(true);
        foreach(MeshRenderer m in meshRenderer)
            m.material = mat[colorNumber];

        if (!isRailBuild)
        {
            foreach (RoadChildCollider c in child)
                c.gameObject.SetActive(true);
        }
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void RoadSelect()
    {
        if (rsScript.roadSelected != null)
            rsScript.roadSelected.CloseSelect();
        gameObject.transform.DOLocalMove(new Vector3(normalPosition.x, normalPosition.y + 2, normalPosition.z), 1f).SetEase(Ease.OutBack);
        foreach (RoadChildCollider c in child)
            c.gameObject.SetActive(false);
        mainScript.uiScript.audioUI.PlaySound(rsScript.SelectRailSound);
        isRailSelected = true;
        rsScript.roadSelected = this;
        foreach (MeshRenderer m in meshRenderer)
            m.material = mat[2];
        mainScript.uiScript.buyRail.SetActive(true);
        mainScript.uiScript.priceRoadText.text = FormatNumsHelper.FormatNum(price);
        if(mainScript.camToTargetCoroutine != null)
            mainScript.StopCoroutine(mainScript.camToTargetCoroutine);
        mainScript.camToTargetCoroutine = mainScript.CamToTarget(camObject, true, mainScript.camController.zoomMax);
        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
    }
    public void CloseSelect()
    {
        int matNub;
        if (isRailBuild == true)
            matNub = 0;
        else
            matNub = 1;
        gameObject.transform.DOLocalMove(new Vector3(normalPosition.x, normalPosition.y, normalPosition.z), 1f).SetEase(Ease.OutCubic);
        foreach (RoadChildCollider c in child)
            c.gameObject.SetActive(true);
        isRailSelected = false;
        foreach (MeshRenderer m in meshRenderer)
            m.material = mat[matNub];
        rsScript.roadSelected = null;
        mainScript.uiScript.buyRail.SetActive(false);
    }
}
