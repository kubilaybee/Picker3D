using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stagee : MonoBehaviour
{
    public int TargetStageScore; // CURRENT BU SAYIYA ULASINCA STAGE SUCCESS
    public int CurrentStageScore;
    public TextMeshProUGUI ScoreText;
    public bool IsStageComplete;
    public bool IsStageFail;
    public Levell levelSa;
    public GameObject pickerStopper;
    // timer
    public float Timer = 4f;
    //public Coroutine checkFailCor;

    public void includeScore() 
    {
        if (IsStageComplete)
        {
            // devam etmek istyorsanýz týklayýn debug
            return;
        }
        StartCoroutine(checkStageFail());
        //checkFailCor=StartCoroutine(checkStage());
        CurrentStageScore++;
        updateScore();
        if (CurrentStageScore >= TargetStageScore)
        {
            StopAllCoroutines();
            IsStageFail = false;
            //StopCoroutine(checkFailCor);    // stop coroutine
            stageSuccess();
        }


    }

    public void stageSuccess()
    {
        //StopCoroutine(checkFailCor);    // stop coroutine
        IsStageComplete = true;
        IsStageFail = false;
        levelSa.GenerateNextStage();
    }

    public void stageFail()
    {
        //Debug.Log("FAIL");
        IsStageFail = true;
        IsStageComplete = false;
        //restart stage funcs
        restartStage();
    }
    public void restartStage()
    {
        if (!IsStageComplete)
        {
            Debug.Log("FAIL");
            GameManager.Instance.stageRestart(levelSa.currentStage.transform.position.z);
            Timer = 4f;
            pickStopperDatas();
            IsStageFail = false;
        }
        GameManager.Instance.resetPickerDatas();
    }

    void pickStopperDatas()
    {
        pickerStopper.GetComponent<BoxCollider>().enabled = true;
        pickerStopper.GetComponent<PickerStopper>().isEnable = false;
        //pickerStopper.SetActive(true);
    }

    void updateScore()
    {
        //StopCoroutine(checkFailCor);    // stop coroutine
        Timer = 4f;
        ScoreText.text = CurrentStageScore.ToString() + "/" + TargetStageScore.ToString();
    }

    // stage complete => stageFail or stageSuccess
   
    //void StageFail()
    //{
    //    IsStageFail = true;
    //    GameManager.Instance.resetStagePicker();
    //}

    //public IEnumerator checkStage()
    //{
    //    Debug.Log("test");
    //    yield return new WaitForSeconds(4f);
    //    Debug.Log("testFail");
    //    if (CurrentStageScore < TargetStageScore)
    //    {
    //        StageFail();
    //    }
    //    yield return null;
    //}

    public IEnumerator checkStageFail()
    {
        Timer = 4f;// GLOBAL DEGISKENE ATILMALI
        // HER TOP BASARILI SEKILDE GIRDIGINDA TIMER = 4 YAPILACAK
        while (Timer>=0)
        {
            if (!IsStageComplete)
            {
                Debug.Log(Timer);
                Timer--;
                yield return new WaitForSeconds(1f);
            }
        }
        if (!IsStageComplete)
        {
            stageFail();
        }
        
        yield return null;
    }
}
