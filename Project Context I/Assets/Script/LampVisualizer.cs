using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampVisualizer : MonoBehaviour // maybe unneccesarry
{
    [SerializeField] private GameData colors;

    public void ChangeLamps()
    {
        for (int i = 0; i < GameManager.sources.Count; i++)
        {
            int value = 0;

            switch (i)
            {
                case 0: value = GameManager.startValue1; break;
                case 1: value = GameManager.startValue2; break;
            }

            if (value == 0)
            {
                GameManager.sources[i].color = colors.colorFalse;
            }
            else
            {
                GameManager.sources[i].color = colors.colorTrue;
            }
        }

        for (int i = 0; i < GameManager.mouseDatas.Count; i++)
        {
            if (GameManager.mouseDatas[i].output != null)
            {
                if (GameManager.mouseDatas[i].value == 1)
                {
                    GameManager.mouseDatas[i].outputSprite.color = colors.colorTrue;
                }
                else
                {
                    GameManager.mouseDatas[i].outputSprite.color = colors.colorFalse;
                }
            }
        }
    }
}
