using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController playerController;
    Vector3 velocity;
    public float speed = 5f;

    private bool isGrounded;
    public float Gravity = -9.8f;
    public float JumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = playerController.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        playerController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        velocity.y += Gravity * Time.deltaTime;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        playerController.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -3.0f * Gravity);
        }
    }
}
