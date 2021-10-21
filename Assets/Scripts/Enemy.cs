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
    public AudioSource source;
    public AudioClip walk_1;
    public AudioClip walk_2;
    public AudioClip walk_3;
    public AudioClip walk_4;

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
        else
            InvokeRepeating(nameof(walkSound), 0f, 0.5f);

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Stars()
    {
        Instantiate(MoveParticle, new Vector3(transform.position.x, GameManager.instance.levelHeight, transform.position.z), transform.rotation);
    }

    private void walkSound()
    {
        int r = Random.Range(1, 5);
        switch (r)
        {
            case 1:
                source.PlayOneShot(walk_1);
                break;
            case 2:
                source.PlayOneShot(walk_2);
                break;
            case 3:
                source.PlayOneShot(walk_3);
                break;
            case 4:
                source.PlayOneShot(walk_4);
                break;
            default:
                source.PlayOneShot(walk_1);
                break;
        }
    }

    public void Damaged(int prmDamage)
    {
        lifePoint -= prmDamage;
        sliderHealthBar.SetHealth(lifePoint);
        if (lifePoint <= 0)
        {
            GameManager.instance.AddMoney();
            Instantiate(DeathParticle, new Vector3(transform.position.x, GameManager.instance.levelHeight, transform.position.z), transform.rotation);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}