using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [Header("File storage config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    private List<IData> dataObjects;
    private FileDataHandler dataHandler;

    public static DataManager instance { get; private set; } //get instance public but modify instance only in this class

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one data manager found.");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataObjects = FindAllIDataObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //Load saved game data from data handler
        this.gameData = dataHandler.Load();

        //initialise to a new game if no data can be loaded
        if (this.gameData == null)
        {
            Debug.Log("No data found. Initalising to new game.");
            NewGame();
        }

        //Send loaded data to other scripts that need it
        foreach (IData data in dataObjects)
        {
            data.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        //Pass data to other scripts for updates
        foreach (IData data in dataObjects)
        {
            data.SaveData(ref gameData);
        }

        //Save data to file using data handler
        dataHandler.Save(gameData);
    }

    public void RestartGame()
    {
        SaveGame();
        Debug.Log("Saved highscore = " + gameData.highscore);
        //looks for the name of a scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IData> FindAllIDataObjects()
    {
        //Finds all scripts that implement data interface in the scene (scripts extending from MonoBehaviour)
        IEnumerable<IData> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData>();

        return new List<IData>(dataObjects);
    }
}
