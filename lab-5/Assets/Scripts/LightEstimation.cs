using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Rendering;

public class LightEstimation : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager cameraManager;

    private Light targetLight;

    // Start is called before the first frame update
    void Start()
    {
        targetLight = GetComponent<Light>();    
    }

    private void OnEnable()
    {
        cameraManager.frameReceived += ProcessFrame;
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= ProcessFrame;
    }

    private void ProcessFrame(ARCameraFrameEventArgs args)
    {
        ARLightEstimationData data = args.lightEstimation;

        if (data.averageBrightness.HasValue)
        {
            targetLight.intensity = data.averageBrightness.Value;
        }

        if (data.mainLightIntensityLumens.HasValue)
        {
            targetLight.intensity = data.mainLightIntensityLumens.Value;
        }

        if (data.averageColorTemperature.HasValue)
        {
            targetLight.colorTemperature = data.averageColorTemperature.Value;
        }

        if (data.colorCorrection.HasValue)
        {
            targetLight.color = data.colorCorrection.Value;
        }

        if (data.mainLightColor.HasValue)
        {
            targetLight.color = data.mainLightColor.Value;
        }

        if (data.ambientSphericalHarmonics.HasValue)
        {
            RenderSettings.ambientMode = AmbientMode.Skybox;
            RenderSettings.ambientProbe = data.ambientSphericalHarmonics.Value;
        }
    }
}
