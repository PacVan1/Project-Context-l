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
                Data collisionData = collision.GetComponent<Data>();

                if (ContainsComponent(collisionData))
                {
                    int index = GetComponentIndex(collisionData);

                    if (index == collisionData.components.Count - 1)
                    {
                        collisionData.connectedToAOrB.Remove(collisionData.connectedToAOrB[index]);
                        component.aIsConnected = false;
                        collisionData.components.Remove(collisionData.components[index]);

                        //Debug.Log("dettached! " + "a : " + component.aIsConnected + " " + component.gameObject.name);
                    }

                }
            }
        }
    }
}
