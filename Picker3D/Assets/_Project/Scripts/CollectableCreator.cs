using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCreator : MonoBehaviour
{
    public int generateCount;
    public float spawnRadius;
    public GameObject currentStage;


    private void Start()
    {
        generateCount = GameManager.Instance.collectableStageSize;
        spawnRadius = GameManager.Instance.spawnRadius;
        generateCollectables();
    }

    void generateCollectables()
    {
        // POOL ** must fix
        for (int i = 0; i < generateCount; i++)
        {
            GameObject tempSphere = Instantiate(GameManager.Instance.CollectablePrefab);
            Vector3 tempSpawnPos = UnityEngine.Random.insideUnitSphere*spawnRadius;
            Vector3 SpawnPos = new Vector3(tempSpawnPos.x,0.5f,tempSpawnPos.z);
            tempSphere.transform.position = SpawnPos + transform.position;
            tempSphere.transform.SetParent(currentStage.transform);
        }

    }

}
