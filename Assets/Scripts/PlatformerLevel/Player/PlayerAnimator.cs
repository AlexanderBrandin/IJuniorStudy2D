using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetRunning(bool isRunning)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, isRunning);
    }
}
