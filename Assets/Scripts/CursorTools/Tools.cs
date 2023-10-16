using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour, IDataPersistence
{
    public int SELECT = 0;
    public int SPAWN = 1;
    public int DELETE = 2;
    public int COLOR = 3;
    public int current = 0;
    public bool attachNext;
    public string prefabSpawnName = "CubePrefab";
    public string prefabColorToChangeHex;

    public void LoadData(GameData data)
    {
        this.current = data.currentTool;
    }

    public void SaveData(ref GameData data)
    {
        data.currentTool = this.current;
    }

    void Start()
    {
        PrefabManager.Initialize();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Tool SELECT");
            current = SELECT;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Tool SPAWN");
            current = SPAWN;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Tool DELETE");
            current = DELETE;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Tool DELETE");
            current = COLOR;
        }
    }
}
