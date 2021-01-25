using System.Collections;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour
{
    [SerializeField] private BarrierObject[] _templates;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parent;

    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _viewRadius;

    private Vector2 _initPosition;

    private void Start()
    {
        StartCoroutine(CalculateSpawnTime());
    }
    private void Initialize(BarrierObject[] template)
    {
        _initPosition = new Vector2(_player.position.x + _viewRadius, Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
        Instantiate(template[Random.Range(0,template.Length)], _initPosition, Quaternion.identity, _parent);
    }

    private IEnumerator CalculateSpawnTime()
    {
        while (true)
        {
            Initialize(_templates);
            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }
}
