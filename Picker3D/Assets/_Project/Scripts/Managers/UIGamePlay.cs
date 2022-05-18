using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.resumeGame();
        GameManager.Instance.setScoreTxt(scoreText);
        GameManager.Instance.setLevelTxt(levelText);
    }
}
