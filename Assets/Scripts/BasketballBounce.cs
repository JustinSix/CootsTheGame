using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballBounce : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip aC;

    bool bouncing = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (!bouncing)
        {
            bouncing = true;
            StartCoroutine(BounceSound());
        }
    }
    IEnumerator BounceSound()
    {
        aS.PlayOneShot(aC);
        yield return new WaitForSeconds(1);
        bouncing = false;
    }
}
