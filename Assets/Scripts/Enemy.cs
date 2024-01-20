using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.y < -3)
        {
            GameManager.score += 1;
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        Vector3 direction = player.transform.position - transform.position;
        enemyRb.AddForce(direction.normalized * speed);
    }
}
