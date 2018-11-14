using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShipController : MonoBehaviour
{
    

    // On ship in Unity give coordinates where ship leaves playing field
    private float minX, maxX;
    public float padding;

    public float speed = 6.0f;

    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate;
    public float health;

    public float maxHealth = 1000;
    public Image healthBar; 
    // Now go to your Attacker and Defender and place a Healthcanvas for them

    public AudioClip lasersound;
    public AudioClip shiphit;
    public AudioClip imdying;
    public GameObject shipDieEffect;

    // Use this for initialization
    void Start()
    {
        health = maxHealth; // Set Health to MaxHealth
        healthBar.fillAmount = health / maxHealth;  //Make a first Update to the Image that it shows correct

        CalculateShipPlaySpace();
    }

    void CalculateShipPlaySpace()
    {
        // Calculate size of the playspace for our ship
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minX = leftmost.x + padding;
        
        maxX = rightmost.x - padding;
        // Debug.Log(minX + "  " + maxX);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))            {       MoveLeft();         }
        if (Input.GetKey(KeyCode.LeftArrow))    {       MoveLeft();         }

        if (Input.GetKey(KeyCode.RightArrow))   {       MoveRight();        }
        if (Input.GetKey(KeyCode.D))            {       MoveRight();        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("ShootLaser", 0.0000001f, firingRate);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("ShootLaser");
           
        }

        healthBar.fillAmount = health / maxHealth;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Projectile bombHit = collider.gameObject.GetComponent<Projectile>();
        
        if (bombHit)
        {

            health -= bombHit.GetHostileDamage();
            bombHit.Impact();
            
            if (health <= 0)
            {
                DieFunction();
            }
            else
            {
                AudioSource.PlayClipAtPoint(shiphit, transform.position, 0.3f);
            }
        }
    }

    void MoveLeft()
    {
    transform.position += Vector3.left * speed * Time.deltaTime;
    RestrictMovement();
    }

    void MoveRight()
    {
    transform.position += Vector3.right * speed * Time.deltaTime;
    RestrictMovement();
    }

    void RestrictMovement()
    {
        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void ShootLaser()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(lasersound, transform.position, 0.3f);

    }

    void DieFunction()
    {
        Instantiate(shipDieEffect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(imdying, transform.position);
        Invoke("LevelOnDieFunction", 2);

    }

    void LevelOnDieFunction()
    {
        GameObject.FindObjectOfType<LevelManager>().LoadLevel("06 Game Over");
       
    }
}
