using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 500f;
    internal Enemy Target;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            transform.LookAt(Target.transform.position);
        }
        //transform.position += transform.forward * Time.deltaTime * bulletSpeed;
        rigidbody.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Turret" && other.gameObject.name != "Sphere")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("Hit");
                enemy.Damaged(5);   
            }
            Destroy(gameObject);
        }
        
        
    }
}
