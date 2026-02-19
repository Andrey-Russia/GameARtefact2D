using UnityEngine;
using UnityEngine.SceneManagement;

public class Fragment : MonoBehaviour
{
    [SerializeField] private float fragmentSpeed = 5f;
    [SerializeField] private float lifetime = 2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * fragmentSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);                                
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}