using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveTrainLastMap(TrainScript train)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + train.name + train.trainId + ".ur";
        FileStream stream = new FileStream(path, FileMode.Create);

        TrainData data = new TrainData(train);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static TrainData LoadTrainLastMap(TrainScript train)
    {
        string path = Application.persistentDataPath + "/" + train.name + train.trainId + ".ur";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TrainData data = formatter.Deserialize(stream) as TrainData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static void SaveMission(Map map)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + map.name + ".map";
        FileStream stream = new FileStream(path, FileMode.Create);

        MissionData data = new MissionData(map);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static MissionData LoadMission(Map map)
    {
        string path = Application.persistentDataPath + "/" + map.name + ".map";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MissionData data = formatter.Deserialize(stream) as MissionData;
            stream.Close();

            return data;
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            MissionData data = new MissionData(map);

            formatter.Serialize(stream, data);
            stream.Close();
            return data;
        }
    }
    public static void SavePlayerData(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerDataData data = new PlayerDataData(playerData);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerDataData LoadPlayerData(PlayerData playerData)
    {
        string path = Application.persistentDataPath + "/player.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerDataData data = formatter.Deserialize(stream) as PlayerDataData;
            stream.Close();

            return data;
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerDataData data = new PlayerDataData(playerData);

            formatter.Serialize(stream, data);
            stream.Close();
            return data;
        }
    }
}
