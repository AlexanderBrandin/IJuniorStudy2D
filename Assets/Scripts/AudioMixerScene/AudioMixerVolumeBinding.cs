using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[Serializable]
public class AudioMixerVolumeBinding
{
    private const float MinSliderValue = 0.0001f;
    private const float MaxSliderValue = 1f;
    private const float DecibelMultiplier = 20f;
    private const float MutedVolume = -80f;

    [SerializeField] private Slider _slider;
    [SerializeField] private string _volumeParameter;

    private AudioMixer _audioMixer;
    private float _currentValue;

    public void Initialize(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
        _currentValue = _slider.value;

        _slider.onValueChanged.AddListener(SetVolume);
    }

    public void Dispose()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    public void Apply(bool isMuted)
    {
        ApplyVolume(isMuted);
    }

    private void SetVolume(float value)
    {
        _currentValue = value;

        ApplyVolume(false);
    }

    private void ApplyVolume(bool isMuted)
    {
        if (isMuted)
        {
            _audioMixer.SetFloat(_volumeParameter, MutedVolume);
            return;
        }

        float safeValue = Mathf.Clamp(_currentValue, MinSliderValue, MaxSliderValue);
        float volume = Mathf.Log10(safeValue) * DecibelMultiplier;

        _audioMixer.SetFloat(_volumeParameter, volume);
    }
}
