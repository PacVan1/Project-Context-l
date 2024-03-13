using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(movement.x, 0f, movement.y).normalized;

        if (direction.magnitude > 0)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
