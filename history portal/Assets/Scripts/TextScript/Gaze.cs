using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    private InfoBehaviour currentInfo; 

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                InfoBehaviour infoBehaviour = go.GetComponent<InfoBehaviour>();

                if (currentInfo != infoBehaviour)
                {
                    CloseCurrentInfo(); 
                    currentInfo = infoBehaviour; 
                    currentInfo.OpenInfo(); 
                }
            }
            else
            {
                CloseCurrentInfo(); 
            }
        }
        else
        {
            CloseCurrentInfo(); 
        }
    }

    private void CloseCurrentInfo()
    {
        if (currentInfo != null)
        {
            currentInfo.CloseInfo();
            currentInfo = null; 
        }
    }
}
