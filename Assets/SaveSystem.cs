using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//fredrik
//saves the highscore in your computer so it can be stored even if you close the game
//brackeys is way better at explaining than me but i tried
//i also gave you the link to the video i followed
//https://www.youtube.com/watch?v=XOjd_qU2Ido
public static class SaveSystem
{
    public static void SavePlayer(GameManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // creates a new binary formatter called formatter
        string path = Application.persistentDataPath + "/player.icd"; //makes a string called path that thanks to persistentDataPath makes a random path on the users operating system followed by /player.icd which will be where the data will be stored
        FileStream stream = new FileStream(path, FileMode.Create); 

        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
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
