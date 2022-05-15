using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public Stagee stage;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collectable>())
        {
            stage.includeScore();
        }
        // delay timer 4s
        // level succes or failed
        //tempStage.Instance.setCurrentStageScore();
    }
}
