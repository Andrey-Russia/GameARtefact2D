using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private GameObject playerTarget;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private Transform gunPosition;

    private float nextFireTime;

    private void Update()
    {
        if (playerTarget != null && Vector2.Distance(transform.position, playerTarget.transform.position) <= detectionRadius)
        {
            ShootAtPlayer();
        }
    }

    private void ShootAtPlayer()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            var bulletInstance = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            Vector2 directionToPlayer = (Vector2)(playerTarget.transform.position - transform.position).normalized;
            bulletInstance.GetComponent<Bullet1>().SetDirection(directionToPlayer);
        }
    }
}