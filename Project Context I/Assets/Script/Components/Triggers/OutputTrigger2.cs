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
                Data collisionData = collision.GetComponent<Data>();

                if (ContainsComponent(collisionData))
                {
                    int index = GetComponentIndex(collisionData);

                    if (index == collisionData.components.Count - 1)
                    {
                        collisionData.components.Remove(collisionData.components[index]);
                        collisionData.connectedToAOrB.Remove(collisionData.connectedToAOrB[index]);
                        component.bIsConnected = false;

                        //Debug.Log("dettached! " + "b : " + component.bIsConnected + " " + component.gameObject.name);
                    }
                }
            }
        }      
    }
}
