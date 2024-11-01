using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                OpenInfo(go.GetComponent<InfoBehaviour>());
            }
        } else
        {
            CloseAll();
        }
    }
    void OpenInfo(InfoBehaviour desiredInfo)
    {
        desiredInfo.OpenInfo();
    }

    void CloseAll()
    {
        
    }
}
