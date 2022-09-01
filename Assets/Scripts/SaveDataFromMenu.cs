using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public static class SaveDataFromMenu
{
    public static void SaveMenuInfo(MenuInfo menuInfo)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/CartasticMenuData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, menuInfo);
        stream.Close();
    }

    public static MenuInfo LoadMenuInfo()
    {
        string path = Application.persistentDataPath + "/CartasticMenuData.txt";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            MenuInfo menuInfo = formatter.Deserialize(stream) as MenuInfo;
            stream.Close();
            return menuInfo;
        }
        else
        {
            //Debug.LogError("File not found in " + path);
            Debug.Log("File not found");
            return null;
        }
    }
}
