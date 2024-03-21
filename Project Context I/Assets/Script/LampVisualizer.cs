using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampVisualizer : MonoBehaviour // maybe unneccesarry
{
    [SerializeField] private GameData colors;
    private List<SpriteRenderer> sourceSprites = new List<SpriteRenderer>();
    private List<SpriteRenderer> outputSprites = new List<SpriteRenderer>();

    private void Start()
    {
/*        sourceSprites[0] = GameManager.sources[0].GetComponent<SpriteRenderer>();
        sourceSprites[1] = GameManager.sources[1].GetComponent<SpriteRenderer>();*/
    }

    public void GetSourceSprite()
    {
        if (GameManager.sources.Count == 2)
        {
            sourceSprites.Add(GameManager.sources[0].GetComponent<SpriteRenderer>());
            sourceSprites.Add(GameManager.sources[1].GetComponent<SpriteRenderer>());
        }
    }

    public void ChangeLamps()
    {
        // sources 
        if (sourceSprites.Count == 2)
        {
            for (int i = 0; i < GameManager.sources.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        if (GameManager.startValue1 == 1)
                        {
                            sourceSprites[0].color = colors.colorTrue;
                        }
                        else { sourceSprites[0].color = colors.colorFalse; }
                        break;
                    case 1:
                        if (GameManager.startValue2 == 1)
                        {
                            sourceSprites[1].color = colors.colorTrue;
                        }
                        else { sourceSprites[1].color = colors.colorFalse; }
                        break;
                }
            }
        }

        // outputs
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
