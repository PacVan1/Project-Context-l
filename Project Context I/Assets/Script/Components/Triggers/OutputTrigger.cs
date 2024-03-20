using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputTrigger : Trigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            if (component.aIsConnected)
            {
                Data mouseData = collision.GetComponent<Data>();

                if (mouseData.outputed == false)
                {
                    mouseData.DisconnectCable(component);
                }
            }
        }
    }
}