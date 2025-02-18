Shader "Custom/PortalURP"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _InactiveColour ("Inactive Colour", Color) = (1,1,1,1)
        _DisplayMask ("Display Mask", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForward" }
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            struct Attributes
            {
                float4 positionOS : POSITION;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _InactiveColour;
                float _DisplayMask;
            CBUFFER_END

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                // Передаём позицию в clip-пространстве для вычисления координат экрана
                OUT.screenPos = OUT.positionHCS;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                // Вычисляем UV из позиции в экранном пространстве
                float2 uv = IN.screenPos.xy / IN.screenPos.w;
                half4 portalCol = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv);
                return portalCol * _DisplayMask + _InactiveColour * (1.0 - _DisplayMask);
            }
            ENDHLSL
        }
    }
}
