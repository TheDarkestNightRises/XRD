using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ObjectTapHandler : PressInputBase
{
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField] public ARRaycastManager raycastManager;
    [SerializeField] private GameObject infoBox;

    protected override void OnPress(Vector3 position)
    {
        if (raycastManager.Raycast(position, hits, TrackableType.All))
        {
            if (hits.Count > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.TryGetComponent<ObjectDescriptionHandler>(out var objectInfo))
                    {
                        string description = objectInfo.description;

                        TextMeshProUGUI infoText = infoBox.GetComponentInChildren<TextMeshProUGUI>();
                        infoText.text = description;
                        infoBox.SetActive(true);
                        Debug.Log("Description: " + description);
                        Debug.Log("You hit an object with ObjectInfoHandler");
                        Debug.Log("You hit an object with ObjectInfoHandler: " + objectInfo.gameObject.name);
                    }
                }
            }
        }


    }

    // public bool isButtonPressed()
    // {
    //     // Return true if no UI button is pressed
    //     // return EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null;
    // }   
}
