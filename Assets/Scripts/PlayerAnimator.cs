using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsRunningParameter = "IsRunning";

    [SerializeField] private PlayerInputReader _inputReader;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        bool isRunning = _inputReader.HorizontalDirection != 0f;

        _animator.SetBool(IsRunningParameter, isRunning);
    }
}
