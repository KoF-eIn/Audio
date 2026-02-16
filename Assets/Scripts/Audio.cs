using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    private const string MasterParam = "MasterVolume";
    private const string ButtonsParam = "ButtonsVolume";
    private const string MusicParam = "MusicVolume";

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _buttonsVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    [Header("Mute Button")]
    [SerializeField] private Button _muteButton;
    [SerializeField] private Text _muteButtonText;

    [Header("Sound Buttons")]
    [SerializeField] private Button[] _soundButtons;
    [SerializeField] private AudioSource[] _buttonSources; 

    [Header("Background Music")]
    [SerializeField] private AudioSource _musicSource;

    private bool _isMuted = false;
    private float _lastMasterVolume = 1f;

    private void Start()
    {
        _masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        _buttonsVolumeSlider.onValueChanged.AddListener(SetButtonsVolume);
        _musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);

        _masterVolumeSlider.value = 1f;
        _buttonsVolumeSlider.value = 1f;
        _musicVolumeSlider.value = 1f;

        SetMasterVolume(1f);
        SetButtonsVolume(1f);
        SetMusicVolume(1f);

        for (int i = 0; i < _soundButtons.Length; i++)
        {
            int index = i;
            _soundButtons[i].onClick.AddListener(() => PlayButtonSound(index));
        }

        _muteButton.onClick.AddListener(ToggleMute);

        if (_musicSource != null && !_musicSource.isPlaying)
            _musicSource.Play();
    }

    private void SetMasterVolume(float value)
    {
        _lastMasterVolume = value;
        if (!_isMuted)
            _audioMixer.SetFloat(MasterParam, Mathf.Log10(value) * 20);
    }

    private void SetButtonsVolume(float value)
    {
        _audioMixer.SetFloat(ButtonsParam, Mathf.Log10(value) * 20);
    }

    private void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat(MusicParam, Mathf.Log10(value) * 20);
    }

    private void PlayButtonSound(int index)
    {
        if (index >= 0 && index < _buttonSources.Length && _buttonSources[index] != null)
            _buttonSources[index].Play();
    }

    private void ToggleMute()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            _audioMixer.SetFloat(MasterParam, -80f);

            if (_muteButtonText != null) _muteButtonText.text = "Включить звук";
        }
        else
        {
            // Восстанавливаем громкость из слайдера
            _audioMixer.SetFloat(MasterParam, Mathf.Log10(_masterVolumeSlider.value) * 20);

            if (_muteButtonText != null) _muteButtonText.text = "Выключить звук";
        }
    }
}