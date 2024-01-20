using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpforce = 5f;
    private Rigidbody playerRb;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Jump();

        Die();
    }

    //ABSTRACTION
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * verticalInput * speed);
        playerRb.AddForce(Vector3.right * horizontalInput * speed);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            canJump = false;
        }
    }

    void Die()
    {
        if (transform.position.y < -5)
        {
            if (GameManager.lives > 0)
            {
                GameManager.lives--;
                transform.position = new Vector3(0, 5, 0);
            }
            else
            {
                GameManager.gameOver = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            canJump = true;
        }
    }

}
