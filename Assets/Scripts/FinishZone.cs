using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Button _restartButton;

    void Start()
    {
        Time.timeScale = 1f;
        _winPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок достиг финишной зоны");
            _winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartLevel()
    {
        _winPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}