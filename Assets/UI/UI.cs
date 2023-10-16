using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using SimpleFileBrowser;

public class UI : MonoBehaviour
{
    public SwitchCameras camSwitcher;
    public Tools watcherTools;
    public SpawnsHolder spawnsHolder;
    public WallPersist wallDataHolder;
    public DataPersistenceManager persistenceManager;

    private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            Toggle tSticky = root.Q<Toggle>("TSticky");
            tSticky.value = true;
            tSticky.RegisterValueChangedCallback(OnToggleValueChanged);

            Button bImport = root.Q<Button>("BImport"); 
            Button bExport = root.Q<Button>("BExport"); 
            Button bSave = root.Q<Button>("BSave");
            Button bRecover = root.Q<Button>("BRecover");
            Button bNew = root.Q<Button>("BNew");
            
            Button bCam1 = root.Q<Button>("BCam1");
            Button bCam2 = root.Q<Button>("BCam2");
            Button bCam3 = root.Q<Button>("BCam3");
            Button bCamFree = root.Q<Button>("BCamFree");

            Button bSpawn = root.Q<Button>("BSpawn");
            Button bDelete = root.Q<Button>("BDelete");
            Button bSelect = root.Q<Button>("BSelect");
            Button bChangeColor = root.Q<Button>("BChangeColor");
            
            Button bObjCube = root.Q<Button>("BObjCube");
            Button bObjSphere = root.Q<Button>("BObjSphere");
            Button bObjBed = root.Q<Button>("BObjBed");
            Button bObjChair = root.Q<Button>("BObjChair");
            Button bObjShelf = root.Q<Button>("BObjShelf");
            Button bObjVase = root.Q<Button>("BObjVase");
            
            Button cRed = root.Q<Button>("cRed");
            Button cOrange = root.Q<Button>("cOrange");
            Button cYellow = root.Q<Button>("cYellow");
            Button cGreen = root.Q<Button>("cGreen");
            Button cBlue = root.Q<Button>("cBlue");
            Button cDarkBlue = root.Q<Button>("cDarkBlue");
            Button cPurple = root.Q<Button>("cPurple");

            bCam1.clicked += () => camSwitcher.currentCam = 1;
            bCam2.clicked += () => camSwitcher.currentCam = 2;
            bCam3.clicked += () => camSwitcher.currentCam = 3;
            bCamFree.clicked += () => camSwitcher.currentCam = 0;
            
            bSpawn.clicked += () => watcherTools.current = watcherTools.SPAWN;
            bDelete.clicked += () => watcherTools.current = watcherTools.DELETE;
            bSelect.clicked += () => watcherTools.current = watcherTools.SELECT;
            bChangeColor.clicked += () => watcherTools.current = watcherTools.COLOR;
            
            bObjCube.clicked += () => watcherTools.prefabSpawnName = "CubePrefab";
            bObjSphere.clicked += () => watcherTools.prefabSpawnName = "SpherePrefab";
            bObjBed.clicked += () => watcherTools.prefabSpawnName = "Bed";
            bObjChair.clicked += () => watcherTools.prefabSpawnName = "Chair";
            bObjShelf.clicked += () => watcherTools.prefabSpawnName = "BookCase";
            bObjVase.clicked += () => watcherTools.prefabSpawnName = "VaseBase";
            
            cRed.clicked += () => watcherTools.prefabColorToChangeHex = "#BD4242";
            cOrange.clicked += () => watcherTools.prefabColorToChangeHex = "#FFA500";
            cYellow.clicked += () => watcherTools.prefabColorToChangeHex = "#FEFB00";
            cGreen.clicked += () => watcherTools.prefabColorToChangeHex = "#0FA01A";
            cBlue.clicked += () => watcherTools.prefabColorToChangeHex = "#24BAF9";
            cDarkBlue.clicked += () => watcherTools.prefabColorToChangeHex = "#002291";
            cPurple.clicked += () => watcherTools.prefabColorToChangeHex = "#710078";

            bRecover.clicked += () => OnClickRecover();
            bSave.clicked += () => OnClickSave();
            bNew.clicked += () => OnClickNew();
            bImport.clicked += () => OnClickImport();
            bExport.clicked += () => OnClickExport();
        }
    private void OnSaveSuccess(string[] paths)
    {
        string filePath = paths[0];

         if (!string.IsNullOrEmpty(filePath))
        {
            Debug.Log("File Saved: " + filePath);
            string directoryPath = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            persistenceManager.fileHandler.SetFilePath(directoryPath, fileName);
            persistenceManager.dataPersistenceObjects = persistenceManager.FindAllDataPersistenceObjects();
            OnClickSave();
            persistenceManager.Save();
        }
    }

    private void OnLoadSuccess(string[] paths)
    {
        string filePath = paths[0];
         if (!string.IsNullOrEmpty(filePath))
        {
            persistenceManager.New();
            string directoryPath = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            Debug.Log("Directory Path: " + directoryPath);
            Debug.Log("File Name: " + fileName);

            persistenceManager.fileHandler.SetFilePath(directoryPath, fileName);
            persistenceManager.dataPersistenceObjects = persistenceManager.FindAllDataPersistenceObjects();
            persistenceManager.Load();
            wallDataHolder.recovered = false;
            spawnsHolder.recovered = false;
            OnClickRecover();
        } 


    }

    private void OnCancel()
    {
        Debug.Log("Operation canceled.");
    }

    private void OnClickExport()
    {
        FileBrowser.ShowSaveDialog(OnSaveSuccess, OnCancel, FileBrowser.PickMode.FilesAndFolders, false, "ykaeeditor", "comfy", "Export", "Save");
    } 

    private void OnClickImport()
    {
        FileBrowser.ShowSaveDialog(OnLoadSuccess, OnCancel, FileBrowser.PickMode.FilesAndFolders, false, "ykaeeditor", "comfy", "Import", "Load");
    } 

    private void OnClickNew()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OnClickSave()
    {
        spawnsHolder.CacheData();
        wallDataHolder.CacheData();
    }

    private void OnClickRecover()
    {
        spawnsHolder.RecoverObjects();
        wallDataHolder.RecoverWalls();
    }

    private void OnToggleValueChanged(ChangeEvent<bool> evt)
    {
        bool isSticky = evt.newValue;
         watcherTools.attachNext = isSticky; 

    if (!isSticky)
    {
        watcherTools.attachNext = false;
    }

    }
}

