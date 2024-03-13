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
                Data collisionData = collision.GetComponent<Data>();

                if (!ContainsComponent(collisionData))
                {
                    component.aIsConnected = true;
                    collisionData.components.Add(component);
                    collisionData.connectedToAOrB.Add(true);

                    //Debug.Log("Attached! " + "a : " + component.aIsConnected + " " + component.gameObject.name);
                }
                else
                {
                    //Debug.Log("Can't connect. Component is connected already.");
                }
            }
        }
    }
    
}
