using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

    private Text myText;

    public static int challengescompleted = 0;
    
    void Start()
    {
        myText = GetComponent<Text>();
        PlayerChallenge01();
    }

    void PlayerChallenge01()
    {
        Debug.Log("Challenges completed " + challengescompleted);
        myText.text = ("First challenge \n \n PRESS A or LEFT ARROW TO MOVE YOUR SHIP LEFT");
    }

    public void PlayerChallenge02()
    {
        Debug.Log("Challenges completed " + challengescompleted);
        myText.text = ("Challenge completed \n \n PRESS D or RIGHT ARROW TO MOVE YOUR SHIP RIGHT");
     }
      


    public void PlayerChallenge03()
    {
        Debug.Log("Challenges completed " + challengescompleted);
        myText.text = ("Challenge completed \n \n PRESS SPACE TO FIRE \n \n Basic enemy can be killed in 3 shots");
        GameObject.FindObjectOfType<TutorialSpawner>().TutorialSpawnEnemy01();
        
    }

    public void PlayerChallenge04()
    {
        Debug.Log("Challenges completed " + challengescompleted);
        myText.text = ("Challenge completed \n \n PRESS SPACE TO FIRE \n \n Second enemy can be killed in 12 shots");
        GameObject.FindObjectOfType<TutorialSpawner>().TutorialSpawnEnemy02();
    }

    public void PlayerChallenge05()
    {
        Debug.Log("Challenges completed " + challengescompleted);
        myText.text = ("Challenge completed \n \n You can now click on GAME button to play the game");
    }
        
}
