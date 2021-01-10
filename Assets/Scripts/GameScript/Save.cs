
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save
{
    private static BinaryFormatter formatter = new BinaryFormatter();
    private static string path = Application.persistentDataPath + "/score.save";

    static int mostRecentScore;
    public static void saveScore(int score)
    {
        if (isHighScore(score))
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
        mostRecentScore = score;
    }

    public static int readSave()
    {
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            int returnV = (int)formatter.Deserialize(stream);
            stream.Close();
            return returnV;
        }
        else
        {
            return 0;
        }
    }

    public static bool isHighScore(int score)
    {
        return readSave() < score;
    }

    public static int getMostRecentScore(){
        return mostRecentScore;
    }
}
