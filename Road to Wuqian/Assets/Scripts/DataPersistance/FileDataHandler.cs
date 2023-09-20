using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        //use path.combine to link file path just in case diff OS
        string fullPath = Path.Combine(Application.persistentDataPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //load serialized data
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception x)
            {
                Debug.LogError("error occured trying to load data from file: " + fullPath + "\n" + x);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        //use path.combine to link file path just in case diff OS
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create directory path just in case not exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize game data object into text file
            string dataToStore = JsonUtility.ToJson(data,true);

            //write data to text file
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception x)
        {
            Debug.LogError("error occured when saving data to file:" + fullPath + "\n" + x);
        }
    }
}
