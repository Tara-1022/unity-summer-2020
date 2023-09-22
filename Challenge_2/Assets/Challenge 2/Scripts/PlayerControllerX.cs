using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeElapsed=0;

    // Update is called once per frame
    void Update()
    {
        timeElapsed = timeElapsed + Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timeElapsed>0.5f )
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeElapsed = 0;
        }
        
    }

}
