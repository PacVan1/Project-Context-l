using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR : Component
{
    public override (int _c, int _d) OnConnected(int _a, int _b)
    {
        if (_a == 1 || _b == 1)
        {
            return (1, _b);
        } else { return (1, _b); }
    }
}
