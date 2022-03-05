using UnityEngine;

public class KeenIdle : MonoBehaviour
{
    [SerializeField] private KeenBounce _keenBounce;
    [SerializeField] private GameObject _text;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private Score _score;

    private void OnMouseDown()
    {
        Destroy(_text);
        var keenBounce = Instantiate(_keenBounce, transform.position, Quaternion.identity);
        keenBounce.Score = _score;
        keenBounce.GameOver = _gameOver;
        Destroy(gameObject);
    }
}
