using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int index;
    private bool coroutineIsRunning = false;
    public LampVisualizer lampVisualizer;
    public PowerSolver powerSolver;

    // color palette
    [SerializeField] public Color colorOn;
    [SerializeField] public Color colorOff;
    [SerializeField] public Color colorTrue;
    [SerializeField] public Color colorFalse;

    private void Start()
    {
        lampVisualizer = GetComponent<LampVisualizer>();
    }

    private void Update()
    {
        if (!coroutineIsRunning)
        {
            // loop through start values
            StartCoroutine("StartValueTimer");
        }
    }

    private IEnumerator StartValueTimer()
    {
        coroutineIsRunning = true;
        yield return new WaitForSeconds(0.75f);

        if (GameManager.mouseDatas.Count == 2)
        {
            StartValues();
            powerSolver.LoopThroughCables(GameManager.mouseDatas);
            lampVisualizer.ChangeLamps();

            foreach (Data mouse in GameManager.mouseDatas)
            {
                mouse.ChangeColor();
            }
        }
        coroutineIsRunning = false;
    }

    public void StartValues()
    {
        switch (index)
        {
            case 0: GameManager.startValue1 = 0; GameManager.startValue2 = 0; break;
            case 1: GameManager.startValue1 = 0; GameManager.startValue2 = 1; break;
            case 2: GameManager.startValue1 = 1; GameManager.startValue2 = 0; break;
            case 3: GameManager.startValue1 = 1; GameManager.startValue2 = 1; break;
        }

        if (index == 3) { index = 0; }
        else { index++; }
    }
}
