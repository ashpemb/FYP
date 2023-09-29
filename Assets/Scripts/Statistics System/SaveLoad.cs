using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{

    public static List<Stats> savedStats = new List<Stats>();

    public static void Save(Stats stats)
    {
        savedStats.Add(stats);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedStats.stats");
        Debug.Log("Stats saved to " + Application.persistentDataPath);
        bf.Serialize(file, SaveLoad.savedStats);
        file.Close();

        string path = Application.persistentDataPath +  "/savedStats" + stats.run + ".txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        if (stats.tutorialTime != 0)
        {
            if (StatsManager.instance.isInTutorial == true)
            {
                writer.WriteLine("Tutorial not finished");
                writer.WriteLine("Time taken in Tutorial : " + stats.tutorialTime.FloatToTimeInMMSS());
            }
            else
            {
                writer.WriteLine("Time taken in Tutorial : " + stats.tutorialTime.FloatToTimeInMMSS());
            }
        }
        else
        {
            
             writer.WriteLine("Tutorial not started");
            
        }
        for(int i = 1; i < stats.burgerTimes.Count + 1; ++i)
        {
            writer.WriteLine("Time taken for Burger" + i +  ": " + stats.burgerTimes[i-1].FloatToTimeInMMSS());
        }
        writer.WriteLine("Burgers made : " + stats.burgersCreated);
        writer.WriteLine("Incorrect orders made : " + stats.incorrectOrders);
        int avgFps = 0;
        for (int i = 0; i < stats.fps.Count; ++i)
        {
            avgFps += stats.fps[i];
        }
        avgFps = avgFps / stats.fps.Count;

        writer.WriteLine("Average Frames Per Second : " + avgFps);

        writer.Close();

    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedStats.stats"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedStats.stats", FileMode.Open);
            SaveLoad.savedStats = (List<Stats>)bf.Deserialize(file);
            file.Close();
        }
    }
}
