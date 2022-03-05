using UnityEngine;

public class KeenBounce : MonoBehaviour
{
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private float _horizontalBounceForce;
    [SerializeField] private float _verticalBounceForce;
    [SerializeField] private Sprite[] _deathSprites;

    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2D;
    private Camera _camera;
    private SpriteRenderer _spriteRenderer;
    
    public GameOver GameOver { get; set; }
    public Score Score { get; set; }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.clip = _deathSound;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _camera = Camera.main;
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        Score.Increment();
        _spriteRenderer.sprite = _deathSprites[Random.Range(0, _deathSprites.Length)];
        _audioSource.Play();
        _rigidbody2D.velocity = new Vector2((transform.position.x - _camera.ScreenToWorldPoint(Input.mousePosition).x) * _horizontalBounceForce, 1 * _verticalBounceForce);
    }

    private void Update()
    {
        Vector2 zeroPoint = _camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 position = transform.position;

        if (position.x > _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
        {
            _rigidbody2D.velocity = new Vector2(-Mathf.Abs(_rigidbody2D.velocity.x), _rigidbody2D.velocity.y);
        }
        else if (position.x < zeroPoint.x)
        {
            _rigidbody2D.velocity = new Vector2(Mathf.Abs(_rigidbody2D.velocity.x), _rigidbody2D.velocity.y);
        }

        if (transform.position.y < zeroPoint.y - 5)
        {
            GameOver.EndGame();
        }
    }
}
