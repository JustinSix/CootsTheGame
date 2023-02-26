using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] int angerToWin;
    [SerializeField] int ludwigsAnger = 0;
    [SerializeField] Slider angerSlider;
    [SerializeField] TMP_Text winningText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text addedAngerText;
    [SerializeField] GameObject outroManager;
    public float timePlaying = 0;
    public bool isPlaying = false;
    private void Update()
    {
        if (isPlaying)
        {
            timePlaying += Time.deltaTime;
            int timePlayingInt = Mathf.RoundToInt(timePlaying);
            timeText.text = "Time:" + timePlayingInt;
        }
    }
    public void StartedPlaying()
    {
        isPlaying = true;
    }
    public void AngerCaused(int anger)
    {
        ludwigsAnger += anger;
        angerSlider.value = (float)ludwigsAnger / (float)angerToWin;
        StartCoroutine(DelayedDisapear());

        if (ludwigsAnger >= angerToWin)
        {
            //win
            WinGame();
        }
    }
    public void WinGame()
    {
        isPlaying = false;
        outroManager.SetActive(true);
    }
    IEnumerator DelayedDisapear()
    {
        addedAngerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        addedAngerText.gameObject.SetActive(false);
    }
}
