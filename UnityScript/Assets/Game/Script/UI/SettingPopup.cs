
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    [SerializeField] private Slider sSound;
    [SerializeField] private Slider sMusic;
    private void OnEnable()
    {
        sSound.value = PlayerPrefs.GetFloat("Sound", 1f);
        sMusic.value = PlayerPrefs.GetFloat("Music", 1f);
    }
    public void SetMusicValue()
    {
        SoundManager.Instance.MusicVolumn(sMusic.value);
    }
    public void SetSoundValue()
    {
        SoundManager.Instance.SoundVolumn(sSound.value);
    }
}
