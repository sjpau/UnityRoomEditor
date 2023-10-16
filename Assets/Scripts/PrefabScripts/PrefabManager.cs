using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefabManager
{
    private static GameObject[] prefabs;

    public static void Initialize()
    {
        prefabs = new GameObject[6];
        //Hey, if it works it works...
        GameObject cube = Resources.Load<GameObject>("Prefabs/CubePrefab");
        GameObject sphere = Resources.Load<GameObject>("Prefabs/SpherePrefab");
        GameObject vase = Resources.Load<GameObject>("Prefabs/VaseBase");
        GameObject bed = Resources.Load<GameObject>("Prefabs/Bed");
        GameObject bookCase = Resources.Load<GameObject>("Prefabs/BookCase");
        GameObject chair = Resources.Load<GameObject>("Prefabs/Chair");
        prefabs[0] = cube;
        prefabs[1] = sphere;
        prefabs[2] = vase;
        prefabs[3] = bed;
        prefabs[4] = bookCase;
        prefabs[5] = chair;
        Debug.Log(prefabs);
    }

    public static GameObject GetPrefab(string prefabName)
    {
        foreach (GameObject prefab in prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
        }

        return null;
    }
}
