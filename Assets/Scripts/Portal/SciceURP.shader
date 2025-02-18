Shader "Custom/SliceOnly"
{
    Properties
    {
        sliceNormal ("Slice Normal", Vector) = (0,0,1,0)
        sliceCentre ("Slice Centre", Vector) = (0,0,0,0)
        sliceOffsetDst ("Slice Offset", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 100

        Pass
        {
            Name "Slice"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float4 sliceNormal;
            float4 sliceCentre;
            float sliceOffsetDst;

            struct Attributes
            {
                float4 vertex : POSITION;
            };

            struct Varyings
            {
                float4 position : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.position = TransformObjectToHClip(IN.vertex);
                OUT.worldPos = TransformObjectToWorld(IN.vertex);
                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                float3 sn = normalize(sliceNormal.xyz);
                float3 sc = sliceCentre.xyz;
                float3 adjustedCentre = sc + sn * sliceOffsetDst;
                float3 offsetToSliceCentre = adjustedCentre - IN.worldPos;
                clip(dot(offsetToSliceCentre, sn));

                return half4(1, 1, 1, 1); // Просто белый цвет
            }
            ENDHLSL
        }
    }
}
