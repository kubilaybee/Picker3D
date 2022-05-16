using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levell : MonoBehaviour
{
    public List<GameObject> stages = new List<GameObject>();
    private int currentStageIndex;
    public Stagee currentStage;
    public bool isLevelSuccess;
    public LevelManager levelMng;

    private void Start()
    {
        generateStage();
    }

    public void GenerateNextStage()
    {
        currentStageIndex++;
        if (currentStageIndex == stages.Count)
        {
            // LEVEL SUCCESS OLUSTURULACAK STAGE KALMADI
            levelSuccess();
        }

        else
        {
            // NORMAL OYUN AKISI
            generateStage();
        }
    }

    // create a next stage
    public void generateStage()
    {
        GameObject tempGO = generateCurrentStage();
        tempGO.SetActive(true);
        tempGO.transform.SetParent(this.gameObject.transform);
        currentStage = tempGO.GetComponent<Stagee>();
        currentStage.levelSa = this;
    }


    GameObject generateCurrentStage()
    {
        Debug.Log(currentStageIndex);
        // old stage
        if (currentStageIndex!=0)
        {
            GameObject tempGO = stages[currentStageIndex - 1];
            //Destroy(Stages[CurrentStageIndex - 1],3);
            //Debug.Log(tempGO.GetType());  object
            tempGO.SetActive(false);
            // reset picker datas **
            GameManager.Instance.resetPickerDatas();
        }

        GameObject tempStage = Instantiate(stages[currentStageIndex], new Vector3(0, 0, (currentStageIndex * GameManager.Instance.stageOffset)), Quaternion.identity);

        return tempStage;
    }


    public void levelSuccess()
    {
        // level success
        isLevelSuccess = true;
        levelMng.generateNextLevel();
    }

}
