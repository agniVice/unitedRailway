using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRotateScript : MonoBehaviour
{
    [SerializeField] CameraController cam;

    public bool RotateOnStart;
    public float StartDelay;
    public float Angle;
    [Range(0, 5)]
    public float RotatingTime;
    public Ease Easee;
    private IEnumerator rotate;

    private void Start()
    {
        if (RotateOnStart)
            rotate = RotateCoroutine(Angle, RotatingTime, Easee, StartDelay);
            StartCoroutine(rotate);
    }
    public void Rotate(float angle, float rotatingTime, Ease ease)
    {
        cam.transform.DORotate(new Vector3(cam.transform.rotation.x, angle, cam.transform.rotation.z), rotatingTime).SetEase(ease).OnComplete(() => { this.enabled = false; });
    }
    private IEnumerator RotateCoroutine(float angle, float rotatingTime, Ease ease, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        Rotate(angle, rotatingTime, ease);
    }
}
