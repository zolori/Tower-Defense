using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (transform.position.x >= -5 && transform.position.z <= -20 && horizontalInput <= 0 && verticalInput >= 0)
        {
            transform.position += new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        }
        if (transform.position.x <= 5 && transform.position.z >= -50 && horizontalInput >= 0 && verticalInput <= 0) 
        { 
            transform.position += new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        } 
        

    }
}
