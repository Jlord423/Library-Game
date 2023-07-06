using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : MonoBehaviour
{
    private int bookCollect = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup")) //pickup and destroy books
        {
            Destroy(other.gameObject);
            bookCollect = bookCollect + 1;
            Debug.Log(bookCollect);
        }
    }
}
