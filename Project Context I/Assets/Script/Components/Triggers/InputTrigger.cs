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
            Data mouseData = collision.GetComponent<Data>();

            if (!component.aIsConnected)
            {

                mouseData.ConnectCable(component, true);
            }
            else
            {
                mouseData.ConnectCable(component, false);
            }
        }
    }
    
}
