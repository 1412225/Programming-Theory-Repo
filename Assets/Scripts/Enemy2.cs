using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy2 : Enemy
{
    // INHERITANCE SCRIPT 
    [SerializeField] private float jumpForce = 5f;
    private bool isOnFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Death();
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (isOnFloor ) 
        {
            enemyRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnFloor = false;
        }
        StartCoroutine(Jump());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isOnFloor = true;
        }
    }

    public override void Death() // POLYMORPHISM
    {
        if (transform.position.y < -3)
        {
            GameManager.score += 2;
            Destroy(gameObject);
        }
    }
}
