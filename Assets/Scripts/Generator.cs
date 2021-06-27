using UnityEngine;
using UnityEngine.Events;

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Timer _timer;
    [SerializeField] private Range _rangeHorizontal;
    [SerializeField] private Range _rangeVertical;
    [SerializeField] private float _chanceSpawn;
    [SerializeField] private float _viewRange;

    private Vector2 _spawnPosition;

    public event UnityAction<GameObject> Spawned;

    private void OnEnable()
    {
        _timer.TimeIsUped += TryCreateObject;
        _timer.StartTimer();
    }

    private void OnDisable()
    {
        _timer.TimeIsUped -= TryCreateObject;
    }

    private void Update()
    {
        _timer.TryTick();
    }

    private void TryCreateObject()
    {
        if (IsChance(_chanceSpawn) && IsPlayerSee(_player.transform.position.x))
        {
            MoveNext();
            CreateObject(GetRandomObject(_templates), _spawnPosition, Quaternion.identity, _parent);
        }
        _timer.StartTimer();
    }

    protected virtual void CreateObject(GameObject template, Vector2 position, Quaternion rotation, Transform parent)
    {
        GameObject spawnObject = Instantiate(template, position, rotation, parent);
        Spawned?.Invoke(spawnObject);
    }

    private void MoveNext()
    {
        _spawnPosition = new Vector2(_spawnPosition.x + _rangeHorizontal.GetRandomPoint(), _rangeVertical.GetRandomPoint());
    }

    private bool IsPlayerSee(float playerPositionX)
    {
        return playerPositionX + _viewRange >= _spawnPosition.x;
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
