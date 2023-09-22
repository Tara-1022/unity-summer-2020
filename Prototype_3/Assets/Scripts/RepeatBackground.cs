using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 bgPosition;//postion to set

    private float repeatWidth;//width at which to repeat
    void Start()
    {
        bgPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x/2;//backround is double
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < bgPosition.x-repeatWidth)//the pos is not 0, so we have to subract the width we need
        {
            transform.position = bgPosition;
        }
    }
}
