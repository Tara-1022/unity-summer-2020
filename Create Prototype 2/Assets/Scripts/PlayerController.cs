using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int lives = 3;
    public static int score = 0;
    public float horizontalinput;
    public float verticalInput;
    public float speed = 20f;
    float boundarylimit = 15f;
    float forwardLimit = 3.5f;
    float ProjectileHeight = 1.5f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //movement
        horizontalinput = Input.GetAxis("Horizontal");//moving with input
        transform.Translate(Vector3.right * horizontalinput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //keeping boundaries
        if (transform.position.x < -boundarylimit)//keeping within boundaries
        {
            transform.position = new Vector3(-boundarylimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundarylimit)
        {
            transform.position = new Vector3(boundarylimit, transform.position.y, transform.position.z);//if out of boundary reposition player at boundary
        }
        
        
        if (transform.position.z < -forwardLimit)//keeping within boundaries
        {
            transform.position = new Vector3(transform.position.x, transform.position.y ,- forwardLimit);
        }
        else if (transform.position.z > forwardLimit)
        {
            transform.position = new Vector3( transform.position.x, transform.position.y, forwardLimit);//if out of boundary reposition player at boundary
        }

        //throwing food
        if (Input.GetKeyDown(KeyCode.Space))//if space, create instance on projectile; getkeydown true when key is pressed down, so only works once
        {
            Instantiate(projectilePrefab, new Vector3(transform.position.x,ProjectileHeight,transform.position.z), projectilePrefab.transform.rotation); //create instances(copies); object,pos,rotation
        }
    }

    
}
