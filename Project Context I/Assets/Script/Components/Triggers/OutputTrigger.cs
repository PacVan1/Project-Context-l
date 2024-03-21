using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputTrigger : Trigger // try to find a way to only need two triggers instead of four
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