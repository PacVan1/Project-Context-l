using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

public class Data : MonoBehaviour
{
    int playerNumber;
    public int value;
    public int lastIndex;
    public List<Component> components = new List<Component>();
    public List<bool> connectedToAOrB = new List<bool>(); // true is a, false is b
    public List<GameObject> cables = new List<GameObject>();
    public GameObject mouseCable;
    public Cable mouseCableData;

    [SerializeField] GameObject sourcePrefab;
    [SerializeField] GameObject cablePrefab;
    public GameObject source;

    public GameData gameSO;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Start()
    { 
        GameManager.mouseDatas.Add(this);
        playerNumber = GameManager.mouseDatas.Count - 1;

        float sourceY = 0;
        if (playerNumber == 0)
        {
            sourceY = 2f;
        }
        else
        {
            sourceY = -2f;  
        }

        source = Instantiate(sourcePrefab, new Vector3(-5f, sourceY, 0), Quaternion.identity);
        mouseCable = Instantiate(cablePrefab);
        mouseCableData = mouseCable.GetComponent<Cable>();

        mouseCableData.a = source.transform;
        mouseCableData.b = transform;
    }

    public void ConnectCable(Component component, bool AOrB)
    {
        if (!ContainsComponent(component))
        {
            components.Add(component);
            
            if (AOrB == false)
            {
                component.bIsConnected = true;
                connectedToAOrB.Add(false);
            }
            else
            {
                component.aIsConnected = true;
                connectedToAOrB.Add(true);
            }

            AddCable();
        }
    }

    public void DisconnectCable(Component component)
    {
        if (ContainsComponent(component))
        {
            int index = GetComponentIndex(component);

            if (index == components.Count - 1)
            {
                if (connectedToAOrB[index] == false)
                {
                    component.bIsConnected = false;
                }
                else
                {
                    component.aIsConnected = false;
                }

                connectedToAOrB.Remove(connectedToAOrB[index]);
                components.Remove(components[index]);
                RemoveCable();
            }
        }
    }

    public void AddCable()
    {
        cables.Add(Instantiate(cablePrefab));
        Cable cableData = cables[cables.Count - 1].GetComponent<Cable>();

        if (cables.Count == 1)
        {
            cableData.a = source.transform;
        }
        else
        {
            if (connectedToAOrB[connectedToAOrB.Count - 2] == true)
            {
                cableData.a = components[components.Count - 2].outputC.transform;
            }
            else
            {
                cableData.a = components[components.Count - 2].outputD.transform;
            }
        }


        if (connectedToAOrB[connectedToAOrB.Count - 1] == true)
        {
            mouseCableData.a = components[components.Count - 1].outputC.transform;
            cableData.b = components[components.Count - 1].inputA.transform;
        } 
        else
        {
            mouseCableData.a = components[components.Count - 1].outputD.transform;
            cableData.b = components[components.Count - 1].inputB.transform;
        }
    }

    public void RemoveCable()
    {
        if (cables.Count == 0) return;

        Destroy(cables[cables.Count - 1]);
        cables.Remove(cables[cables.Count - 1]);

        if (cables.Count == 0)
        {
            mouseCableData.a = source.transform;
        }
        else
        {
            if (connectedToAOrB[connectedToAOrB.Count - 1] == true)
            {
                mouseCableData.a = components[components.Count - 1].outputC.transform;
            } 
            else
            {
                mouseCableData.a = components[components.Count - 1].outputD.transform;
            }
        }
    }

    public bool ContainsComponent(Component component)
    {
        bool containsComponent = false;

        if (components != null)
        {
            if (components.Contains(component))
            {
                containsComponent = true;
                return containsComponent;
            }
        }

        return containsComponent;
    }

    public int GetComponentIndex(Component component)
    {
        int componentIndex = 0;

        if (components != null)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] == component)
                {
                    componentIndex = i;
                    return componentIndex;
                }
            }
        }

        return componentIndex;
    }

    public void ChangeColor()
    {
        if (value == 1)
        {
            spriteRenderer.color = gameSO.colorTrue;
        }
        else
        {
            spriteRenderer.color = gameSO.colorFalse;
        }
    }
}
