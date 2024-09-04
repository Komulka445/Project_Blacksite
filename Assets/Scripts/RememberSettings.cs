using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class RememberSettings : MonoBehaviour
{
    public Camera Main;
    public PostProcessLayer MainLayer;
    public UniversalAdditionalCameraData cameraData;
    public int FXAAValue;
    // Start is called before the first frame update
    void Start()
    {
        UniversalAdditionalCameraData cameraData = Main.GetComponent<UniversalAdditionalCameraData>();
        MainLayer = Main.GetComponent<PostProcessLayer>();
        FXAAValue = PlayerPrefs.GetInt("FXAAEnabled");
        //Debug.Log(FXAAValue);
        if(FXAAValue == 0)
        {
            cameraData.antialiasing = AntialiasingMode.None;
            MainLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
        }
        else if (FXAAValue == 1)
        {
            cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
            MainLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        }
    }
}
