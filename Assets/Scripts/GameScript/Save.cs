
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save
{
    private static BinaryFormatter formatter = new BinaryFormatter();
    private static string path = Application.persistentDataPath + "/score.save";
    public static void saveScore(int score)
    {
        FileStream stream;
        if (File.Exists(path))
        {
            stream = new FileStream(path, FileMode.Append);
        }
        else
        {
            stream = new FileStream(path, FileMode.Create);
        }

        formatter.Serialize(stream, score);
        stream.Close();
    }

    public static string readSave()
    {
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            string returnV = (string)formatter.Deserialize(stream);
            stream.Close();
            return returnV;
        }
        else
        {
            return null;
        }
    }

    public static bool isHighScore(){
        return false;
    }
}
