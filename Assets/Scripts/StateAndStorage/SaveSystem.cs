using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// The base data class for saving the current player state.
/// 
/// The player related functions are based on https://www.youtube.com/watch?v=XOjd_qU2Ido
/// Note: For more complex save options it is maybe worth to check out Easy Save: https://bit.ly/2BzgdXb
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
public static class SaveSystem
{
    // Note: The file name and ending ending could be freely chosen
    private const string playerFilePath = "/player.cv";

    public static void SavePlayer(Player player)
    {
        // Create the needed environment. 
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + playerFilePath;
        FileStream stream = new FileStream(path, FileMode.Create);

        // Create and write the data
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + playerFilePath;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
