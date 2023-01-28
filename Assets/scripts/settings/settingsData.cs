using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class settingsData
{
    public bool fullscreen;
    public int QualityIndex;
    public float audioVolume;
    public int resWidth, resHeight;
    public int refreshRate;
    public int dropdownResIndex;
    //public int resInt;
    public bool mouseOn;
    public bool keyboardOn;

    public settingsData(settings settings)
    {
        fullscreen = settings.fullscreenbool;
        QualityIndex = settings.qualityIndexInt;
        audioVolume = settings.volumefloat;
        resWidth = settings.resulWidth;
        resHeight = settings.resuHeight;
        refreshRate = settings.resuRefresh;
        dropdownResIndex = settings.resuIndex;
        //resInt = settings.resuIndex;
        mouseOn = settings.mouseBool;
        keyboardOn = settings.keyboardBool;
    }
}
