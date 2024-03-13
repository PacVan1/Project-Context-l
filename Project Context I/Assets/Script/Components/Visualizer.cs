using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    private List<Data> mouseDatas = new List<Data>();

    private void Start()
    {
        mouseDatas = GameManager.mouseDatas;
    }

    private void Update()
    {
        for (int i = 0; i < mouseDatas.Count; i++)
        {
            if (mouseDatas[i].components.Count > 0)
            {
                Debug.DrawLine(mouseDatas[i].source.transform.position, mouseDatas[i].components[0].transform.position);

                // draw in between
                for (int j = 0; j < mouseDatas[i].components.Count - 1; j++)
                {
                    Debug.DrawLine(mouseDatas[i].components[j].transform.position, mouseDatas[i].components[j + 1].transform.position);
                }

                Debug.DrawLine(mouseDatas[i].components[mouseDatas[i].components.Count - 1].transform.position, mouseDatas[i].transform.position);
            }
            else
            {
                Debug.DrawLine(mouseDatas[i].source.transform.position, mouseDatas[i].transform.position);
            }
        }
    }
}
