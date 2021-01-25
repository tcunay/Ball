using UnityEngine;
using UnityEngine.UI;

public class CreatorsPanel : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(EnableCloseAnimation);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(EnableCloseAnimation);
    }

    private void EnableCloseAnimation()
    {
        _animator.SetTrigger("Close");
    }
}
