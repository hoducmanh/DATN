using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonDontDestroy<SoundManager>
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioSource music;
    protected override void Awake()
    {
        base.Awake();
        music.Play();
        MusicVolumn(PlayerPrefs.GetFloat("Music", 1f));
        SoundVolumn(PlayerPrefs.GetFloat("Sound", 1f));
    }
    public void ClickButton()
    {
        sound.Play();
    }
    public void MusicVolumn(float value)
    {
        music.volume = value;
        PlayerPrefs.SetFloat("Music", value);
    }
    public void SoundVolumn(float value)
    {
        sound.volume = value;
        PlayerPrefs.SetFloat("Sound", value);
    }
}
