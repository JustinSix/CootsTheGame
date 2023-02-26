using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    public static AudioManager instance;
    [SerializeField] AudioSource aS;
    [SerializeField] AudioClip[] shipClipArray;
    [SerializeField] AudioClip[] forestClipArray;
    [SerializeField] AudioClip[] desertClipArray;
    [SerializeField] AudioClip[] slimeClipArray;
    [SerializeField] AudioClip[] shroomClipArray;
    [SerializeField] AudioClip[] menuClipArray;
    [SerializeField] AudioClip[] meditationClipArray;
    [SerializeField] AudioClip[] introSequenceClipArray;

    public string biome = "Ship"; // ship forest desert slime 

    bool doOnce = false;
    void Awake()
    {
        if (AudioManager.instance == null)
        {
            DontDestroyOnLoad(gameObject);
            AudioManager.instance = this;
        }
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //get the saved music volume, standard = 10f
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 10f);
        float fxVolume = PlayerPrefs.GetFloat("FXVolume", 10f);
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 10f);

        //set the music volume to the saved volume 
        AdjustMusicVolume(musicVolume);
        AdjustFXVolume(fxVolume);
        AdjustMasterVolume(masterVolume);
        AudioClip aC = null;
        ChooseAudio(aC);
    }
    public void AdjustMasterVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("MasterVolume", volume);
        //Save changes
        PlayerPrefs.Save();
    }
    public void AdjustMusicVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("MusicVolume", volume);
        //Save changes
        PlayerPrefs.Save();
    }
    public void AdjustFXVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("FXVolume", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("FXVolume", volume);
        //Save changes
        PlayerPrefs.Save();
    }
    public void ChooseAudio(AudioClip aC)
    {
        StopAllCoroutines();
        AudioClip chosenAudio = aS.clip;
        if (aC == null)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "Discworlds")
            {
                //Biomes ship forest desert slime 
                switch (biome)
                {
                    case "Ship":
                        int rNumSh = Random.Range(0, shipClipArray.Length);
                        chosenAudio = shipClipArray[rNumSh];
                        break;
                    case "Lush":
                        int rNumF = Random.Range(0, shipClipArray.Length);
                        chosenAudio = forestClipArray[rNumF];
                        break;
                    case "Desert":
                        int rNumD = Random.Range(0, shipClipArray.Length);
                        chosenAudio = desertClipArray[rNumD];
                        break;
                    case "Slime":
                        int rNumSl = Random.Range(0, shipClipArray.Length);
                        chosenAudio = slimeClipArray[rNumSl];
                        break;
                    case "Shroom":
                        int rNumShr = Random.Range(0, shipClipArray.Length);
                        chosenAudio = shroomClipArray[rNumShr];
                        break;
                    default:
                        Debug.LogError("No biome");
                        break;
                }

            }
            if (sceneName == "Menu")
            {
                int rNum = Random.Range(0, menuClipArray.Length);
                chosenAudio = menuClipArray[rNum];
            }
        }
        else
        {
            chosenAudio = aC;
        }
        aS.clip = chosenAudio;
        aS.Stop();
        aS.Play();
        StartCoroutine(WaitForAudioToFinishThenPlayNew(chosenAudio.length));
    }

    IEnumerator WaitForAudioToFinishThenPlayNew(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        AudioClip aC = null;
        ChooseAudio(aC);
    }


}
