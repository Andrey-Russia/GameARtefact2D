using UnityEngine;

public class AimShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireInterval = 1f;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _playerTarget;

    private float _lastShotTime;

    private void Update()
    {
        if (Time.timeSinceLevelLoad - _lastShotTime >= _fireInterval)
        {
            var bulletInstance = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            var direction = (_playerTarget.position - _shootPoint.position).normalized;
            bulletInstance.GetComponent<Bullet>().SetDirection(direction);
            _lastShotTime = Time.timeSinceLevelLoad;
        }
    }
}
