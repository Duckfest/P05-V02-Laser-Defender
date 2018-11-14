using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject shipHitEffect;
    

    public float damage;

    public float GetFriendlyDamage()
    {
   //      Debug.Log("Friendly projectile reports " + damage + " damage");
        return damage;
       
    }

    public float GetHostileDamage()
    {
   //      Debug.Log("Enemy projectile reports " + damage + " damage");
        return damage;

    }

    public void Impact()
    {
       Debug.Log("Impact. projectile is going to destroy gameObject " + gameObject);
       
        Instantiate(shipHitEffect, transform.position, Quaternion.identity);
        
         Destroy(gameObject);
    }

   
}
