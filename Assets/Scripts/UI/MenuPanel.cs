using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
