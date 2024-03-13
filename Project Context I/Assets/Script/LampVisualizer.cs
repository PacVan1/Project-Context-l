using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampVisualizer : MonoBehaviour
{
    public List<Image> lamps = new List<Image>();

    public Color onColor = Color.green;
    public Color offColor = Color.red;

    public void ChangeLamps()
    {
        for (int i = 0; i < lamps.Count; i++)
        {
            int value = 0;

            switch (i)
            {
                case 0: value = GameManager.startValue1;  break;
                case 1: value = GameManager.startValue2; break;
                case 2: value = GameManager.mouseDatas[0].value; break;
                case 3: value = GameManager.mouseDatas[1].value; break;
            }

            if (value == 0)
            {
                lamps[i].color = offColor;
            }
            else
            {
                lamps[i].color = onColor;
            }
        }
    }
}
