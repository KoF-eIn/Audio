using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private const string MasterParameter = "MasterVolume";

    private const float MinDb = -80f;
    private const float MinLinear = 0.0001f;

    private bool _isMuted;

    private float _lastMasterVolume = 1f;

    public void SetVolume(string parameterName, float linearValue)
    {
        if (_isMuted && parameterName == MasterParameter)
        {
            _lastMasterVolume = linearValue;

            return;
        }

        if (parameterName == MasterParameter)
            _lastMasterVolume = linearValue;

        float db = linearValue > MinLinear ? Mathf.Log10(linearValue) * 20 : MinDb;
        _audioMixer.SetFloat(parameterName, db);
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
            _audioMixer.SetFloat(MasterParameter, MinDb);
        else
            SetVolume(MasterParameter, _lastMasterVolume);
    }
}