using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {


        EnemyAI theEnemyAI;
        PlayerController thePlayer;

        theEnemyAI = collision.gameObject.GetComponent<EnemyAI>();
        if (theEnemyAI != null)
        {
            // this is an enemy
        }

        thePlayer = collision.gameObject.GetComponent<PlayerController>();
        if (thePlayer != null)
        {
            //Debug.Log("Hit!");
            // this is the player
            thePlayer.TakeDamage(10);
        }

    }

}
