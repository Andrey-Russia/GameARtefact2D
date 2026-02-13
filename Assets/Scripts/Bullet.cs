using NUnit.Framework.Internal.Builders;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTimt = 3f;

    private GameObject owner;

    private void Start()
    {
        Destroy(gameObject, _lifeTimt);
    }

    public void Init(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().linearVelocity = direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
            SceneManager.LoadScene(0);
        else if (other.CompareTag("Enemy"))
            Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
