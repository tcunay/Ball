using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score = 0;

    public event UnityAction GameOver;
    public event UnityAction OnScoreChanged;

    public int Score => _score;

    public void ScoreChanged()
    {
        _score++;
        OnScoreChanged?.Invoke();
        Debug.Log(_score);
    }
    public void Die()
    {
        GameOver?.Invoke();
    }
}
