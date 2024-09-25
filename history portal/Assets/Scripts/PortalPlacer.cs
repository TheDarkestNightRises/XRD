using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PortalPlacer : MonoBehaviour
{
    [SerializeField] public GameObject SpawnablePortal;
    [SerializeField] public ARRaycastManager raycastManager;
    [SerializeField] public ARPlaneManager planeManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Update()
    {
        // Only proceed if there's at least one touch on the screen
        if (Input.touchCount <= 0) return;

        // Get the first touch
        var touch = Input.GetTouch(0);

        // Proceed when the touch phase is "Began" (when the user first touches the screen)
        if (touch.phase != TouchPhase.Began) return;

        // Check if the raycast hits a plane within the polygon
        if (!raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon)) return;

        // Ensure no UI button was touched
        if (!isButtonPressed()) return;

        // Get the position and rotation from the hit pose
        var hitpose = hits[0].pose;

        // Place the portal at the hit location
        Instantiate(SpawnablePortal, hitpose.position, hitpose.rotation);

        // Disable all planes and the plane manager after placing the portal
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        planeManager.enabled = false;
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
