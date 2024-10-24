using UnityEngine;

public class Trash : MonoBehaviour
{
    public float speed;
    private Bounds _cameraBounds;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;
        var size = new Vector3(width, height);
        _cameraBounds = new Bounds(Vector3.zero, size);

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        var newPosition = transform.position;
        var spriteWidth = _spriteRenderer.sprite.bounds.extents.x;

        newPosition.x = Mathf.Clamp(transform.position.x,
            _cameraBounds.min.x + spriteWidth, _cameraBounds.max.x - spriteWidth);

        transform.position = newPosition;
    }
}
