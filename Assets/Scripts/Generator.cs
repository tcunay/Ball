using UnityEngine;

[System.Serializable]
public struct Range
{
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    public float RandomPosition { get => Random.Range(_min, _max); }
}

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Range _rangeHorizontal;
    [SerializeField] private Range _rangeVertical;
    [SerializeField] private float _chanceSpawn;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _viewRange;

    private Vector2 _currentSpawnPosition;
    private float _currentSpawnPositionX;
    private float _currentSpawnPositionY;
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
            if (IsChance(_chanceSpawn) && IsPlayerSee(_player.transform.position.x))
            {
                MoveNext();
                Instantiate(GetRandomObject(_templates), _currentSpawnPosition, Quaternion.identity, _parent);
            }
            _elapsedTime = 0;
        }
    }

    private void MoveNext()
    {
        _currentSpawnPositionX += _rangeHorizontal.RandomPosition;
        _currentSpawnPositionY = _rangeVertical.RandomPosition;

        _currentSpawnPosition = new Vector2(_currentSpawnPositionX, _currentSpawnPositionY);
    }

    private bool IsPlayerSee(float playerPositionX)
    {
        return playerPositionX + _viewRange >= _currentSpawnPositionX;
    }

    private bool IsChance(float chance)
    {
        return Random.Range(1, 101) <= chance;
    }

    private GameObject GetRandomObject(GameObject[] templates)
    {
        return templates[Random.Range(0, templates.Length)];
    }
}
