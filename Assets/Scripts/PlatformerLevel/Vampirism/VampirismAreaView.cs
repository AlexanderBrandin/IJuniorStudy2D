using UnityEngine;

public class VampirismAreaView : MonoBehaviour
{
    private const float RadiusToDiameterMultiplier = 2f;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private VampirismAreaFollower _follower;

    private void Awake()
    {
        _follower = GetComponent<VampirismAreaFollower>();

        Hide();
    }

    public void Initialize(Transform target, float radius)
    {
        _follower.Initialize(target);
        SetRadius(radius);
    }

    public void Show()
    {
        _spriteRenderer.enabled = true;
    }

    public void Hide()
    {
        _spriteRenderer.enabled = false;
    }

    private void SetRadius(float radius)
    {
        float spriteDiameter = _spriteRenderer.sprite.bounds.size.x;
        float targetDiameter = radius * RadiusToDiameterMultiplier;
        float scale = targetDiameter / spriteDiameter;

        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
