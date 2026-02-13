using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoott : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firepoint;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Shoot();
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = (mousePos - transform.position).normalized;

        GameObject bullet = Instantiate(_bullet, _firepoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Init(direction);
    }
}
