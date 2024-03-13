using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerSolver : MonoBehaviour
{
    private List<Data> mouseDatas = new List<Data>();

    private void Start()
    {
        mouseDatas = GameManager.mouseDatas;
    }

    private void Update()
    {
        if (mouseDatas.Count == 2)
        {
            LoopThroughCables();
        }
    }

    public void LoopThroughCables()
    {
        mouseDatas[0].value = GameManager.startValue1;
        mouseDatas[1].value = GameManager.startValue2;
        mouseDatas[0].lastIndex = 0;
        mouseDatas[1].lastIndex = 0;

        // running all small components before the big ones
        RunningSmallComponents();

        while (mouseDatas[0].lastIndex < mouseDatas[0].components.Count && mouseDatas[1].lastIndex < mouseDatas[1].components.Count)
        {
            // check if both mouses have the same components attached at the same points in the array
            if (mouseDatas[0].components[mouseDatas[0].lastIndex] == mouseDatas[1].components[mouseDatas[1].lastIndex])
            {
                // check if the cable is connected to either point a (true) or b (false)
                if (mouseDatas[0].connectedToAOrB[mouseDatas[0].lastIndex] == true)
                {
                    (mouseDatas[0].value, mouseDatas[1].value) = mouseDatas[0].components[mouseDatas[0].lastIndex].OnConnected(mouseDatas[0].value, mouseDatas[1].value);
                }
                else
                {
                    (mouseDatas[1].value, mouseDatas[0].value) = mouseDatas[0].components[mouseDatas[0].lastIndex].OnConnected(mouseDatas[1].value, mouseDatas[0].value);
                }

                mouseDatas[0].lastIndex++;
                mouseDatas[1].lastIndex++;

                RunningSmallComponents();
            }
            else
            {
                break;
            }
        }
    }

    public void RunningSmallComponents()
    {
        // running all small components
        for (int d = 0; d < mouseDatas.Count; d++)                                         // d = data
        {
            if (mouseDatas[d].lastIndex < mouseDatas[d].components.Count)
            {
                for (int c = mouseDatas[d].lastIndex; c < mouseDatas[d].components.Count; c++) // c = components
                {
                    if (mouseDatas[d].components[c].CompareTag("SmallComponent"))
                    {
                        mouseDatas[d].value = mouseDatas[d].components[c].OnConnected(mouseDatas[d].value)._c;
                    }
                    else
                    {
                        mouseDatas[d].lastIndex = c; 
                        break;
                    }
                }
            }
        }
    }
}
