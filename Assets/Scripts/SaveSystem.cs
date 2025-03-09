using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static TextAsset textAsset;
    static string filename = Application.dataPath + "/test.csv";
    public static void Save(PlayerDataManager dataManager)
    {
        TextWriter textWriter = new StreamWriter(filename, false);
        textWriter.WriteLine("Num of Owned Plot"); // "," = next block in csv file
        textWriter.WriteLine(dataManager.numOfOwnedPlot);

        textWriter.WriteLine("Owned Money");
        textWriter.WriteLine(dataManager.money);

        textWriter.WriteLine("Upgrade Rate");
        textWriter.WriteLine(dataManager.upgrade);

        textWriter.WriteLine("Num of Worker");
        textWriter.WriteLine(dataManager.workerOwn);

        textWriter.WriteLine("Tomato Own,Blueberry Own,Strawberry Own,Cow Own");
        textWriter.WriteLine(StashManager.instance.tomatoCount + "," + StashManager.instance.blueberryCount + "," + StashManager.instance.strawberryCount + "," + StashManager.instance.cowCount);
        textWriter.Write("Plot ID, Type Of Crop, Growing Current Time, Num Of Crop, Rotten Current Time\n");
        for (int i = 0; i < PlayerDataManager.Instance.plantedPlots.Count; i++)
        {
            textWriter.WriteLine(dataManager.plantedPlots[i].plotID + "," + dataManager.CropStateManagers[i].type + "," + dataManager.CropStateManagers[i].growingState.currentTime
                    + "," + dataManager.CropStateManagers[i].wholeState.numOfCrop + "," + dataManager.CropStateManagers[i].rottenState.currentTime);
        }

       
        textWriter.Close();
        
        Debug.Log("-=-SAVE-=-");
    }
    public static string[] Load()
    {
        if (File.Exists(filename))
        {
            TextReader textReader = new StreamReader(filename);
            string[] data = textReader.ReadToEnd().Split(new string[] { ",", "\n" }, System.StringSplitOptions.None); // split words by "," & "\n"
           // int length = data.Length - 1;
            //num of owned plot
           // PlayerDataManager.Instance.numOfOwnedPlot = Convert.ToInt16(data[1]);
            //

            textReader.Close();
            Debug.Log("-=-LOAD-=-");
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + filename);       
            return null;
        }
    }
}
