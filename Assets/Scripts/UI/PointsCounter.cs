using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;

    private int _score = 0;

    private void OnEnable()
    {
        _player.OnScoreChanged += OnScoreChanged;
    }

    public void OnScoreChanged()
    {
        _score++;
        Debug.Log("ASDASDF" + _player.Score);
        _scoreText.text = _score.ToString();
    }
}
