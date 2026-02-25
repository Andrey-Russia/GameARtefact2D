using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float startSpeed = 1f;
    [SerializeField] private float targetSpeed = 3f;
    [SerializeField] private float accelerationTime = 5f;
    private Transform playerTransform;
    private bool isChasingPlayer = false;
    private Tweener movementTweener;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
    }

    void Update()
    {
        if (isChasingPlayer && playerTransform != null)
            FollowPlayer();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isChasingPlayer = true;
            StartAccelerationSequence();
    }

    void StartAccelerationSequence()
    {
        movementTweener?.Kill();
        movementTweener = DOTween.To(
            () => startSpeed,
            x => startSpeed = x,
            targetSpeed,
            accelerationTime
        ).SetRelative().SetEase(Ease.OutQuad);
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, startSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(0);
    }
}