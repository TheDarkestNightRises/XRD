Shader "Custom/PortalShader"
{
    SubShader
    {
        ZWrite Off
        ColorMask 0
        Cull Off

        Stencil
        {
            Ref 1
            Pass Replace
        }

        Pass
        {
        }
    }
}
