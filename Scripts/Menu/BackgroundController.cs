using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BackgroundController : MonoBehaviour
{
    public GameObject cam;
    public MapController mapController;
    public CamController camController;
    private void Start()
    {
        gameObject.transform.SetParent(cam.transform);
        Move();
    }
    public void Move()
    {
        if (mapController.IsMapSelection == false)
            transform.DOLocalMove(new Vector3(-260, -87, 93), 10f).SetDelay(1f).OnComplete(() => {
                transform.DOLocalMove(new Vector3(-207, -15, 165), 10f).SetDelay(1f).OnComplete(() => {
                    transform.DOLocalMove(new Vector3(-366, -15, 165), 10f).SetDelay(1f).OnComplete(() => {
                        transform.DOLocalMove(new Vector3(-612, 144, 324), 10f).SetDelay(1f).OnComplete(() => {
                            transform.DOLocalMove(new Vector3(-521, 310, 490), 10f).SetDelay(1f).OnComplete(() => {
                                transform.DOLocalMove(new Vector3(-412, 326, 506), 10f).SetDelay(1f).OnComplete(() => {
                                    transform.DOLocalMove(new Vector3(-231, 171, 351), 10f).SetDelay(1f).OnComplete(() => {
                                        transform.DOLocalMove(new Vector3(-272, -27, 152), 10f);}).SetDelay(1f).OnComplete(() => {
                                            Move(); 
                                    });
                                });
                            });
                        });
                    });
                });
            });
    }
}
