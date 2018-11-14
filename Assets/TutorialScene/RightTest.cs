using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTest : MonoBehaviour {

  

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit box on the right outside the if-statement");
        if (TutorialText.challengescompleted == 1)
        {
            Debug.Log("Hit box on the right inside if-statement");
            TutorialText.challengescompleted = 2;
            GameObject.FindObjectOfType<TutorialText>().PlayerChallenge03();
        }

    }
}
