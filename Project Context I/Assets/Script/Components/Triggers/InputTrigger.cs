using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputTrigger : Trigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            if (!component.aIsConnected)
            {
                Data mouseData = collision.GetComponent<Data>();
                mouseData.ConnectCable(component, true);
            }
        }
    }

}