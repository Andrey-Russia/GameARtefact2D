using UnityEngine;

internal class EnemyShooter : MonoBehaviour
{
    [SerializeField]private GameObject _bulletPrefab;

    [SerializeField]private float _fireRate = 1f;

    [SerializeField]private Transform _shootPoint;

    private float _nextFireTime;

    private void Update()
    {
        if (Time.time >= _nextFireTime)
        {
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            _nextFireTime += _fireRate;
        }
    }
}
