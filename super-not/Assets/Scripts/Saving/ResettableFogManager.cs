using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableFogManager : Resettable
{
    private Color originalFogColor;
    private float originalFogDensity;
    private bool originalFogEnabled;

    private void Awake()
    {
        originalFogColor = RenderSettings.fogColor;
        originalFogDensity = RenderSettings.fogDensity;
        originalFogEnabled = RenderSettings.fog;
    }

    public override void ResetHandler()
    {
        RenderSettings.fogEndDistance = 50;
        RenderSettings.fogColor = originalFogColor;
        RenderSettings.fogDensity = originalFogDensity;
        RenderSettings.fog = originalFogEnabled;
    }

    public void SetFog(Color color, float density, bool enabled)
    {
        RenderSettings.fogColor = color;
        RenderSettings.fogDensity = density;
        RenderSettings.fog = enabled;
    }
}
