using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTest : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit box on the left outise if-statement");
        if (TutorialText.challengescompleted == 0)
        {
            Debug.Log("Hit box on the left inside if-statement");
            TutorialText.challengescompleted = 1;
            GameObject.FindObjectOfType<TutorialText>().PlayerChallenge02();
        }
            
    }
}
