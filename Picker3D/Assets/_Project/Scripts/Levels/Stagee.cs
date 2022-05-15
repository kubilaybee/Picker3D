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
    public Levell santaLevel;
    //public Coroutine checkFailCor;

    public void includeScore() 
    {
        if (IsStageComplete)
        {
            return;
        }
        //checkFailCor=StartCoroutine(checkStage());
        CurrentStageScore++;
        updateScore();
        if (CurrentStageScore >= TargetStageScore)
        {
            //StopCoroutine(checkFailCor);    // stop coroutine
            stageSuccess();
        }


    }

    public void stageSuccess()
    {
        //StopCoroutine(checkFailCor);    // stop coroutine
        IsStageComplete = true;
        santaLevel.GenerateNextStage();
    }

    void updateScore()
    {
        //StopCoroutine(checkFailCor);    // stop coroutine
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
    //    new WaitForSeconds(4f);
    //    Debug.Log("testFail");
    //    if (CurrentStageScore < TargetStageScore)
    //    {
    //        StageFail();
    //    }
    //    yield return null;
    //}
}
