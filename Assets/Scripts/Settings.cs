using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [Header("Audio")]
    public GameObject sliders;
    public GameObject quitButton;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider fxVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider ludVolumeSlider;
    private bool menuOpen = false;
    public GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        //Volume
        AdjustMasterVolume(PlayerPrefs.GetFloat("Master", 1f));
        AdjustMusicVolume(PlayerPrefs.GetFloat("Music", 1f));
        AdjustFXVolume(PlayerPrefs.GetFloat("SoundEffects", 1f));
        AdjustLudVolume(PlayerPrefs.GetFloat("LudsVoice", 1f));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenCloseSettings();
        }
    }
    public void OpenCloseSettings()
    {
        if (menuOpen)
        {
            sliders.SetActive(false);
            menuOpen = false;
            Time.timeScale = 1;
            if (gM.isPlaying)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                quitButton.SetActive(false);
            }
            else
            {

            }
        }
        else
        {
            sliders.SetActive(true);
            quitButton.SetActive(true); 
            menuOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }



    public void AdjustMasterVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("Master", volume);
        //Save changes
        PlayerPrefs.Save();
    }
    public void AdjustMusicVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("Music", volume);
        //Save changes
        PlayerPrefs.Save();
    }
    public void AdjustFXVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("SoundEffects", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("SoundEffects", volume);
        //Save changes
        PlayerPrefs.Save();
    }
    public void AdjustLudVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("LudsVoice", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("LudsVoice", volume);
        //Save changes
        PlayerPrefs.Save();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
