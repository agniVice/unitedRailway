using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera and MainScript")]
    public Transform cameraTransform;
    public Camera cam;
    public MainSceneScript mainScript;
    public Transform audioListener;

    [Space]

    [Header("LimitCameraBounds")]
    public float leftLimit;
    public float rightLimit;
    public float forwardLimit;
    public float backLimit;
    [Space]
    [Header("CameraSettings")]
    public float zoomTime;
    public float movementTime;
    public float zoomMin;
    public float zoomMax;
    public Vector3 newZoom;
    public float newZoomi;
    public Vector3 zoomAmount;
    public float zoomSensivity;

    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    public bool multiTouch;

    public Touch touchZero;
    private Touch touchOne;

    private Vector3 avgPosition;
    public Vector3 newPosition;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    void Start()
    {
        newPosition = transform.position;
        //newZoom = cam.transform.localPosition;
    }

    void LateUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += transform.forward * 0.3f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += transform.forward * -0.3f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += transform.right * 0.3f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPosition += transform.right * -0.3f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newZoomi += 0.1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            newZoomi -= 0.1f;
        }
#endif
        if (Input.GetMouseButtonDown(0))
        {
            multiTouch = false;
        }
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1 && multiTouch == false)
            {
                touchZero = Input.GetTouch(0);
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = cam.ScreenPointToRay(touchZero.position);
                float entry;
                if (plane.Raycast(ray, out entry))
                {
                    switch (touchZero.phase)
                    {
                        case TouchPhase.Began:
                            dragStartPosition = ray.GetPoint(entry);
                            break;
                        case TouchPhase.Moved:
                            dragCurrentPosition = ray.GetPoint(entry);
                            newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                            break;
                        case TouchPhase.Ended:
                            break;
                    }
                }
            }
            if (Input.touchCount == 2)
            {
                multiTouch = true;
                touchZero = Input.GetTouch(0);
                touchOne = Input.GetTouch(1);
                avgPosition = (touchOne.position + touchZero.position)/2;
                Plane planee = new Plane(Vector3.up, Vector3.zero);
                Ray rayy = cam.ScreenPointToRay(avgPosition);
                float entryy;
                if (planee.Raycast(rayy, out entryy))
                {
                    switch (touchOne.phase)
                    {
                        case TouchPhase.Began:
                            dragStartPosition = rayy.GetPoint(entryy);
                            break;
                        case TouchPhase.Moved:
                            dragCurrentPosition = rayy.GetPoint(entryy);
                            newPosition = transform.position + dragStartPosition - dragCurrentPosition;

                            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
                            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

                            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
                            float currentDistTouch = (touchZero.position - touchOne.position).magnitude;
                            float difference = currentDistTouch - distTouch;
                            zoom(difference * zoomSensivity);
                            break;
                    }
                }
            }
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
        transform.position.y,
        Mathf.Clamp(transform.position.z, backLimit, forwardLimit));
        newPosition = new Vector3(
        Mathf.Clamp(newPosition.x, leftLimit, rightLimit),
        transform.position.y,
        Mathf.Clamp(newPosition.z, backLimit, forwardLimit));
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoomi, Time.deltaTime * zoomTime);
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, zoomMin, zoomMax);
        audioListener.localPosition = Vector3.Lerp(audioListener.localPosition, newZoom, Time.deltaTime * zoomTime);
        newZoom.y = Mathf.Clamp(newZoom.y, minY, maxY);
        newZoom.z = Mathf.Clamp(newZoom.z, minZ, maxZ);
        //cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, Mathf.Clamp(cam.transform.localPosition.y, 30, 150), Mathf.Clamp(cam.transform.localPosition.z, -30, -150));

    }
    private void zoom(float increment)
    {
        newZoom += zoomAmount * increment;
        newZoomi = Mathf.Clamp(cam.orthographicSize - increment, zoomMin, zoomMax);
    }

}
