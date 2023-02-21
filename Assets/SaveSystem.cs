using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

//fredrik
//saves the highscore in your computer so it can be stored even if you close the game
//brackeys explains every step so i gave you the link to the video i followed
//https://www.youtube.com/watch?v=XOjd_qU2Ido
public static class SaveSystem
{
    public static void SavePlayer(GameManager player)
    {
        //creates a file containing the data stored in PlayerData
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.icd";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        //loads the data stored in the file created in the previous step
        string path = Application.persistentDataPath + "/player.icd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Savefile not found in" + path);
            return null;
        }
    }
}
