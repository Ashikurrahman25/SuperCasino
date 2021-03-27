using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static void Save(AllList purchase)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/GameData.hkxya";
        FileStream file = new FileStream(path, FileMode.Create);

        formatter.Serialize(file, purchase);
        file.Close();
    }

    public static AllList Load()
    {
        string path = Application.persistentDataPath + $"/GameData.hkxya";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            AllList geoloc = formatter.Deserialize(file) as AllList;
            file.Close();

            return geoloc;
        }
        else
        {
            AllList empty = new AllList();
            return empty;
        }
    }
}
