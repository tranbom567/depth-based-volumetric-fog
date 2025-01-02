#include "DeclareDepthTexture.hlsl"
void radialCalculate_float(float2 UV, float2 Center, float NumSamples, float BlurWidth, float Intensity, float DepthThreSold,float DepthMax, out float4 OutputCol)
{
    float4 col = float4(0, 0, 0, 1);
    float2 ray = UV - Center.xy;
    for (int i = 0; i < NumSamples; i++)
    {
        float scale = 1 - BlurWidth * (float(i) / float(NumSamples - 1));
        float sceneDepthSample = SampleSceneDepth(float2(ray * scale + Center.xy)) / float(NumSamples);
        sceneDepthSample = Linear01Depth(sceneDepthSample, _ZBufferParams);
        if (sceneDepthSample > DepthThreSold && sceneDepthSample < DepthMax)
        {
            col.xyz += (sceneDepthSample) / float(NumSamples);
        }
    }

    OutputCol = (1 - col) * Intensity;
}