using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystemSettings
{
    public static void SaveSettings(settings settings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/tabsettings.xd";
        FileStream stream = new FileStream(path, FileMode.Create);

        settingsData data = new settingsData(settings);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static settingsData LoadSettings()
    {
        string path = Application.persistentDataPath + "/tabsettings.xd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            settingsData data =  formatter.Deserialize(stream) as settingsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }

}
