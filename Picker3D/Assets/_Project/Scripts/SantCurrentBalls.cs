using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantCurrentBalls : MonoBehaviour
{
    public List<GameObject> currentBalls = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!currentBalls.Contains(other.gameObject)&& other.gameObject.GetComponent<Collectable>())
        {
            currentBalls.Add(other.gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentBalls.Contains(other.gameObject))
        {
            currentBalls.Remove(other.gameObject);
        }
    }
}
