using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController player;

    public Vector3 move;

    Vector3 velocity;
    public float gravity = -19.6f;

    public Transform groundcheck;
    public float groundDetect = 0.4f;
    public LayerMask groundHide;
    public bool isGrounded;

    public float jumpHeight = 5.5f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDetect, groundHide);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        Walk();
        Jump();

        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
    }

    void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        player.Move(move * 10 * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * (gravity * 2));
        }
    }
}
