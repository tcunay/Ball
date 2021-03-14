using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _chanceSpawn;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _minRangeSpawn;
    [SerializeField] private float _maxRangeSpawn;
    [SerializeField] private float _viewRange;

    private float _currentSpawnPositionX;
    private float _elapsedTime;

    private void Update()
    {
        TryCreateObject();
    }

    private void TryCreateObject()
    {
        _elapsedTime += Time.deltaTime;
        if (_secondsBetweenSpawn <= _elapsedTime)
        {
            if (GetChance(_chanceSpawn) && CheckVisibilityPosition())
            {
                SetNextSpawnRange();
                Instantiate(GetRandomObject(_templates), GetNextPosition(), Quaternion.identity, _parent);
            }
            _elapsedTime = 0;
        }
    }

    private void SetNextSpawnRange()
    {
        _currentSpawnPositionX += Random.Range(_minRangeSpawn, _maxRangeSpawn);
    }

    private Vector2 GetNextPosition()
    {
        return new Vector2(_currentSpawnPositionX, Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
    }

    private bool CheckVisibilityPosition()
    {
        return _player.transform.position.x + _viewRange >= _currentSpawnPositionX;
    }

    private bool GetChance(float chance)
    {
        return Random.Range(1, 101) <= chance;
    }

    private GameObject GetRandomObject(GameObject[] templates)
    {
        return templates[Random.Range(0, templates.Length)];
    }
}
