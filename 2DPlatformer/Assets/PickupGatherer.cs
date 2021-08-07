using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGatherer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pickup")
        {
            Debug.Log(collision.gameObject.GetComponent<Pickup>().healthPickData.Health);
            Destroy(collision.gameObject);
        }
    }
}
