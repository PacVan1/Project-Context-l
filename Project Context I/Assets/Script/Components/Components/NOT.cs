using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT : Component
{
    public override (int _c, int _d) OnConnected(int _a, int _b = -1)
    {
        if (_a == 1) { return (0, _b); }
        else { return (1, _b); }
    }
}
