using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
