using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public WorldPoint3D worldPoint;
    public Tools cursorTools;
    public GameObject spawn;


    void Start()
    {
        worldPoint = GetComponent<WorldPoint3D>();
    }

    void Update()
    {
        if (cursorTools.current == cursorTools.SPAWN)
        {
            Vector3 mousePosition = worldPoint.CursorToWorldPoint3D();
            if (Input.GetMouseButtonDown(0) && mousePosition != Vector3.zero)
            {

                Debug.Log(mousePosition);
                GameObject current = Instantiate(PrefabManager.GetPrefab(cursorTools.prefabSpawnName), mousePosition, Quaternion.identity);
                current.name = cursorTools.prefabSpawnName;
                Mutate prefabMutate = current.GetComponent<Mutate>();
                if (cursorTools.attachNext)
                {

                    prefabMutate.attach = true;
                }
                else
                {
                    prefabMutate.attach = false;
                }
                current.transform.parent = spawn.transform;
                Debug.Log("Created new object.");
            }    
        }
    }
}
