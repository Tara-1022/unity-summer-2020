using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private GameManagerScript gameManagerScript;//reference to the script

    private float speed = 25f;

    private float boundaryLimit = -15f;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();//find gameobject(player) and get its script
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameManagerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime * gameManagerScript.speedMulitiplier);//if player moves faster, so must the world
        }

        if (gameObject.CompareTag("Obstacle") && gameObject.transform.position.x < boundaryLimit)//so we don't delete the background
        {
            Destroy(gameObject);
        }
    }
}
