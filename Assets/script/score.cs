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
    }
    
    void Update()
    {
        scoreCount += levelCalculation * Time.deltaTime; //Increment the score
        scoreCounter.text = scoreCount.ToString();        
    }
}
