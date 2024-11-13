using System.Collections;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    private float targetFogEndDistance = 3f;
    private float initialFogEndDistance = 50f;
    private float fogFadeDuration = 0.5f;  

    private void Start()
    {
        ClearFog();
    }

    public void SetFog() 
    {
        StopAllCoroutines(); 
        StartCoroutine(FadeInFog());
    }

    public void ClearFog() 
    {
        StopAllCoroutines(); 
        StartCoroutine(FadeOutFog());
    }

    private IEnumerator FadeInFog()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fogFadeDuration)
        {
            RenderSettings.fogEndDistance = Mathf.Lerp(initialFogEndDistance, targetFogEndDistance, elapsedTime / fogFadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RenderSettings.fogEndDistance = targetFogEndDistance;
    }

    private IEnumerator FadeOutFog()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fogFadeDuration)
        {
            RenderSettings.fogEndDistance = Mathf.Lerp(targetFogEndDistance, initialFogEndDistance, elapsedTime / fogFadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RenderSettings.fogEndDistance = initialFogEndDistance;
    }

    public void ResetFog() 
    {
        RenderSettings.fogEndDistance = initialFogEndDistance;
    }
}
