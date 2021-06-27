using UnityEngine.Events;

public interface IScoreCollecting
{
    event UnityAction ScoreChanged;

    void ChangeScore(int reward);
}
