using UnityEngine;
using IJunior.TypedScenes;

public class MenuPanel : MonoBehaviour
{
    public void StartGame()
    {
        GameScene.Load();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
