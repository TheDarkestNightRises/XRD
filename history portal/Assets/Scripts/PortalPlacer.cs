using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PortalPlacer : PressInputBase
{
    [SerializeField] public GameObject SpawnablePortal;
    [SerializeField] public ARRaycastManager raycastManager;
    [SerializeField] public ARPlaneManager planeManager;
    [SerializeField] public GameObject markerPrefab;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject currentPortal;
    private GameObject markerInstance;
    private Pose lastHitPose;

    void Start()
    {
        if (markerPrefab != null)
        {
            markerInstance = Instantiate(markerPrefab);
            markerInstance.SetActive(false);
        }
    }

    void Update()
    {
        UpdateMarkerPosition();
    }

    private void UpdateMarkerPosition()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            lastHitPose = hits[0].pose;

            if (markerInstance != null)
            {
                markerInstance.SetActive(true);
                markerInstance.transform.position = lastHitPose.position;
                markerInstance.transform.rotation = Quaternion.Euler(-90, lastHitPose.rotation.eulerAngles.y, lastHitPose.rotation.eulerAngles.z);
            }
        }
        else
        {
            if (markerInstance != null)
            {
                markerInstance.SetActive(false);
            }
        }
    }

    protected override void OnPress(Vector3 position)
    {
        if (markerInstance == null || !markerInstance.activeSelf) return;

        if (currentPortal != null)
        {
            Destroy(currentPortal);
        }

        currentPortal = Instantiate(SpawnablePortal, lastHitPose.position, lastHitPose.rotation);
    }

    public void SwitchLocation(GameObject location)
    {
        SpawnablePortal = location;
    }

    public bool isButtonPressed()
    {
        return EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null;
    }
}
