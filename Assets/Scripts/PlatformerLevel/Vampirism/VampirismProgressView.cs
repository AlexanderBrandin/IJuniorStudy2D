using UnityEngine;
using UnityEngine.UI;

public class VampirismProgressView : MonoBehaviour
{
    [SerializeField] private VampirismAbility _ability;
    [SerializeField] private Cooldown _cooldown;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _ability.ProgressChanged += SetProgress;
        _cooldown.ProgressChanged += SetProgress;
        _cooldown.Finished += SetReady;

        SetReady();
    }

    private void OnDisable()
    {
        _ability.ProgressChanged -= SetProgress;
        _cooldown.ProgressChanged -= SetProgress;
        _cooldown.Finished -= SetReady;
    }

    private void SetProgress(float value)
    {
        _slider.value = Mathf.Clamp01(value);
    }

    private void SetReady()
    {
        _slider.value = 1f;
    }
}
