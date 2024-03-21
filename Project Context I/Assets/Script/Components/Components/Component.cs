using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Component : MonoBehaviour
{
    // properties
    public bool aIsConnected; // change this into what mouse is connected (mouse for connected, null for disconnected)
    public bool bIsConnected; //

    // in- and output prefabs
    public GameObject inputA;
    public GameObject inputB;
    public GameObject outputC;
    public GameObject outputD;

    private SpriteRenderer spriteRenderer;
    public Game gameManager; // do something about the gamemanager. you're using too much different kinds of references 
    [SerializeField] GameData colors;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        ChangeColor(); // Doesn't have to change every frame. Only when cables have changed
    }

    public abstract (int _c, int _d) OnConnected(int _a, int _b = -1);

    public void ChangeColor()
    {
        if (aIsConnected)
        {
            if (CompareTag("SmallComponent") || bIsConnected)
            {
                spriteRenderer.color = colors.componentActivated;
            } 
            else
            {
                spriteRenderer.color = colors.componentDeactivated;
            }
        }
        else { spriteRenderer.color = colors.componentDeactivated; }
    }
}
