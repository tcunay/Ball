using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Timer
{
    [SerializeField] private float _timeValue;

    private bool _timeRuns;
    private float _elapsedTime;

    public event UnityAction TimeIsUped;

    private void Update()
    {
        TryTick();
    }

    public void TryTick()
    {
        if (_timeRuns)
        {
            Tick();
        }
    }

    private void Tick()
    {
        _elapsedTime += Time.deltaTime;
        if(_timeValue <= _elapsedTime)
        {
            _timeRuns = false;
            TimeIsUped?.Invoke();
        }
    }

    public void StartTimer()
    {
        _timeRuns = true;
        _elapsedTime = 0;
    }
}
