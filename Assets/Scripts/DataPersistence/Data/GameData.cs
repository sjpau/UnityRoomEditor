using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public Color color;
    public bool sticky;
}

[System.Serializable]
public class WallData
{
    public string name;
    public Color color;
}

[System.Serializable]
public class GameData 
{
 
    public int currentTool;
    public List<SpawnData> spawnDataHolder = new List<SpawnData>(); 
    public List<WallData> wallDataHolder = new List<WallData>(); 

    public GameData()
    {
        this.currentTool = 0;
        this.spawnDataHolder = null;
        this.wallDataHolder = null;
    }
}
