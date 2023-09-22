using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOutOfBounds : MonoBehaviour
{
    private float TopBoundaryz = 25f;
    private float LowBoundaryz = -5f;
    private float sideBounds = 27.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  //destroy if it goes out of bounds
        if (transform.position.z > TopBoundaryz || transform.position.x<-sideBounds ||transform.position.x>sideBounds)
        {
            Destroy(gameObject);//gameobject refers to object to which script is attached
        }
        else if(transform.position.z < LowBoundaryz)
        {
            
            Destroy(gameObject);
        }
    }
}
