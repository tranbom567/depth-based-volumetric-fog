using System;
using UnityEngine;
[Serializable]
public class VolumetricLightSettings
{
    [Header("Quality")]
    [Range(0.1f, 1f)]
    public float renderScale=0.5f;
    [Header("Color")]
    [Range(0f, 1f)]
    public float intensity=0.5f;
    [Range(0f, 1f)]
    public float radiusWidth = 0.85f;
}
