using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Level"))
        {
            //make seed stay in place
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        } else if (collision.gameObject.CompareTag("Water")) {
            Debug.Log("Water");
        }
    }
}
