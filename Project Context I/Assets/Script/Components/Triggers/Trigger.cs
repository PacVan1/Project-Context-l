using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Component component;

    public bool ContainsComponent(Data data)
    {
        bool containsComponent = false;

        if (data.components != null)
        {
            if (data.components.Contains(component))
            {
                containsComponent = true;
                return containsComponent;
            }       
        }

        return containsComponent;
    }

    public int GetComponentIndex(Data data)
    {
        int componentIndex = 0;

        if (data.components != null)
        {
            for (int i = 0; i < data.components.Count; i++)
            {
                if (data.components[i] == component)
                {
                    componentIndex = i;
                    return componentIndex;
                }
            }
        }

        return componentIndex;
    }
}
