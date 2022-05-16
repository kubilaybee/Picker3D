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
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        picker = Instantiate(pickerPref);
        cineMachineVirtualCam.m_Follow = picker.transform;
        cineMachineVirtualCam.m_LookAt = picker.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
