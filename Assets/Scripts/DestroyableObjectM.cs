using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjectM : MonoBehaviour
{
    [SerializeField] AudioClip breakSFX;
    [SerializeField] AudioSource aS;
    [SerializeField] GameManager gM;
    [SerializeField] int anger;
    [SerializeField] GameObject nonBrokenO;
    [SerializeField] GameObject[] brokenPieces;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CAT" || other.gameObject.tag == "Destroyable")
        {
            BreakItStuff();
        }
    }

    private void BreakItStuff()
    {
        foreach (GameObject brokenPiece in brokenPieces)
        {
            brokenPiece.SetActive(true);
            brokenPiece.transform.parent = null;
        }

        gM.AngerCaused(anger);

        aS.PlayOneShot(breakSFX);

        nonBrokenO.SetActive(false);
    }
}
