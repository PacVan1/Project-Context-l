using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    // steering behavior properties
    [SerializeField] Vector3 velocity;
    [SerializeField] private Vector3 acceleration;
    [SerializeField] private float maxForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float slowdownDistance;
    [SerializeField] private bool canSlowdown;

    private Rigidbody2D rigidbody;

    // input
    public Vector2 input;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.AddForce(new Vector3(input.x, input.y));
    }

    public void OnMove(InputAction.CallbackContext ctx) => input = ctx.ReadValue<Vector2>();
}
