using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private AudioVolumeControl _volumeControl;

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleMute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleMute);
    }

    private void ToggleMute()
    {
        _volumeControl.ToggleMute();
    }
}