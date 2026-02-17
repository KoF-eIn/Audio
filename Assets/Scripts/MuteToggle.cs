using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private Button _muteButton;

    [SerializeField] private AudioVolumeControl _volumeControl;

    private void OnEnable()
    {
        _muteButton.onClick.AddListener(ToggleMute);
    }

    private void OnDisable()
    {
        _muteButton.onClick.RemoveListener(ToggleMute);
    }

    private void ToggleMute()
    {
        _volumeControl.ToggleMute();
    }
}