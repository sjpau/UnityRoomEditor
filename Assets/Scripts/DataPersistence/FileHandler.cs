using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileHandler 
{
    
    private string dataStorePath = "";
    private string dataFileName = "";

    public FileHandler(string dataStorePath, string dataFileName)
    {
        this.dataStorePath = dataStorePath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataStorePath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string toLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        toLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<GameData>(toLoad);
            }
            catch (Exception e)
            {
                Debug.Log("Error reading: " + fullPath + "\n" + e);
            }

        }
        return loadedData;

    }

    public string GetFilePath()
    {
        string fullPath = Path.Combine(dataStorePath, dataFileName);
        return fullPath;
        
    }
    
    public void SetFilePath(string outsideDir, string dataFileName)
    {
        this.dataStorePath = outsideDir;
        this.dataFileName = dataFileName;
    } 

    public void Save(GameData data)
    {
        string fullPath =  GetFilePath();
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            
            string toStore = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(toStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error saving to file: " + fullPath + "\n" + e);
        }
    }
}
