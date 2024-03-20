using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Component : MonoBehaviour
{
    // properties
    public bool aIsConnected;
    public bool bIsConnected;

    // in- and output prefabs
    public GameObject inputA;
    public GameObject inputB;
    public GameObject outputC;
    public GameObject outputD;

    public SpriteRenderer sprite;
    public Game gameManager;

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        ChangeColor();
    }

    public abstract (int _c, int _d) OnConnected(int _a, int _b = -1);

    public void ChangeColor()
    {
        if (aIsConnected && bIsConnected)
        {
            sprite.color = gameManager.colorTrue;
        }
        else { sprite.color = gameManager.colorFalse; }
    }
}
