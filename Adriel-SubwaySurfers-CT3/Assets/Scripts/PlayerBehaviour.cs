using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private ScoreManager scoreManager;
    private bool left, center, right, isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        left = true;
        right = true;
        center = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            jump();
        }
    }

    private void moveLeft()
    {
        if (left && !center)
        {
            transform.position = new Vector3(-3f, transform.position.y, 0f);

            left = false;
            center = true;
            right = true;
        }
        else if (center && !right)
        {
            transform.position = new Vector3(0f, transform.position.y, 0f);

            left = true;
            center = false;
            right = true;
        }
    }

    private void moveRight()
    {
        if (right && !center)
        {
            transform.position = new Vector3(3f, transform.position.y, 0f);

            left = true;
            center = true;
            right = false;
        }
        else if (center && !left)
        {
            transform.position = new Vector3(0f, transform.position.y, 0f);

            left = true;
            center = false;
            right = true;
        }
    }

    private void jump()
    {
        rb.AddForce(new Vector3(0f, 7f, 0f), ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Perdeu Playboy");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collider.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Pegou uma moeda!");
            Destroy(collider.gameObject);
            scoreManager.addScore(1);
        }
    }
}
