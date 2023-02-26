using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OutroManager : MonoBehaviour
{
    public GameManager gM;
    public AudioSource musicAS;
    public Image blackImage;
    public TMP_Text winText;
    public GameObject basketball;
    public GameObject buttonMenu;
    public GameObject ludwigObject;
    // Start is called before the first frame update
    void Start()
    {
        musicAS.Stop();
        basketball.SetActive(false);
        ludwigObject.SetActive(false);
        StartCoroutine(FadeInBlack());
    }

    void EnableEnd()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winText.gameObject.SetActive(true);
        winText.text = "Coots ended stream in " + gM.timePlaying + " seconds!";
    }
    IEnumerator FadeInBlack()
    {
        for (float alpha  = 0f; alpha < 1; alpha += Time.deltaTime)
        {
            blackImage.color = new Color(0, 0,0,alpha);
            yield return null;
        }
        blackImage.color = new Color(0, 0, 0, 1);
        EnableEnd();
        yield return new WaitForSeconds(1f);
        buttonMenu.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("LudwigsRoom");
    }
}
