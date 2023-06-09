using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
            transform.position = new Vector3(-3f, 0f, 0f);
            left = false;
            right = true;
            center = true;
        }
        else if (center && !right)
        {
            transform.position = new Vector3(0f, 0f, 0f);

            left = true;
            center = false;
            right = true;
        }
    }

    private void moveRight()
    {
        if (right && !center)
        {
            transform.position = new Vector3(3f, 0f, 0f);
            left = true;
            right = false;
            center = true;
        }
        else if (center && !left)
        {
            transform.position = new Vector3(0f, 0f, 0f);

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
    }

}





