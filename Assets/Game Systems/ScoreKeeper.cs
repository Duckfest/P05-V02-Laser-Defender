using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score;
    
    private Text myText;

    void Start()
    {
        Text myText = GetComponent<Text>();
        myText.text = "Score " + score.ToString();
        Reset();

    }

    public void Score(int points)
    {
        score += points;
        Text myText = GetComponent<Text>();
        myText.text = "Score " + score.ToString(); 
    }

	public static void Reset()
    {
        score = 0;
    }
}
