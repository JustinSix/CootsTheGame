using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosJumpSphere : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip jumpSound;
    public float forceStrength = 500;

    //function to apply relative force in opposite direction of collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CAT")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.contacts[0].normal * forceStrength);
            aS.PlayOneShot(jumpSound);
        }
    }
}
