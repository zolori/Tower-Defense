using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject _end;

    public int lifePoint = 20;
    public int maxLifePoint = 20;
    public HealthBar sliderHealthBar;
    public int enemyId;
    public GameObject DeathParticle;

    public GameObject MoveParticle;

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        _end = GameObject.FindWithTag("Finish");
        navMeshAgent.destination = _end.transform.position;
        sliderHealthBar.SetMaxHealth(maxLifePoint);
        if (enemyId == 1)
        {
            InvokeRepeating(nameof(Stars), 0f, 0.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Stars()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            level = 3;
        }
        else
        {
            level = 6;
        }

        Instantiate(MoveParticle, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
    }

    public void Damaged(int prmDamage)
    {
        lifePoint -= prmDamage;
        sliderHealthBar.SetHealth(lifePoint);
        if (lifePoint <= 0)
        {
            GameManager.instance.AddMoney();
            Instantiate(DeathParticle, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}