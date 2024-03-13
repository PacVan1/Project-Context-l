using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Isabella : MonoBehaviour
{
    string[] allComponents = { "XOR", "OR", "AND", "NOT" };

    public void checked_component()
    {
        for (int i = 0; i < allComponents.Length; i++)
        {

            Functions(allComponents[0], true, true);
        }
    }

    public bool check_connected()
    {
        bool a = true;
        return a;
    }

    public bool AND(bool a, bool b)
    {
        if (a == true && b == true)
        {
            a = true;
        }
        else
        {
            a = false;
        }
        return a;
    }
    public bool OR(bool a, bool b)
    {
        if (a == true || b == true)
        {
            a = false;
        }
        else
        {
            a = true;
        }
        return a;
    }
    public bool XOR(bool a, bool b)
    {
        if (a == true && b == false || a == false && b == true)
        {
            a = true;
        }
        else
        {
            a = false;
        }
        return a;
    }
    public bool NOT(bool a)
    {
        if (a == true)
        {
            a = false;
        }
        else
        {
            a = true;
        }
        return a;
    }

    public bool Functions(string type, bool a, bool b)
    {
        bool returnValue = false;

        switch (type)
        {
            case "XOR": returnValue = XOR(a, b); break;
            case "OR": returnValue = OR(a, b); break;
            case "AND": returnValue = AND(a, b); break;
            case "NOT": returnValue = NOT(a); break;
        }

        return returnValue;
    }
}
