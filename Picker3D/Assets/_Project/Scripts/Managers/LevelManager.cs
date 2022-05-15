using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels = new List<GameObject>();
    private int currentLevelIndex;
    public Levell currentLevel;
    public bool isLevelCompleted;

    private void Start()
    {
        generateLevel();
    }

    public void generateNextLevel()
    {
        currentLevelIndex++;
        if(currentLevelIndex == levels.Count)
        {
            // all levels end
            gameCompleted();
        }
        else
        {
            // gamePlay
            generateLevel();
        }
    }

    private void generateLevel()
    {
        GameObject tempGameObject = generateCurrentLevel();
        tempGameObject.SetActive(true);
        currentLevel = tempGameObject.GetComponent<Levell>();
        currentLevel.levelMng = this;
    }

    GameObject generateCurrentLevel()
    {
        Debug.Log(currentLevelIndex);
        if (currentLevelIndex != 0)
        {
            GameObject tempGameObj = levels[currentLevelIndex - 1];
            tempGameObj.SetActive(false);
            GameManager.Instance.resetPickerDatas();
        }
        // stage pos fix it off set problems
        GameObject tempLevel = Instantiate(levels[currentLevelIndex], new Vector3(0, 0, (currentLevelIndex * (currentLevel != null ? currentLevel.stages.Count : 0)) * GameManager.Instance.stageOffset), Quaternion.identity);
        return tempLevel;
    }
    private void gameCompleted()
    {
        isLevelCompleted = true;
    }

}
