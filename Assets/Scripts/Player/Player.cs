using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IScoreCollecting
{
    private int _score;

    public event UnityAction Died;
    public event UnityAction ScoreChanged;

    public int Score => _score;

    public void ChangeScore(int currentReward)
    {
        _score += currentReward;
        ScoreChanged?.Invoke();
    }

    public void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
