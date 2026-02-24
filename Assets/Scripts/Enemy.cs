using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Transform playerTransform;
    private bool isChasingPlayer = false;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
    }

    void Update()
    {
        if (isChasingPlayer && playerTransform != null)
            ChasePlayer();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasingPlayer = true;
            Debug.Log("Вошел в зону обнаружения игрока.");
        }
    }

    void ChasePlayer()
    {
        transform.DOMove(playerTransform.position, Time.time + Vector2.Distance(transform.position, playerTransform.position) / speed, false).SetSpeedBased();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Столкнулся с игроком!");
            SceneManager.LoadScene(0);
        }
    }
}