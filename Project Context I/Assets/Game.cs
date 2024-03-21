using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int index;
    private bool coroutineIsRunning = false;
    private LampVisualizer lampVisualizer;
    private PowerSolver powerSolver;

    public GameObject sourcePrefab;
    public GameObject outputPrefab;

    public bool checkAnswer = false;
    public int[,] answer = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
    public bool won = true;

    private void Start()
    {
        lampVisualizer = GetComponent<LampVisualizer>();
        powerSolver = GetComponent<PowerSolver>();

        InstantiateSources();
        lampVisualizer.GetSourceSprite();
    }

    private void Update()
    {
        if (!coroutineIsRunning)
        {
            // loop through start values
            StartCoroutine("StartValueTimer");
        }
    }

    private void InstantiateSources()
    {
        for (int i = 0; i < 2; i++)
        {
            GameManager.sources.Add(Instantiate(sourcePrefab));
        }

        GameManager.sources[0].transform.position = new Vector3(-5, 1.7f);
        GameManager.sources[1].transform.position = new Vector3(-5, -1.7f);
    }

    private IEnumerator StartValueTimer()
    {
        coroutineIsRunning = true;
        yield return new WaitForSeconds(1f);

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

    public void CheckAnswers()
    {
        if (GameManager.mouseDatas[0].outputed == true && GameManager.mouseDatas[1].outputed == true && index == 0)
        {
            checkAnswer = true;
        }

        if (checkAnswer == true)
        {
            if (GameManager.mouseDatas[0].value != answer[index, 0] || GameManager.mouseDatas[1].value != answer[index, 1])
            {
                won = false;
            }

            if (index == 3)
            {
                if (won == true)
                {
                    Debug.Log("You won!");
                } else { Debug.Log("You lose");  }
            }
        }
    }
}
