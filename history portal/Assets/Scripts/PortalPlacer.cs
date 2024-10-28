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

    protected override void OnPress(Vector3 position)
    {
        if (!raycastManager.Raycast(position, hits, TrackableType.PlaneWithinPolygon)) return;

        if (!isButtonPressed()) return;

        var hitpose = hits[0].pose;

        Instantiate(SpawnablePortal, hitpose.position, hitpose.rotation);

        // foreach (var plane in planeManager.trackables)
        // {
        //     plane.gameObject.SetActive(false);
        // }

        // planeManager.enabled = false;
    }

    public void SwitchLocation(GameObject location)
    {
        // Switch the portal prefab
        SpawnablePortal = location;
    }

    public bool isButtonPressed()
    {
        // Return true if no UI button is pressed
        return EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null;
    }
}
