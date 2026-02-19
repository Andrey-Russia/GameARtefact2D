using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _chaseRange = 5f;
    [SerializeField] private float _moveSpeed = 3f;

    private bool _isChasing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _isChasing = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _isChasing = false;
    }

    private void Update()
    {
        if (_isChasing && _playerTransform != null)
            MoveTowardPlayer();
    }

    private void MoveTowardPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _playerTransform.position,
            _moveSpeed * Time.deltaTime
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}