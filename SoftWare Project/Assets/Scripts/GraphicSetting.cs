using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicSetting : MonoBehaviour
{
    [SerializeField] TMP_Dropdown qualityDropDown;
    [SerializeField] TMP_Dropdown screenOptions;
    Resolution[] resolutions;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    float currentResRefreshRate;
    int currentResolutionIndex = 0;
    private void Awake()
    {
        qualityDropDown.value = QualitySettings.GetQualityLevel();
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        AddResolutions();
        screenOptions.value = 1;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void AddResolutions()
    {
        List<string> options = new List<string>();
        currentResRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length;i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetScreenOption(int fullScreenIndex)
    {
        if (fullScreenIndex >= 1)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;
    }
}