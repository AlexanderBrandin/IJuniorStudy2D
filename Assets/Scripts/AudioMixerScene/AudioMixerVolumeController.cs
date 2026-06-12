using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerVolumeBinding[] _volumeBindings;

    private bool _isMuted;

    private void OnEnable()
    {
        foreach (AudioMixerVolumeBinding volumeBinding in _volumeBindings)
            volumeBinding.Initialize(_audioMixer);
    }

    private void Start()
    {
        ApplyVolumes();
    }

    private void OnDisable()
    {
        foreach (AudioMixerVolumeBinding volumeBinding in _volumeBindings)
            volumeBinding.Dispose();
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        ApplyVolumes();
    }

    private void ApplyVolumes()
    {
        foreach (AudioMixerVolumeBinding volumeBinding in _volumeBindings)
            volumeBinding.Apply(_isMuted);
    }
}
