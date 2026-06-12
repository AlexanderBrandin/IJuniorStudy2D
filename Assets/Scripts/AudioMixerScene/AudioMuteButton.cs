using UnityEngine;
using UnityEngine.UI;

public class AudioMuteButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioMixerVolumeController _volumeController;

    private void OnEnable()
    {
        _button.onClick.AddListener(_volumeController.ToggleMute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_volumeController.ToggleMute);
    }
}
