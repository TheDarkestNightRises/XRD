// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Custom/PolygonGlow"
{
    Properties
    {
        _GlowColor("Glow Color", Color) = (1, 0.5, 0, 1)
        _GlowIntensity("Glow Intensity", Float) = 1.0
        _Metallic("Metallic", Range(0, 1)) = 0.0
        _Smoothness("Smoothness", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float4 color : COLOR;
            };

            // Added properties for metallic and smoothness
            float _GlowIntensity;
            float4 _GlowColor;
            float _Metallic;
            float _Smoothness;

            // PBR Lighting Model Variables
            // float3 _WorldSpaceCameraPos;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            // PBR lighting calculation function (simplified)
            half4 LightingCustom(half3 normal, half3 lightDir, half3 viewDir, half metallic, half smoothness)
            {
                // Simple Lambertian diffuse term
                half diffuse = max(0.0, dot(normal, lightDir));

                // Fresnel-Schlick for metallic reflectance (simplified)
                half fresnel = pow(1.0 - max(0.0, dot(viewDir, normal)), 5.0);
                half3 specColor = lerp(half3(0.04, 0.04, 0.04), _GlowColor.rgb, metallic); // Blend between diffuse and metallic color
                half specular = lerp(1.0, fresnel, smoothness);

                return half4(diffuse * (1.0 - metallic) + specColor * specular, 1.0);
            }

            float4 frag(v2f i) : SV_Target
            {
                // Calculate view direction
                float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPos);

                // Calculate dot product between view direction and normal for face "intensity"
                float intensity = dot(i.worldNormal, viewDir);

                // Apply a smoothstep to make glow softer near edges
                intensity = smoothstep(0.3, 1.0, intensity);

                // Call custom lighting function for PBR calculations (metallic, smoothness)
                half4 pbrColor = LightingCustom(i.worldNormal, viewDir, viewDir, _Metallic, _Smoothness);

                // Final color is based on glow color, intensity, and the PBR result
                float4 color = _GlowColor * intensity * _GlowIntensity;
                color.rgb = lerp(color.rgb, pbrColor.rgb, 0.5); // Blend glow with the PBR result

                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
