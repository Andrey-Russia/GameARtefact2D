using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Transform _player;
    private bool _is;

    private void Update()
    {
        if (_is && _player != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                _player.position,
                _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.transform;
            _is = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
