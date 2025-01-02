using UnityEngine;
[ExecuteInEditMode]
public class VolumetricDepthRuntimeCallculate : MonoBehaviour
{
    [SerializeField]
    private Material volumetricLightMat;
    [SerializeField]
    [Range(0f,1f)]
    private float intensity=0.5f;
    [SerializeField]
    [Range(0f,1f)]
    private float radialBlur=0.85f;
    [SerializeField]
    private Color sunColor;
    [SerializeField]
    private float depthThreSold=0.9f;
    private Transform mainCamTrans;
    void Start()
    {
        sunColor = RenderSettings.sun.color;
        mainCamTrans=Camera.main.transform;
    }

   
    void Update()
    {
        if (!volumetricLightMat)
            return;
        volumetricLightMat.SetColor("_SunColor", sunColor);
        volumetricLightMat.SetFloat("_BlurWidth", radialBlur);
        volumetricLightMat.SetFloat("_Intensity", intensity);
        volumetricLightMat.SetFloat("_DepthThreSold",depthThreSold);
        setCenterOfSun();
    }
    private void setCenterOfSun()
    {
        var sunWorldPos = mainCamTrans.position + RenderSettings.sun.transform.forward;
        var sunViewportPoint=Camera.main.WorldToViewportPoint(sunWorldPos);
        volumetricLightMat.SetVector("_Center", sunViewportPoint);
    }
}
