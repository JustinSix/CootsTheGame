using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudwigClipPlayer : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip[] ludClipsArray;
    public void StartPlayingClips()
    {
        StartCoroutine(PlayRandomAudio());
    }

    IEnumerator PlayRandomAudio()
    {
        AudioClip rClip = ludClipsArray[Random.Range(0, ludClipsArray.Length)];

        aS.PlayOneShot(rClip); 

        yield return new WaitForSeconds(rClip.length);

        StartCoroutine(PlayRandomAudio());
    }
}
