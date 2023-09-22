using System.Collections;///
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManagerScript gameManagerScript;//reference to the script

    public GameObject[] obstaclePrefabs;
    private int indexVal;

    private Vector3 spawnPos = new Vector3(28, 0, 0);
    private float startTime = 0f;
    private float repeatTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();//find gameobject and get its script
        InvokeRepeating("SpawnObstacle", startTime, repeatTime);
    }

    

    void SpawnObstacle()
    {
        indexVal = Random.Range(0, obstaclePrefabs.Length);//getting random obstacle

        if (obstaclePrefabs[indexVal].name=="Barrel Pile")
        {
            spawnPos.y = obstaclePrefabs[indexVal].transform.position.y;//because the barrel prefab, being a collection, is positioned lower, causing problems
        }
        else
        {
            spawnPos = new Vector3(28, 0, 0);
        }
        
        
        if (!gameManagerScript.gameOver)//actually spawning if game not over
        {
            Instantiate(obstaclePrefabs[indexVal], spawnPos, obstaclePrefabs[indexVal].transform.rotation);
        }
    }
}
