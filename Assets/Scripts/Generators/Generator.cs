using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _chanceSpawn;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _viewRadius;

    private Vector2 _initPosition;
    private float _currentRadius;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime +=  Time.deltaTime;
        if(_secondsBetweenSpawn <= _elapsedTime)
        {
            Initialize();
            _elapsedTime = 0;
        }
    }

    private void Initialize()
    {
        if (GetChance() && GetDesiredPlayerState())
        {
            Instantiate(GetRandomObject(_templates), GetNextPositionN(), Quaternion.identity, _parent);
        }
    }

    private Vector2 GetNextPositionN()
    {
        _initPosition = new Vector2(_currentRadius, Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
        return _initPosition;
    }

    private bool GetChance()
    {
        if(Random.Range(1, 101) <= _chanceSpawn)
        {
            
            return true;
        }
        else
        {
            _currentRadius += _viewRadius;
            return false;
        }
    }

    private bool GetDesiredPlayerState()
    {
        if (_player.transform.position.x + _viewRadius * 2 > _initPosition.x)
        {
            _currentRadius += _viewRadius;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected GameObject GetRandomObject(GameObject[] templates)
    {
        var template = templates[Random.Range(0, templates.Length)];

        return template;
    }
}
