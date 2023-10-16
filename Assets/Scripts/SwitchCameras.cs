using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    private GameObject[] gameCameras;
    public int currentCam = 0;


    private void Awake()
{
    gameCameras = new GameObject[] { MainCamera, Camera1, Camera2, Camera3 };
}

    private void TurnCameraOnIndex(GameObject[] cams, int index)
    {
        for (int i = 0; i < cams.Length; i++)
        {
            if (i == index)
            {
                cams[i].SetActive(true);
            }
            else
            {
                cams[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentCam = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentCam = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentCam = 2;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentCam = 3;

        }
        TurnCameraOnIndex(gameCameras, currentCam);
    }
}
