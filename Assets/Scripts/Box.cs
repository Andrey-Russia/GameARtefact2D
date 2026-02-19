using UnityEngine;
using DG.Tweening;

public class Box : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private GameObject _fragmentPrefab;
    [SerializeField] private int _fragmentsCount = 8;
    [SerializeField] private float _scatterDistance = 2f;
    [SerializeField] private float _flyDuration = 1f;

    private int currentHealth;

    private void Start()
    {
        currentHealth = _maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            ExplodeIntoFragments();
            Destroy(gameObject);
        }
    }

    private void ExplodeIntoFragments()
    {
        for (int i = 0; i < _fragmentsCount; i++)
        {
            var angle = Mathf.PI * 2 * i / _fragmentsCount;
            var position = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * _scatterDistance;

            var fragment = Instantiate(_fragmentPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180))));

            fragment.transform.DOMove(position, _flyDuration).SetEase(Ease.OutQuad);
        }
    }
}
