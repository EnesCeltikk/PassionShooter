using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Bullet")
        {
            GetComponent<PlayerHealth>().TakeDamage(20);
        }
    }
}
