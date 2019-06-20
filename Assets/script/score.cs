using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public float level = 1f;
    public float scoreCount = 0f;
    public float levelCalculation;
    [SerializeField] Text scoreCounter;
    
    void Start()
    {
        levelCalculation = level / 10;
        scoreCounter = GameObject.Find("scoreboard").GetComponent<Text>();
    }

    void Update()
    {
        if (FindObjectOfType<GManager>().playing() && !FindObjectOfType<GManager>().pausing()) {
        scoreCount += levelCalculation; //Increment the score
        scoreCounter.text = scoreCount.ToString("n0");
        }

        //Debug.Log("score " + scoreCount.ToString("n1"));
    }

    void multiplier()
    {
        level += 0.2f;
    }
}
