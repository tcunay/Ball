using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _openMenu;

    private void OnEnable()
    {
        _player.Died += OnGameOver;
    }

    private void OnDisable()
    {
        _player.Died -= OnGameOver;
    }

    public void OnGameOver()
    {
        _openMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
