using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
    public GameObject output;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            Data mouseData = collision.GetComponent<Data>();

            mouseData.outputed = true;
            mouseData.output = gameObject;
            mouseData.outputSprite = output.GetComponent<SpriteRenderer>();
            mouseData.EndCable();
        }
    }
}
