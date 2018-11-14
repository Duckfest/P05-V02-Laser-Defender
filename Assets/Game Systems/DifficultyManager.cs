using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{

    public static int difficulty = 1;

    public static bool waveOneAllowed;
    public static bool waveTwoAllowed;
    public static bool waveThreeAllowed;
    public static bool waveFourAllowed;
    public static bool waveFiveAllowed;
    public static bool waveSixAllowed;
    public static bool waveSevenAllowed;
    public static bool waveEightAllowed;


    private Text myText;

    void Start()
    {
        Reset();
        Text myText = GetComponent<Text>();
        myText.text = "Difficulty " + difficulty.ToString();
 
        OnDifficultyOne();

    }

    public void UpdateDifficulty()
    {
        Text myText = GetComponent<Text>();
        myText.text = "Difficulty " + difficulty.ToString();
    }

    public void DetermineDifficulty()
    {
        if (EnemyKillScript.enemykills == 10) { OnDifficultyTwo(); } 
        if (EnemyKillScript.enemykills == 20) { OnDifficultyThree();  }
        if (EnemyKillScript.enemykills == 40) { OnDifficultyFour(); }
        if (EnemyKillScript.enemykills == 45) { OnDifficultyFive(); }
        if (EnemyKillScript.enemykills == 55) { OnDifficultySix(); }
        if (EnemyKillScript.enemykills == 90) { OnDifficultySeven(); }
        if (EnemyKillScript.enemykills == 100) { OnDifficultyEight(); }
    }

    void OnDifficultyOne() // until 10
    {
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " One true, rest false");
        waveOneAllowed = true;
        waveTwoAllowed = false;
        waveThreeAllowed = false;
        waveFourAllowed = false; 
        waveFiveAllowed = false; 
        waveSixAllowed = false;
        waveSevenAllowed = false;
        waveEightAllowed = false;
}

    void OnDifficultyTwo() // 10 to 20
    {
        difficulty = 2;
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " Two true, rest false");
        waveOneAllowed = false;
        waveTwoAllowed = true;
        waveThreeAllowed = false;
        waveFourAllowed = false; 
        waveFiveAllowed = false; 
        waveSixAllowed = false;
        waveSevenAllowed = false;
        waveEightAllowed = false;

        UpdateDifficulty();
    }

    void OnDifficultyThree() // 20-40
    {
        difficulty = 3;
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " One, Two true, rest false");
        waveOneAllowed = true;
        waveTwoAllowed = true;
        waveThreeAllowed = false;
        waveFourAllowed = false; 
        waveFiveAllowed = false; 
        waveSixAllowed = false;
        waveSevenAllowed = false;
        waveEightAllowed = false;


        UpdateDifficulty();
        
    }

    void OnDifficultyFour() //40-45 One big hitter
    {
        difficulty = 4;
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " Three true, rest false");
        waveOneAllowed = false;
        waveTwoAllowed = false;
        waveThreeAllowed = true;
        waveFourAllowed = false; 
        waveFiveAllowed = false; 
        waveSixAllowed = false;
        waveSevenAllowed = false;
        waveEightAllowed = false;

        UpdateDifficulty();
    }

    void OnDifficultyFive() // heavy hitting from 45-55
    {
        difficulty = 5;
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " Three, five true, rest false heavy hitting from 45-55");
        waveOneAllowed = false;
        waveTwoAllowed = false;
        waveThreeAllowed = true;
        waveFourAllowed = false; 
        waveFiveAllowed = true; 
        waveSixAllowed = false;
        waveSevenAllowed = false;
        waveEightAllowed = false;
        
        UpdateDifficulty();
    }

    void OnDifficultySix() // spam the field from 56-90
    {

        difficulty = 6;
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " one two and four allowed spam the field from 56-90");
        waveOneAllowed = true;
        waveTwoAllowed = true;
        waveThreeAllowed = false;
        waveFourAllowed = true; 
        waveFiveAllowed = false; 
        waveSixAllowed = false;
        waveSevenAllowed = false;
        waveEightAllowed = false;
        
        UpdateDifficulty();
    }

    void OnDifficultySeven() // Wave six, big hitters
    {
        difficulty = 7;
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " Six True, rest false  Wave six, big hitters");
        waveOneAllowed = false;
        waveTwoAllowed = false;
        waveThreeAllowed = false;
        waveFourAllowed = false;
        waveFiveAllowed = false;
        waveSixAllowed = true;
        waveSevenAllowed = false;
        waveEightAllowed = false;
       
        UpdateDifficulty();
    }

    void OnDifficultyEight() // add enemy spawn shield to the mix
    {
        difficulty = 8;
        Debug.Log("Kills " + EnemyKillScript.enemykills + " Difficulty " + difficulty + " Big six true, two and four also");
        waveOneAllowed = false;
        waveTwoAllowed = true;
        waveThreeAllowed = false;
        waveFourAllowed = true;
        waveFiveAllowed = true;
        waveSixAllowed = true;
        waveSevenAllowed = false;
        waveEightAllowed = false;

        UpdateDifficulty();
    }

    public static void Reset()
    {
        difficulty = 1;
    }
}