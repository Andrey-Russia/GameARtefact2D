using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet1 : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 4f;
    [SerializeField] private float _lifetime = 3f;

    private Vector2 _direction;

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        transform.Translate(_direction * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            SceneManager.LoadScene(0);

        Destroy(gameObject);
    }


}