using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTrigger2 : Trigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            if (!component.bIsConnected)
            {
                Data collisionData = collision.GetComponent<Data>();

                if (!ContainsComponent(collisionData))
                {
                    component.bIsConnected = true;
                    collisionData.components.Add(component);
                    collisionData.connectedToAOrB.Add(false);

                    //Debug.Log("Attached! " + "b : " + component.bIsConnected + " " + component.gameObject.name);
                }
                else
                {
                    //Debug.Log("Can't connect. Component is connected already.");
                }
            }
        }      
    }
}
