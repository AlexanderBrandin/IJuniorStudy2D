using UnityEngine;
using UnityEngine.UI;

public class VampirismProgressView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        SetReady();
    }

    public void SetProgress(float value)
    {
        _slider.value = Mathf.Clamp01(value);
    }

    public void SetReady()
    {
        _slider.value = 1f;
    }
}
