using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _restartButton.onClick.RemoveListener(RestartGame);
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
