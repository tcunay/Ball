using System.Collections;
using UnityEngine;

public class LineofCoinsGenerate : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parent;

    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _chanceSpawn;

    private Vector2 _initPosition;

    private void Start()
    {
        StartCoroutine(CalculateSpawnTime());
    }

    private void Initialize(GameObject template)
    {
        _initPosition = new Vector2(_player.position.x + _viewRadius, Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
        Instantiate(template, _initPosition, Quaternion.identity, _parent);
    }

    private IEnumerator CalculateSpawnTime()
    {
        while (true)
        {
            if(Random.Range(1,101) < _chanceSpawn)
            {
            Initialize(_template);
            }
            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }
}
