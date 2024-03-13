using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Component : MonoBehaviour
{
    public bool aIsConnected;
    public bool bIsConnected;

    public Transform aPos;
    public Transform bPos;
    public Transform cPos;
    public Transform dPos;

    public abstract (int _c, int _d) OnConnected(int _a, int _b = -1);
}
