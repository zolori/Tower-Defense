using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject _end;

    public int lifePoint = 20;
    public int maxLifePoint = 20;
    public HealthBar sliderHealthBar;
    public string enemyId;
    public GameObject DeathParticle;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        _end = GameObject.FindWithTag("Finish");
        navMeshAgent.destination = _end.transform.position;
        sliderHealthBar.SetMaxHealth(maxLifePoint);

        enemyId = System.Guid.NewGuid().ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Damaged(int prmDamage)
    {
        lifePoint -= prmDamage;
        sliderHealthBar.SetHealth(lifePoint);
        if (lifePoint <= 0)
        {
            GameManager.instance.AddMoney();
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(DeathParticle, new Vector3(transform.position.x, 2, transform.position.z), transform.rotation);
        
        
    }
}