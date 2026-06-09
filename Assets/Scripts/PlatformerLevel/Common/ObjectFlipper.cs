using UnityEngine;

public class ObjectFlipper : MonoBehaviour
{
    private const float RightRotationY = 0f;
    private const float LeftRotationY = 180f;

    public void LookRight()
    {
        transform.rotation = Quaternion.Euler(0f, RightRotationY, 0f);
    }

    public void LookLeft()
    {
        transform.rotation = Quaternion.Euler(0f, LeftRotationY, 0f);
    }
}
