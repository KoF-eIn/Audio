using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private const string MasterParam = "MasterVolume";
    private const string ButtonsParam = "ButtonsVolume";
    private const string MusicParam = "MusicVolume";

    private const float MinDb = -80f;
    private const float MinLinear = 0.0001f;

    private bool _isMuted;

    private float _lastMasterVolume = 1f;

    public void SetMasterVolume(float linearValue)
    {
        _lastMasterVolume = linearValue;

        if (!_isMuted)
            ApplyVolume(MasterParam, linearValue);
    }

    public void SetButtonsVolume(float linearValue)
    {
        ApplyVolume(ButtonsParam, linearValue);
    }

    public void SetMusicVolume(float linearValue)
    {
        ApplyVolume(MusicParam, linearValue);
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
            _audioMixer.SetFloat(MasterParam, MinDb);
        else
            ApplyVolume(MasterParam, _lastMasterVolume);
    }

    private void ApplyVolume(string param, float linearValue)
    {
        float db = linearValue > MinLinear ? Mathf.Log10(linearValue) * 20 : MinDb;
        _audioMixer.SetFloat(param, db);
    }
}