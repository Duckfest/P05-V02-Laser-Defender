using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKillScript : MonoBehaviour
{

    public static int enemykills;


    private Text myText;

    void Start()
    {
        Text myText = GetComponent<Text>();
        myText.text = "Kills " + enemykills.ToString();
        Reset();
    }

    public void EnemyKills()
    {
        EnemyKillCounter();
        EnemyKillWinConditionChecker();
        GameObject.FindObjectOfType<DifficultyManager>().DetermineDifficulty();
    }

    void EnemyKillWinConditionChecker()
    {

        if (enemykills == 1 && TutorialText.challengescompleted == 2)
        {
            Debug.Log("First blood!");
            TutorialText.challengescompleted = 3;
            GameObject.FindObjectOfType<TutorialText>().PlayerChallenge04();
        }

        if (enemykills == 2 && TutorialText.challengescompleted == 3)
        {
            Debug.Log("Second blood!");
            TutorialText.challengescompleted = 4;
            GameObject.FindObjectOfType<TutorialText>().PlayerChallenge05();
        }

    }



    void EnemyKillCounter()
    {
        enemykills += 1;
        Text myText = GetComponent<Text>();
        myText.text = "Kills " + enemykills.ToString();
        
    }

    public static void Reset()
    {
        enemykills = 0;
    }
}