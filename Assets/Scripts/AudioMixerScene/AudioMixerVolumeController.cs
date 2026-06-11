using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerVolumeController : MonoBehaviour
{
    private const float MinSliderValue = 0.0001f;
    private const float DecibelMultiplier = 20f;
    private const float MutedVolume = -80f;

    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _buttonsVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    [SerializeField] private string _masterVolumeParameter;
    [SerializeField] private string _buttonsVolumeParameter;
    [SerializeField] private string _musicVolumeParameter;

    private bool _isMuted;
    private float _masterVolume;
    private float _buttonsVolume;
    private float _musicVolume;

    private void OnEnable()
    {
        _masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        _buttonsVolumeSlider.onValueChanged.AddListener(SetButtonsVolume);
        _musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void Start()
    {
        _masterVolume = _masterVolumeSlider.value;
        _buttonsVolume = _buttonsVolumeSlider.value;
        _musicVolume = _musicVolumeSlider.value;

        ApplyAllVolumes();
    }

    private void OnDisable()
    {
        _masterVolumeSlider.onValueChanged.RemoveListener(SetMasterVolume);
        _buttonsVolumeSlider.onValueChanged.RemoveListener(SetButtonsVolume);
        _musicVolumeSlider.onValueChanged.RemoveListener(SetMusicVolume);
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        ApplyAllVolumes();
    }

    private void SetMasterVolume(float value)
    {
        _masterVolume = value;

        ApplyVolume(_masterVolumeParameter, _masterVolume);
    }

    private void SetButtonsVolume(float value)
    {
        _buttonsVolume = value;

        ApplyVolume(_buttonsVolumeParameter, _buttonsVolume);
    }

    private void SetMusicVolume(float value)
    {
        _musicVolume = value;

        ApplyVolume(_musicVolumeParameter, _musicVolume);
    }

    private void ApplyAllVolumes()
    {
        ApplyVolume(_masterVolumeParameter, _masterVolume);
        ApplyVolume(_buttonsVolumeParameter, _buttonsVolume);
        ApplyVolume(_musicVolumeParameter, _musicVolume);
    }

    private void ApplyVolume(string parameterName, float sliderValue)
    {
        if (_isMuted)
        {
            _audioMixer.SetFloat(parameterName, MutedVolume);
            return;
        }

        float safeValue = Mathf.Clamp(sliderValue, MinSliderValue, 1f);
        float volume = Mathf.Log10(safeValue) * DecibelMultiplier;

        _audioMixer.SetFloat(parameterName, volume);
    }
}
