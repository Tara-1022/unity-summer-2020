using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public bool inDashMode = false;
    public bool gameOver = false;

    public int speedMulitiplier = 1;//to use to multiply speed
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inDashMode = Input.GetKey(KeyCode.X);//checks in dash mode and adjusts the multiplier accordingly

        if (inDashMode)
        {
            speedMulitiplier = 2;
        }
        else
        {
            speedMulitiplier = 1;
        }
    }
    public void IncreaseScore()
    {
        if (!gameOver)
        {
            score += speedMulitiplier;//since score is 2 in dash, 1 i normal

            Debug.Log(score.ToString());
        }
    }
}
