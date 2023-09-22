using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject focalPoint;
    public float speed = 5f;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        RB.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }
}
