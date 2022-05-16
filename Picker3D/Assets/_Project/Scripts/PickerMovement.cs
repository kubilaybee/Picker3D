using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    #region PickerMovementParameter

    [Header("Movement Parameters")]
    [SerializeField]
    public float CharacterSpeed;
    [SerializeField]
    public float TouchRotationSpeed;

    public float xMinLimit;
    public float xMaxLimit;

    private Vector3 lastMousePos;
    private Vector3 firstMousePos;
    private Vector3 deltaMousePos;
    private float velocityX;

    #endregion

    public SantCurrentBalls santCurrentBalls;
    public bool forceToBall;

    public void forceAllBalls()
    {
        for (int i = 0; i < santCurrentBalls.currentBalls.Count; i++)
        {
            if (santCurrentBalls.currentBalls[i] != null)
            {
                // FORCE COLLECTABLE OBJ
                santCurrentBalls.currentBalls[i].GetComponent<Rigidbody>().AddForce(transform.forward * 0.8f);
            }
        } 
    }

    private void Update()
    {
        if (forceToBall)
        {
            forceAllBalls();
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            // firstMousePos
            firstMousePos = lastMousePos;
            // finalMousePos
            lastMousePos = Input.mousePosition;
            // find deltaMousePos
            deltaMousePos = (lastMousePos - firstMousePos);
            // delay
            velocityX = Mathf.Lerp(velocityX, deltaMousePos.x, 0.2f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            // reset all position datas
            firstMousePos = Vector3.zero;
            lastMousePos = Vector3.zero;
            deltaMousePos = Vector3.zero;
            velocityX = 0;
        }

        // Movement firstStage-> forward Movement secStage-> x movement
        transform.Translate(Vector3.forward * Time.deltaTime * CharacterSpeed + new Vector3(velocityX * TouchRotationSpeed / 300f, 0, 0));
        // X - Movement Limit
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMinLimit, xMaxLimit), transform.position.y, transform.position.z);
    }
}
