using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    protected Rigidbody enemyRb;
    protected GameObject player;
    protected float enemySize;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        speed = Random.Range(.9f, 1.5f);
        enemySize = Random.Range(.75f, 1.25f);
        transform.localScale = Vector3.one * enemySize;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Death();
    }

    protected void Move()
    {
        Vector3 direction = player.transform.position - transform.position;
        enemyRb.AddForce(direction.normalized * speed);
    }

    public virtual void Death()
    {
        if (transform.position.y < -3)
        {
            GameManager.score += 1;
            Destroy(gameObject);
        }
    }
}
