using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;

    [SerializeField] private AudioSource _source1;
    [SerializeField] private AudioSource _source2;
    [SerializeField] private AudioSource _source3;

    private void OnEnable()
    {
        _button1.onClick.AddListener(PlaySound1);
        _button2.onClick.AddListener(PlaySound2);
        _button3.onClick.AddListener(PlaySound3);
    }

    private void OnDisable()
    {
        _button1.onClick.RemoveListener(PlaySound1);
        _button2.onClick.RemoveListener(PlaySound2);
        _button3.onClick.RemoveListener(PlaySound3);
    }

    private void PlaySound1() => _source1?.Play();
    private void PlaySound2() => _source2?.Play();
    private void PlaySound3() => _source3?.Play();
}