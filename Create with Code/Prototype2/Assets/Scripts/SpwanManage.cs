using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManage : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spwanRangeX = 20;
    private float spwanPosZ = 20;

    private float startDelay = 2;
    private float intervals = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, intervals);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spwanPos = new Vector3(Random.Range(-spwanRangeX, spwanRangeX), 0, spwanPosZ);
        Instantiate(animalPrefabs[animalIndex], spwanPos,
            animalPrefabs[animalIndex].transform.rotation);
    }
}
