using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerSolver : MonoBehaviour
{
    public void LoopThroughCables(List<Data> m)
    {
        m[0].value = GameManager.startValue1;
        m[1].value = GameManager.startValue2;

        m[0].lastIndex = 0;
        m[1].lastIndex = 0;

        // running all small components before the big ones
        RunningSmallComponents(m);

        while (m[0].lastIndex < m[0].components.Count && m[1].lastIndex < m[1].components.Count)
        {
            // check if both mouses have the same components attached at the same points in the array
            if (m[0].components[m[0].lastIndex] == m[1].components[m[1].lastIndex])
            {
                // check if the cable is connected to either point a (true) or b (false)
                if (m[0].connectedToAOrB[m[0].lastIndex] == true)
                {
                    (m[0].value, m[1].value) = m[0].components[m[0].lastIndex].OnConnected(m[0].value, m[1].value);
                }
                else
                {
                    (m[1].value, m[0].value) = m[0].components[m[0].lastIndex].OnConnected(m[1].value, m[0].value);
                }

                m[0].lastIndex++;
                m[1].lastIndex++;

                RunningSmallComponents(m);
            }
            else
            {
                break;
            }
        }
    }

    public void RunningSmallComponents(List<Data> m)
    {
        // running all small components
        for (int d = 0; d < m.Count; d++)                                         // d = data
        {
            if (m[d].lastIndex < m[d].components.Count)
            {
                for (int c = m[d].lastIndex; c < m[d].components.Count; c++) // c = components
                {
                    if (m[d].components[c].CompareTag("SmallComponent"))
                    {
                        m[d].value = m[d].components[c].OnConnected(m[d].value)._c;
                    }
                    else
                    {
                        m[d].lastIndex = c; 
                        break;
                    }
                }
            }
        }
    }
}
