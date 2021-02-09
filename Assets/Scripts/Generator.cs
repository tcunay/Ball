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
            if (GetChance() && CheckPosition())
            {
                ChangeSpawnPosition();
                Instantiate(GetRandomObject(_templates), GetNextPosition(), Quaternion.identity, _parent);
            }
            _elapsedTime = 0;
        }
    }

    private void ChangeSpawnPosition()
    {
        _currentSpawnPositionX += Random.Range(_minRangeSpawn, _maxRangeSpawn);
    }

    private Vector2 GetNextPosition()
    {
        Vector2 initPosition = new Vector2(_currentSpawnPositionX, Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
        return initPosition;
    }

    private bool CheckPosition()
    {
        if (_player.transform.position.x + _viewRange > GetNextPosition().x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool GetChance()
    {
        if (Random.Range(1, 101) <= _chanceSpawn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private GameObject GetRandomObject(GameObject[] templates)
    {
        var template = templates[Random.Range(0, templates.Length)];
        return template;
    }
}
