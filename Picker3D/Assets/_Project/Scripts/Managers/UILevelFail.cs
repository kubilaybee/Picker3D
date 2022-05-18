using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelFail : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setScoreTxt(scoreText);
        GameManager.Instance.stopTheGame();
    }

    public void restartGame()
    {
        GameManager.Instance.changeGameState(GameManager.GameStates.GamePlay);
    }
}
