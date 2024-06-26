using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class OutputTrigger2 : Trigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            if (component.bIsConnected)
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
