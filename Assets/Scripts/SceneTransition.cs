using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
