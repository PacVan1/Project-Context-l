using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

public class Data : MonoBehaviour
{
    private GameObject mouseCable; // I feel like I do not need this
    private Cable mouseCableData; // I feel like I also do not need this

    public int value;
    public int lastIndex; // I could probably use recursion if I knew how that works

    public List<Component> components = new List<Component>();
    public List<bool> connectedToAOrB = new List<bool>(); // I could make a variable in each components which stores which mouse is in which component
    public List<GameObject> cables = new List<GameObject>(); 

    [SerializeField] GameObject sourcePrefab; // Don't need this
    [SerializeField] GameObject cablePrefab;
    public GameObject source;
    public GameObject output;
    public SpriteRenderer outputSprite; // hell no

    public GameData colors; // Make it so that all important values are stored in the same place for easy access
    public bool outputed = false; // I have to see if I can find a better solution for this

    private SpriteRenderer spriteRenderer;

    public void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.mouseDatas.Add(this);
        source = Instantiate(sourcePrefab);
        GameManager.sources.Add(source.GetComponent<SpriteRenderer>());

        if (GameManager.mouseDatas.Count == 1)
        {
            source.transform.position = new Vector3(-5, 2);
        }
        else
        {
            source.transform.position = new Vector3(-5, -2);
        }

        mouseCable = Instantiate(cablePrefab);
        mouseCableData = mouseCable.GetComponent<Cable>();

        mouseCableData.targetA = source.transform;
        mouseCableData.targetB = transform;
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
            cableData.targetA = source.transform;
        }
        else
        {
            if (connectedToAOrB[connectedToAOrB.Count - 2] == true)
            {
                cableData.targetA = components[components.Count - 2].outputC.transform;
            }
            else
            {
                cableData.targetA = components[components.Count - 2].outputD.transform;
            }
        }


        if (connectedToAOrB[connectedToAOrB.Count - 1] == true)
        {
            mouseCableData.targetA = components[components.Count - 1].outputC.transform;
            cableData.targetB = components[components.Count - 1].inputA.transform;
        } 
        else
        {
            mouseCableData.targetA = components[components.Count - 1].outputD.transform;
            cableData.targetB = components[components.Count - 1].inputB.transform;
        }
    }

    public void EndCable()
    {
        mouseCableData.targetB = output.transform;
    }

    public void RemoveCable()
    {
        if (cables.Count == 0) return;

        Destroy(cables[cables.Count - 1]);
        cables.Remove(cables[cables.Count - 1]);

        if (cables.Count == 0)
        {
            mouseCableData.targetA = source.transform;
        }
        else
        {
            if (connectedToAOrB[connectedToAOrB.Count - 1] == true)
            {
                mouseCableData.targetA = components[components.Count - 1].outputC.transform;
            } 
            else
            {
                mouseCableData.targetA = components[components.Count - 1].outputD.transform;
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
            spriteRenderer.color = colors.colorTrue;
        }
        else
        {
            spriteRenderer.color = colors.colorFalse;
        }
    }
}
