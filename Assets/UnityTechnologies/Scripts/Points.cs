using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collect playerInventory = other.GetComponent<Collect>();
        if(playerInventory != null)
        {
            playerInventory.DiamonCollected();
            gameObject.SetActive(false);
        }
    }
}
