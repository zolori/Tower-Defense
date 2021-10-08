using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    Transform transform;

<<<<<<< Updated upstream
=======
    private Boolean ready = false;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
<<<<<<< Updated upstream
        Instantiate(enemy, transform.position, Quaternion.identity);
=======
    }

    private void Update()
    {
        InvokeRepeating(nameof(Spawn), 0f, 1);
    }

    void Spawn()
    {
        if (ready && GameObject.FindGameObjectsWithTag("Enemy").Length < 20)
        {
            Instantiate(enemy, transform.position + new Vector3(-2,0,0), Quaternion.identity);
        }
        else
        {
            CancelInvoke();
            ready = false;
        }
>>>>>>> Stashed changes
    }

    public void IsReady()
    {
        ready = true;
    }
}