using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
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
        if (other.tag == "Food")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);//on collider with an object(with a trigger), destroy it and you
            PlayerController.score += 1;
            Debug.Log("Score: " + PlayerController.score);
        }
        if (other.tag == "Player")
        {
            if (PlayerController.lives > 0)
            {
                PlayerController.lives -= 1;
                Debug.Log("Lives:" + PlayerController.lives);
            }
            if (PlayerController.lives == 0)
            {
                Debug.Log("Game Over");
            }
          
            
        }
       
    }
}
