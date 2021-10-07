using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 100f;
    internal Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.LookAt(Target.position);
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
