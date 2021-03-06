using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public List<GameObject> levels = new List<GameObject>();
    public int currentLevelIndex;
    public Levell currentLevel;
    public bool isLevelCompleted;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        generateLevel();
    }

    public void generateNextLevel()
    {
        currentLevelIndex++;
        // add the gameManager level number
        GameManager.Instance.currentLevelNumber++;
        Destroy(currentLevel.gameObject);
        if (currentLevelIndex == levels.Count)
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
        GameManager.Instance.currentLevelNumber = 1;
        GameObject tempGameObject = generateCurrentLevel();
        tempGameObject.SetActive(true);
        currentLevel = tempGameObject.GetComponent<Levell>();
        currentLevel.levelMng = this;
        tempGameObject.transform.position = Vector3.zero;


        // SANTA SONRAKI LEVEL
        GameManager.Instance.resetPickerDatas();
        GameManager.Instance.picker.transform.position = Vector3.zero;

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
        GameObject tempLevel = Instantiate(levels[currentLevelIndex]);
        return tempLevel;
    }
    private void gameCompleted()
    {
        isLevelCompleted = true;
    }
}
