using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerStopper : MonoBehaviour
{
    public bool isEnable;

    private void OnTriggerEnter(Collider other)
    {
        if (isEnable)
        {
            return;
        }

        // level completed func
        if (other.gameObject.transform.parent.GetComponent<PickerMovement>())
        {
            isEnable = true;
            other.gameObject.transform.parent.GetComponent<PickerMovement>().forceToBall=true;
            other.gameObject.transform.parent.GetComponent<PickerMovement>().CharacterSpeed = 0;
            other.gameObject.transform.parent.GetComponent<PickerMovement>().TouchRotationSpeed = 0;
            //StartCoroutine(stage.checkStageFail());
            this.gameObject.GetComponent<BoxCollider>().enabled =false;
            //this.gameObject.SetActive(false);
        }
    }
}
