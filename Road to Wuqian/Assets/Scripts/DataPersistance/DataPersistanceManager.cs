using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private FileDataHandler dataHandler;
    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;
    public static DataPersistanceManager instance { get; private set; }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        if (this.dataPersistanceObjects == null)
        {
            Debug.LogError("No IDataPersistance objects found.");
            return;
        }
        else
        {
            Debug.Log("Found " + dataPersistanceObjects.Count + " IDataPersistance objects.");
        }
        LoadGame();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("error, found more than 1 in scene"); // shld only have 1 at a time per scene
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //load any saved data from fila first using data handler
        this.gameData = dataHandler.Load();

        // if no data, initialize new game
        if(this.gameData == null)
        {
            Debug.Log("No saved data, creating new game with default values");
            NewGame();
        }
       
        //push loaded data to all scripts needed
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("Loaded coin count = " + gameData.coinCount);
    }

    public void SaveGame()
    {
        //push data to other scripts to update it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved coin count = " + gameData.coinCount);

        //save data to file using data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects); 
    }
}
