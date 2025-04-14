using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider masterSlider;//main volume

    static float musicVolume = 1f;
    static float sfxVolume = 1f;
    static float masterVolume = 1f;

    // Start is called before the first frame update
    void Start(){
        

    }

    private void OnEnable()
    {
        // Load the saved volume settings
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", musicVolume);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", sfxVolume);
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", masterVolume);
    }

    void OnDisable(){
        // Save the current volume settings
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    /// <summary>
    /// change the volume of the music when the slider is moved
    /// </summary>
    void Awake(){
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    // set the volume
    void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10( volume)*20);
    }

    void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
