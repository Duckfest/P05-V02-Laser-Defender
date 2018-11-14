using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float health;

    public GameObject projectile;
    public float shotsperSecond;
    public float bombvelocity;
    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;
    // private DifficultyManager difficultyManager;
    private EnemyKillScript enemykillscript;

    public AudioClip crack;
    public AudioClip justahit;
    public GameObject enemyDieEffect;

    void Start()
    {
        scoreKeeper = GameObject.Find("ScoreTxt").GetComponent<ScoreKeeper>();
        enemykillscript = GameObject.Find("EnemyKillTxt").GetComponent<EnemyKillScript>();
      //  difficultyManager = GameObject.Find("DifficultyTxt").GetComponent<DifficultyManager>();
        
    }

    void Update()
    {
        float probability = shotsperSecond * Time.deltaTime;
        if (Random.value < probability)
        {
            Drop();
        }
        
    }

    void Drop()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -0.3f, 0);
        GameObject bomb = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        bomb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bombvelocity);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Projectile laserHit = collider.gameObject.GetComponent<Projectile>();
       //  Debug.Log("laserHit = " + laserHit);
        if (laserHit)

        {
            health -= laserHit.GetFriendlyDamage();
            laserHit.Impact();
            scoreKeeper.Score(scoreValue);
            
            if (health <= 0)
            {

                AudioSource.PlayClipAtPoint(crack, transform.position, 0.1f);
                Instantiate(enemyDieEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
                // Debug.Log(gameObject + "  destroyed");

                enemykillscript.EnemyKills();
                
                
            }
            else
            {
                AudioSource.PlayClipAtPoint(justahit, transform.position, 0.3f);
            }

        }
    }

    
}
