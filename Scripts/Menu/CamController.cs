using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Camera cam;
    public Vector3 newPosition;
    public float movementTime;
    public float zoomTime;
    public float newZoom;
    private void Start()
    {
        newPosition = transform.position;
        newZoom = cam.orthographicSize;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime * zoomTime);
    }
}
