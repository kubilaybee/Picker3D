using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    #region Picker
    [Header("Picker Datas")]
    public GameObject pickerPref;
    public GameObject picker;
    #endregion
    #region CinemachineDatas
    [Header("Cinemachine Datas")]
    public CinemachineVirtualCamera cineMachineVirtualCam;
    #endregion
    #region LevelDatas
    [Header("Levels")]
    public int currentLevelNumber;
    public float stageOffset;
    #endregion

    #region Collectable
    public GameObject CollectablePrefab;

    public int collectableStageSize;
    public float spawnRadius;
    #endregion
    [Header("CollectableDatas")]
    public GameObject stagePref;

    #region Score
    [Header("Score Datas")]
    public int score;   // fix it
    public int levelSuccessPoint;
    #endregion

    #region GameState
    public enum GameStates { None,Start,GamePlay,LevelSuccess,LevelFail}
    [Header("GameState")]
    public GameStates CurrentGameState;
    #endregion

    #region CollectableObjectPoolSystem
    [Header("CollectableObjectPool")]
    public GameObject collectablePoolArea;
    public List<GameObject> poolObjectList = new List<GameObject>();
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    // pool object
    public void createPool(int poolObjectSize)
    {
        //GameObject tempSpawnPosObj = collectablePoolArea.transform.GetChild(5).gameObject;
        //Vector3 tempSpawnPos = tempSpawnPosObj.transform.position;
        for (int i = 0; i < poolObjectSize; i++)
        {
            Vector3 tempPos = collectablePoolArea.transform.GetChild(5).gameObject.transform.position;
            GameObject tempPoolObj = Instantiate(CollectablePrefab, new Vector3(tempPos.x,tempPos.y+(i+1),tempPos.z), Quaternion.identity);
            poolObjectList.Add(tempPoolObj);
        }
    }


    // change gameState 
    public void changeGameState(GameStates gameState)
    {
        CurrentGameState = gameState;

        switch (gameState)
        {
            case GameStates.None:
                break;
            case GameStates.Start:
                UIManager.Instance.createUIElement(UIManager.UIElementsID.UIStart);
                break;
            case GameStates.GamePlay:
                UIManager.Instance.createUIElement(UIManager.UIElementsID.UIGamePlay);
                break;
            case GameStates.LevelSuccess:
                UIManager.Instance.createUIElement(UIManager.UIElementsID.UILevelSuccess);
                break;
            case GameStates.LevelFail:
                UIManager.Instance.createUIElement(UIManager.UIElementsID.UILevelFail);
                break;
            default:
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // pool object area create
        Instantiate(collectablePoolArea);
        // start game
        changeGameState(GameStates.Start);
        // picker datas
        picker = Instantiate(pickerPref);
        cineMachineVirtualCam.m_Follow = picker.transform;
        cineMachineVirtualCam.m_LookAt = picker.transform;
        
    }

    public void stageRestart(float nextPosZ)
    {
        picker.transform.position = new Vector3(0,0, nextPosZ);
    }

    // stage fail 
    //public void resetStagePicker()
    //{
    //    picker.transform.position = new Vector3(0, 0, picker.transform.position.z - stageOffset);
    //    resetPickerDatas();
    //}

    // next level picker datas 
    public void resetPickerDatas()
    {
        picker.GetComponent<PickerMovement>().CharacterSpeed = 6;
        picker.GetComponent<PickerMovement>().TouchRotationSpeed = 1.2f;
        picker.GetComponent<PickerMovement>().forceToBall = false;
        //picker.transform.position = Vector3.zero;
    }

    public void stopTheGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void setScoreTxt(Text scoreText)
    {
        scoreText.text = "Score: " + score;
    }

    public void setLevelTxt(Text levelText)
    {
        levelText.text = "LEVEL - " + currentLevelNumber;
    }
}
