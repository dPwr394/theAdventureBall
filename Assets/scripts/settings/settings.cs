using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    Resolution[] res;
    public TMPro.TMP_Dropdown resDropdown;
    public Slider audioSlider;
    public Toggle fullscreenToggle;
    public Toggle keyboardToggle;
    public Toggle mouseToggle;
    public TMPro.TMP_Dropdown graphicsDropdown;
    public AudioMixer audioMixer;
    public bool fullscreenbool;
    public int qualityIndexInt = 4;
    public float volumefloat;
    public int resulWidth, resuHeight;
    public int resuIndex;
    public int resuRefresh;
    public bool mouseBool;
    public bool keyboardBool;
    private void Start()
    {
        res = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + "x" + res[i].height + "@" + res[i].refreshRate + "hz";
            options.Add(option);

            if (res[i].width == Screen.currentResolution.width && res[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
                resuIndex = currentResIndex;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();

        loadSettingsData();
    }

    public void SetVol(float vol) //set volume
    {
        audioMixer.SetFloat("MasterVol", vol);
        volumefloat = vol;
    }

    public void SetQuality(int indexQuality) //set quality level
    {
        QualitySettings.SetQualityLevel(indexQuality);
        qualityIndexInt = indexQuality;
    }

    public void onFullscreen(bool setfull) //set Fullscreen
    {
        Screen.fullScreen = setfull;
        fullscreenbool = setfull;
    }

    public void SetRes(int SetResIndex) 
    {
        Resolution resulotion = res[SetResIndex];

        Screen.SetResolution(resulotion.width, resulotion.height, Screen.fullScreen);
        resulWidth = resulotion.width;
        resuHeight = resulotion.height;
        resuRefresh = resulotion.refreshRate;

        resuIndex = resDropdown.value;
    }

    public void SetKeyboard(bool board)
    {
        if (board)
        {
            keyboardBool = true;

            mouseToggle.isOn = false;
            keyboardToggle.isOn = true;

        }
        else{
            keyboardBool = false;

            mouseToggle.isOn = true;
            keyboardToggle.isOn = false;

        }
    }

    public void SetMouse(bool mouse) 
    {
        if (mouse)
        {
            mouseBool = true;

            keyboardToggle.isOn = false;
            mouseToggle.isOn = true;
        }
        else
        {
            mouseBool = false;

            keyboardToggle.isOn = true;
            mouseToggle.isOn = false;

        }
    }
    public void saveSettingsData()
    {
        saveSystemSettings.SaveSettings(this);
    }
    public void loadSettingsData()
    {

        settingsData data = saveSystemSettings.LoadSettings();

        Resolution selectedRes = new Resolution();
        selectedRes.width = data.resWidth;
        selectedRes.height = data.resHeight;
        selectedRes.refreshRate = data.refreshRate;


        Screen.SetResolution(selectedRes.width, selectedRes.height, data.fullscreen);

        //QualitySettings.SetQualityLevel(data.QualityIndex);
        //audioMixer.SetFloat("MasterVol", data.audioVolume);


        //SetRes(data.resInt);
        SetQuality(data.QualityIndex);
        SetVol(data.audioVolume);

        audioSlider.value = data.audioVolume;
        fullscreenToggle.isOn = data.fullscreen;
        graphicsDropdown.value = data.QualityIndex;
        resDropdown.value = data.dropdownResIndex;
        keyboardToggle.isOn = data.keyboardOn;
        mouseToggle.isOn = data.mouseOn;
        //resDropdown.value = currentResIndex;
        //resDropdown.RefreshShownValue();

    }

}
