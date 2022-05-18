using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    public List<GameObject> Levels = new List<GameObject>();
    public float stageOffset;
    #endregion
    #region Collectable
    public GameObject CollectablePrefab;

    public int collectableStageSize;
    public float spawnRadius;
    #endregion
    public GameObject stagePref;

    #region Score
    [Header("Score Datas")]
    public int score;   // fix it
    public int levelSuccessPoint;
    #endregion

    #region GameState
    public enum GameStates { None,Start,GamePlay,LevelSuccess,LevelFail}
    public GameStates CurrentGameState;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    /**
    //**
    public void ChangeGameState(GameStates gameState)
    {
        CurrentGameState = gameState;

        switch (gameState)
        {
            case GameStates.None:
                break;
            case GameStates.MainMenu:
                UIManager.Instance.CreateUIElement(UIManager.UIElementsID.UIMainMenu);
                CameraFollow.Instance.ChangeCameraState(CameraFollow.CameraType.MainMenu);
                CameraFollow.Instance.SetTarget(CurrentCharacter);
                CurrentCharacter.GetComponent<Character>().SetCharacterAnim(Character.AnimationTypes.Idle);
                AppValueController.Instance.FakeHealt = AppValueController.Instance.HealtBoughtCounter + AppValueController.Instance.DefaultHealt;
                AppValueController.Instance.FakeDiamondValue = AppValueController.Instance.DiamondValue + (AppValueController.Instance.EarningBoughtCounter * AppValueController.Instance.EarningValueOffset);
                AppValueController.Instance.FakeDiamondFiveValue = AppValueController.Instance.DiamondFiveValue + (AppValueController.Instance.EarningBoughtCounter * AppValueController.Instance.EarningValueOffset);
                break;
            case GameStates.Gameplay:
                UIManager.Instance.CreateUIElement(UIManager.UIElementsID.UIGameplay);
                CameraFollow.Instance.ChangeCameraState(CameraFollow.CameraType.Gameplay);
                CurrentCharacter.GetComponent<Character>().SetCharacterAnim(Character.AnimationTypes.Running);
                break;
            case GameStates.Paused:
                break;
            case GameStates.LevelSuccess:
                CameraFollow.Instance.ChangeCameraState(CameraFollow.CameraType.LevelSuccess);
                StartCoroutine(UILevelSuccessPanelOpen());
                StartCoroutine(LevelSuccessCharacterRotator());

                break;
            case GameStates.LevelFailed:
                CameraFollow.Instance.ChangeCameraState(CameraFollow.CameraType.LevelFailed);
                CameraFollow.Instance.SetTarget(CurrentCharacter.GetComponent<Character>().Hip.gameObject);
                StartCoroutine(UILevelFailPanelOpen());

                break;
        }
    }
    //**

    public GameObject GenerateCharacter()
    {
        CurrentCharacter = Instantiate(CharacterPrefab);
        CurrentCharacter.transform.position = CharacterSpawnPos;
        CurrentCharacter.GetComponent<Character>().SetCharacterAnim(Character.AnimationTypes.Idle);
        return CurrentCharacter;
    }
    //** FIX
    public IEnumerator UILevelFailPanelOpen()
    {
        yield return new WaitForSeconds(AppValueController.Instance.UILevelFailPanelOpenTime);
        UIManager.Instance.CreateUIElement(UIManager.UIElementsID.UILevelFailed);
    }
    //** FIX
    public IEnumerator UILevelSuccessPanelOpen()
    {
        yield return new WaitForSeconds(AppValueController.Instance.UILevelSuccessPanelOpenTime);
        UIManager.Instance.CreateUIElement(UIManager.UIElementsID.UILevelSuccess);
    }
    **/
    public void changeGameState(GameStates gameState)
    {
        CurrentGameState = gameState;

        switch (gameState)
        {
            case GameStates.None:
                break;
            case GameStates.Start:
                break;
            case GameStates.GamePlay:
                break;
            case GameStates.LevelSuccess:
                break;
            case GameStates.LevelFail:
                break;
            default:
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
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
        picker.GetComponent<PickerMovement>().CharacterSpeed = 5;
        picker.GetComponent<PickerMovement>().TouchRotationSpeed = 1.2f;
        picker.GetComponent<PickerMovement>().forceToBall = false;
        //picker.transform.position = Vector3.zero;
    }
}
