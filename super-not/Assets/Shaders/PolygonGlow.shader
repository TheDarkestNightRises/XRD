Shader "Custom/PolygonGlow"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (0.5, 0, 0, 1)
        _ReflectionColor ("Reflection Color", Color) = (1, 0.5, 0, 1)
        _Refraction ("Refraction", Range(1, 2)) = 1.45
        _Glossiness ("Glossiness", Range(0, 1)) = 0.8
        _MainTex ("Base Texture", 2D) = "white" { }
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 color : COLOR;
            };
            
            struct v2f
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };
            
            float4 _BaseColor;
            float4 _ReflectionColor;
            float _Refraction;
            float _Glossiness;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                return o;
            }
            
            float4 frag(v2f i) : SV_Target
            {
                // Sample the base color
                float4 baseColor = _BaseColor * tex2D(_MainTex, i.pos.xy);

                // Simulate reflection (just an approximation)
                float3 reflection = reflect(i.normal, normalize(float3(0, 1, 0))); // simulate light direction
                float4 reflectionColor = _ReflectionColor * max(dot(reflection, float3(0, 1, 0)), 0.0);

                // Combine base color with reflection
                float4 finalColor = baseColor + reflectionColor;
                
                return finalColor;
            }
            ENDCG
        }
    }
}
