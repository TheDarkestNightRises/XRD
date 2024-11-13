using System.Collections;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    private float targetFogEndDistance = 5f;  
    private float initialFogEndDistance = 50f;

    private void Start()
    {
        ResetFog();
    }

    public void SetFog()
    {
        StartCoroutine(SetFogRoutine());
    }

    private IEnumerator SetFogRoutine()
    {
        while (RenderSettings.fogEndDistance > targetFogEndDistance)
        {
            RenderSettings.fogEndDistance = Mathf.Lerp(RenderSettings.fogEndDistance, targetFogEndDistance, 0.1f);
            yield return null;
        }
    }

    public void ResetFog()
    {
        RenderSettings.fogEndDistance = initialFogEndDistance;
    }
}
