using UnityEngine;
using UnityEngine.UI;

public class AudioInitializer : MonoBehaviour
{
    [SerializeField] private AudioVolumeControl _volumeControl;

    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _buttonsSlider;
    [SerializeField] private Slider _musicSlider;

    [SerializeField] private AudioSource _backgroundMusic;

    private void OnEnable()
    {
        _masterSlider.onValueChanged.AddListener(_volumeControl.SetMasterVolume);
        _buttonsSlider.onValueChanged.AddListener(_volumeControl.SetButtonsVolume);
        _musicSlider.onValueChanged.AddListener(_volumeControl.SetMusicVolume);

        _masterSlider.value = 1f;
        _buttonsSlider.value = 1f;
        _musicSlider.value = 1f;
    }

    private void OnDisable()
    {
        _masterSlider.onValueChanged.RemoveListener(_volumeControl.SetMasterVolume);
        _buttonsSlider.onValueChanged.RemoveListener(_volumeControl.SetButtonsVolume);
        _musicSlider.onValueChanged.RemoveListener(_volumeControl.SetMusicVolume);
    }

    private void Start()
    {
        if (_backgroundMusic != null && !_backgroundMusic.isPlaying)
            _backgroundMusic.Play();
    }
}