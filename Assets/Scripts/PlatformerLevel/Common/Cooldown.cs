using System;
using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public event Action<float> ProgressChanged;
    public event Action Started;
    public event Action Finished;

    [SerializeField] private float _duration;

    private Coroutine _cooldownCoroutine;

    public bool IsReady { get; private set; } = true;

    public void StartCooldown()
    {
        if (IsReady == false)
            return;

        _cooldownCoroutine = StartCoroutine(CountingCooldown());
    }

    private IEnumerator CountingCooldown()
    {
        IsReady = false;
        Started?.Invoke();

        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;

            float progress = elapsedTime / _duration;
            ProgressChanged?.Invoke(progress);

            yield return null;
        }

        ProgressChanged?.Invoke(1f);

        IsReady = true;
        Finished?.Invoke();

        _cooldownCoroutine = null;
    }
}
