using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsHolder : MonoBehaviour, IDataPersistence
{  

    public List<Transform> spawnedObjects = new List<Transform>(); 
    private SpawnData spawnData;
    public GameObject spawn;
    public Tools cursorTools;
    public List<SpawnData> spawnDataHolder = new List<SpawnData>(); 
    public bool recovered = false;

    public void LoadData(GameData data)
    {
        this.spawnDataHolder = data.spawnDataHolder;
    }

    public void SaveData(ref GameData data)
    {
        data.spawnDataHolder = this.spawnDataHolder;
    }

    public void RecoverObjects()
    {
        if (!recovered)
        {
        if (this.spawnDataHolder != null)
        {
            Debug.Log("Previous layout found. Objects found: " + this.spawnDataHolder.Count);
            foreach (SpawnData i in this.spawnDataHolder)
            {
                    Debug.Log("Trying to recover an object.");
                    string prefabName = i.name;
                    Debug.Log("Found: " + prefabName);
                    GameObject prefabToInstantiate = PrefabManager.GetPrefab(prefabName);
                    Debug.Log("Acquired prefab: " + prefabToInstantiate);

                    Vector3 pos = i.position;
                    Quaternion rot = i.rotation;
                    Vector3 scale = i.scale;

                    GameObject instantiatedPrefab = Instantiate(prefabToInstantiate, pos, rot);
                    Mutate prefabMutate = instantiatedPrefab.GetComponent<Mutate>();
                    if (i.sticky)
                    {
                        prefabMutate.attach = true;
                    }
                    Debug.Log("Instantiated: " + instantiatedPrefab);
                    instantiatedPrefab.transform.localScale = scale;
                    instantiatedPrefab.GetComponent<Renderer>().material.color = i.color;
                    instantiatedPrefab.name = prefabName;
                    instantiatedPrefab.transform.parent = spawn.transform;
            }     
            this.recovered = true; 
        }
        else
        {
            Debug.Log("No previous layout found.");
        }
        }
    }

    public void CacheData()
    {
        this.spawnedObjects.Clear();
        this.spawnDataHolder.Clear();
        foreach (Transform child in transform)
        {
            this.spawnedObjects.Add(child);
            Debug.Log("Added to spawned objects: " + child);

            SpawnData toHold = new SpawnData();
            toHold.name = child.name;
            toHold.position = child.position;
            toHold.rotation = child.rotation;
            toHold.scale = child.localScale;
            toHold.color = child.GetComponent<Renderer>().material.color;
            toHold.sticky = child.GetComponent<Mutate>().attach;
            this.spawnDataHolder.Add(toHold);
        } 
            Debug.Log(this.spawnedObjects.Count);
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
          CacheData(); 
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            RecoverObjects();
        }
    }
}