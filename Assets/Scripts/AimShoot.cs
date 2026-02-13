using UnityEngine;

public class AimShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireRare = 2;
    [SerializeField] private Transform _player;
    [SerializeField] private float _timer;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _fireRare)
        {
            Shoot();
            _timer = 0;
        }
    }

    void Shoot()
    {
        Vector2 dir = (_player.position - transform.position).normalized;
        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Init(dir);
    }
}
