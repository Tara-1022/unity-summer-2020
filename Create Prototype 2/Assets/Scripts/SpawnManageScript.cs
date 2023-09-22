using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManageScript : MonoBehaviour
{
    public GameObject[] AnimalPrefabs;//array uses square brackets public array of gameobjects created
    
    private float spawnRangeX = 15f;
    private float spawnRangeZ = 20f;
    private float startTime = 2f;
    private float repeatTime = 3.5f;
    private float spawnSide = 27f;
    private Vector3 sideAngle = new Vector3(0f, 90f, 0f);
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startTime,repeatTime);//takes a method, given a time will constantly call the method over some rate
        //mehod,start time, repeat time
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, AnimalPrefabs.Length);//animalIndex can only be seen in the update method
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, spawnRangeZ);//defining the position to spawn

        Instantiate(AnimalPrefabs[animalIndex], spawnPos, AnimalPrefabs[animalIndex].transform.rotation);//instantiating an animal copy


        //spawning from side
        int animalIndex_1 = Random.Range(0, AnimalPrefabs.Length);
        Vector3 spawnLeftPos = new Vector3(-spawnSide, 0f, Random.Range(1f, 12f));
        Instantiate(AnimalPrefabs[animalIndex_1], spawnLeftPos, Quaternion.Euler(sideAngle));

        int animalIndex_2 = Random.Range(0, AnimalPrefabs.Length);
        Vector3 spawnRightPos = new Vector3(spawnSide, 0f, Random.Range(1f, 12f));
        Instantiate(AnimalPrefabs[animalIndex_2], spawnRightPos, Quaternion.Euler(-sideAngle));//rotation is a quaternion
    }  
}
