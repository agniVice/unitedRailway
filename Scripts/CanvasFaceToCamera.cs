using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CanvasFaceToCamera : MonoBehaviour
{
    public GameObject cam;
    private void Start()
    {
        if (cam == null)
            cam = GameObject.Find("Camera");
    }
    private void FixedUpdate()
    {
        gameObject.transform.forward = cam.transform.forward;
    }
#if UNITY_EDITOR
    [ContextMenu("Rotate to camera")]
    public void CanvasToCamera()
    {
        if (cam == null)
            cam = GameObject.Find("Camera");
        gameObject.transform.forward = cam.transform.forward;
    }
#endif
}
