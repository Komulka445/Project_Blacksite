using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class Settings : MonoBehaviour
{
    public Camera Main;
    public PostProcessLayer MainLayer;
    public UniversalAdditionalCameraData cameraData;
    // Start is called before the first frame update
    void Start()
    {
        UniversalAdditionalCameraData cameraData = Main.GetComponent<UniversalAdditionalCameraData>();
        MainLayer = Main.GetComponent<PostProcessLayer>();
        //def p‰‰ll‰
        MainLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        /*if (MainLayer == null)
        {
            Debug.Log("null");
            return;
        }*/
    }
    public void ToggleFXAA()//togglaa p‰‰lle/pois
    {
        if(MainLayer.antialiasingMode == PostProcessLayer.Antialiasing.None)
        {
            cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
            MainLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
            PlayerPrefs.SetInt("FXAAEnabled", 1);
            PlayerPrefs.Save();
        }
        else if (MainLayer.antialiasingMode == PostProcessLayer.Antialiasing.FastApproximateAntialiasing)
        {
            cameraData.antialiasing = AntialiasingMode.None;
            MainLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
            PlayerPrefs.SetInt("FXAAEnabled", 0);
            PlayerPrefs.Save();
        }
    }
}
