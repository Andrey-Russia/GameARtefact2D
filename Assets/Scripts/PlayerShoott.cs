using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerShoott : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireRate = 0.25f;

    private float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Fire()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePosition - transform.position).normalized;

        var bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
    }
}
