using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPersist : MonoBehaviour, IDataPersistence
{
    private WallData wallData;
    public List<WallData> wallDataHolder = new List<WallData>(); 
    public bool recovered = false;
    public Transform walls;

    public void LoadData(GameData data)
    {
        this.wallDataHolder = data.wallDataHolder;
    }

    public void SaveData(ref GameData data)
    {
        data.wallDataHolder = this.wallDataHolder;
    }

    public void RecoverWalls()
        {
            if (!recovered)
            {
                Debug.Log("Wall holder: " + this.wallDataHolder);
                if (this.wallDataHolder != null)
                {
                    Debug.Log("Trying to recover walls." + this.wallDataHolder.Count);
                    foreach (WallData i in this.wallDataHolder)
                    {
                        Debug.Log(i);
                        GameObject targetWall = GameObject.Find(i.name);
                        Debug.Log("Found wall: " + targetWall);
                        targetWall.GetComponent<Renderer>().material.color = i.color;

                    }     
                    this.recovered = true; 
                }
                else
                {
                    Debug.Log("No previous wall config found.");
                }
            }
        }
  
    public void CacheData()
    {
        this.wallDataHolder.Clear();
        foreach (Transform child in walls)
        {
            WallData toHold = new WallData();
            toHold.name = child.name;
            toHold.color = child.GetComponent<Renderer>().material.color;
            this.wallDataHolder.Add(toHold);
        } 
    } 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            CacheData();
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            RecoverWalls();
            Debug.Log("Walls as children found: " +  walls.childCount);
        }
    }
}
