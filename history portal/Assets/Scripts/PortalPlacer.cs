using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PortalPlacer : PressInputBase
{
    [SerializeField] public GameObject SpawnablePortal;
    [SerializeField] public ARRaycastManager raycastManager;
    [SerializeField] public ARPlaneManager planeManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject currentPortal; 

    protected override void OnPress(Vector3 position)
    {
        if (!raycastManager.Raycast(position, hits, TrackableType.PlaneWithinPolygon)) return;

        if (!isButtonPressed()) return;

        var hitPose = hits[0].pose;

        if (currentPortal != null)
        {
            Destroy(currentPortal);
        }

        currentPortal = Instantiate(SpawnablePortal, hitPose.position, hitPose.rotation);
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
