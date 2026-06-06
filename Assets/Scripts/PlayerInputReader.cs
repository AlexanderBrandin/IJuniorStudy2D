using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public event Action JumpPressed;

    public float HorizontalDirection { get; private set; }

    private void Update()
    {
        ReadMovement();
        ReadJump();
    }

    private void ReadMovement()
    {
        if (Keyboard.current == null)
            return;

        HorizontalDirection = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            HorizontalDirection = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            HorizontalDirection = 1f;
    }

    private void ReadJump()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            JumpPressed?.Invoke();
    }
}
