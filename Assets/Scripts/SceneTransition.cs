using UnityEngine;
using IJunior.TypedScenes;

public class SceneTransition : MonoBehaviour
{
    public void OpenMenu()
    {
        MenuScene.Load();
    }
}
