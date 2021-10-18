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
        float edgeSize = 100f;

        //Move with keyborad

        if (Input.GetKey(KeyCode.D) && transform.position.x <= 5)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q) && transform.position.x >= -10)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && transform.position.z >= -50)
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Z) && transform.position.z <= -20)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        //Move with mouse

        if (Input.mousePosition.x > Screen.width - edgeSize && transform.position.x <= 5)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x < edgeSize && transform.position.x >= -10)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y > Screen.height - edgeSize && transform.position.z <= -20)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y < edgeSize && transform.position.z >= -50)
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }
}