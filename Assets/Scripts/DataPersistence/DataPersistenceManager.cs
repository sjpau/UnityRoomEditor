using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    public List<IDataPersistence> dataPersistenceObjects;
    public FileHandler fileHandler;
    public static DataPersistenceManager instance {get; private set;}

    private void Start()
    {
        this.fileHandler = new FileHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one data persitent manager.");
        }
        instance = this;
    }

    public void New()
    {
        this.gameData = new GameData();
    }

    public void Load()
    {
        this.gameData = fileHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No save state found. Creating new.");
            New();
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void Save()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
            Debug.Log(dataPersistenceObj);
        }
        fileHandler.Save(gameData);
    }

    public List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
