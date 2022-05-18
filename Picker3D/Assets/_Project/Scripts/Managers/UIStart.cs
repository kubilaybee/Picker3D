using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.stopTheGame();
    }

    public void startGame()
    {
        GameManager.Instance.changeGameState(GameManager.GameStates.GamePlay);
    }
}
