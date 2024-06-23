using UnityEngine;
using UnityEngine.UI;

public class UISettingHome : MonoBehaviour
{
    //[SerializeField] private Toggle sound;
    //[SerializeField] private Toggle music;
    //[SerializeField] private Toggle vibrate;
    [SerializeField] private Button bClose;
    [SerializeField] private Slider sSound;
    [SerializeField] private Slider sMusic;


    private void Awake()
    {
        bClose.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        //sound.onValueChanged.AddListener(AudioManager.Instance.SwitchOnOffSound);
        //music.onValueChanged.AddListener(AudioManager.Instance.SwitchOnOffMusic);
        //vibrate.onValueChanged.AddListener(ViberationManager.Instance.SwitchOnOffVibrate);
    }

    private void OnEnable()
    {
        //sound.isOn = GameDataManager.Instance.SoundState == 0;
        //music.isOn = GameDataManager.Instance.MusicState == 0;
        //vibrate.isOn = GameDataManager.Instance.VibrateState == 0;
    }
}
