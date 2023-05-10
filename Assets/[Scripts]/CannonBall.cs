using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionEffect;

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
        }
        GameObject particle = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
