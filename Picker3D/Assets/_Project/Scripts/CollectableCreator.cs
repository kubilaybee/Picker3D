using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCreator : MonoBehaviour
{
    public int generateCount;
    public float spawnRadius;
    public GameObject currentStage;
    private bool collectablesTransformComplete;


    private void Start()
    {
        generateCount = GameManager.Instance.collectableStageSize;
        spawnRadius = GameManager.Instance.spawnRadius;
        // create pool
        GameManager.Instance.createPool(generateCount);
    }

    private void Update()
    {

        if (!collectablesTransformComplete)
        {
            if (GameManager.Instance.poolObjectList.Count > generateCount)
            {
                generateCollectables();
            }
        }
    }

    void generateCollectables()
    {
        collectablesTransformComplete = !collectablesTransformComplete;
        // POOL ** completed
        for (int i = 0; i < generateCount; i++)
        {
            Debug.Log("COLLECTABLES");
            GameObject tempSphere = GameManager.Instance.poolObjectList[i];
            GameManager.Instance.poolObjectList.RemoveAt(i);
            //GameObject tempSphere = Instantiate(GameManager.Instance.CollectablePrefab);
            Vector3 tempSpawnPos = UnityEngine.Random.insideUnitSphere * spawnRadius;
            Vector3 SpawnPos = new Vector3(tempSpawnPos.x, 0.5f, tempSpawnPos.z);
            tempSphere.transform.position = SpawnPos + transform.position;
            tempSphere.transform.SetParent(currentStage.transform);
        }
        
        

    }

}
