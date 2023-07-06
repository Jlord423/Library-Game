using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
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

        theEnemyAI = collision.gameObject.GetComponent<EnemyAI>();
        if (theEnemyAI != null)
        {
            // this is an enemy
            theEnemyAI.TakeDamage(10);
            Debug.Log("Hit!");
        }
        DestroyProjectile();

    }
        
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
