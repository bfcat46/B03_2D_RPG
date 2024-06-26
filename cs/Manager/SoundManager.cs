using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip gameMusic;
    public GameObject OnButton;
    public GameObject OffButton;

    bool isMuted = false;

    private void Awake()
    {
        EventBus.VolumeChange.AddListener(ChangeVolume);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void SoundMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }

    public void ButtonOnOff()
    {
        if (isMuted)
        {
            OnButton.SetActive(true);
            OffButton.SetActive(false);
        }
        else
        {
            OnButton.SetActive(false);
            OffButton.SetActive(true);
        }
    }

    void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
