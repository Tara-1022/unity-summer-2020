using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private int keyChoice = 1;
    public GameObject player;
    private Vector3 offset_1 = new Vector3(0, 5, -7);
    private Vector3 offset_2 = new Vector3(-10, 2, 0);
    private Vector3 offset_3 = new Vector3(10, 2, 0);
    private Vector3 offset_4 = new Vector3(0, 15, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            keyChoice += 1;
            if (keyChoice > 4)
            {
                keyChoice = 1;
            }
        }

        if (keyChoice == 1)
        {
            transform.rotation = Quaternion.Euler(Vector3.right * 20f);
            transform.position = player.transform.position + offset_1;
        }
        if (keyChoice == 2)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * 90f);
            transform.position = player.transform.position + offset_2;
        }
        if (keyChoice == 3)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * -90f);
            transform.position = player.transform.position + offset_3;
        }
        if (keyChoice == 4)
        {
            transform.rotation = Quaternion.Euler(Vector3.right * 90f);
            transform.position = player.transform.position + offset_4;
        }
    }
}
