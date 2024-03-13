using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationScript : MonoBehaviour
{

    public Vector2 mouse_position;
    public float sensitivity = -1f;
    private Vector3 rotate;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        mouse_position.x = Input.GetAxis("Mouse X");
        mouse_position.y = Input.GetAxis("Mouse Y");
        rotate = new Vector3(mouse_position.x, mouse_position.y * sensitivity);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }
}
