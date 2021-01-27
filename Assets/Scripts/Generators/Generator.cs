using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    [SerializeField] protected GameObject[] Templates;
    [SerializeField] protected Transform Player;
    [SerializeField] protected Transform Parent;

    [SerializeField] protected float SecondsBetweenSpawn;
    [SerializeField] protected float MaxSpawnPositionY;
    [SerializeField] protected float MinSpawnPositionY;
    [SerializeField] protected float ViewRadius;
    [SerializeField] protected float ChanceSpawn;

    protected Vector2 InitPosition;
    protected float ElapsedTime;


    private void Update()
    {
        ElapsedTime +=  Time.deltaTime;
        if(SecondsBetweenSpawn <= ElapsedTime)
        {
            Initialize();
            ElapsedTime = 0;
        }
    }
    protected void Initialize()
    {
        if (Random.Range(1, 101) <= ChanceSpawn && GetDesiredPlayerState())
        {
            Instantiate(SetGameObject(Templates), GetInitPosition(), Quaternion.identity, Parent);
        }
    }

    protected abstract Vector2 GetInitPosition();

    protected abstract bool GetDesiredPlayerState();

    protected GameObject SetGameObject(GameObject[] templates)
    {
        var template = templates[Random.Range(0, templates.Length)];

        return template;
    }

    private IEnumerator SpawnLoop()
    {
        while (GetDesiredPlayerState())
        {
            Debug.Log("Вход в цикл коррутины");
            //GetInitPosition();
            if (Random.Range(1, 101) <= ChanceSpawn)
            {
                Initialize();
            }
            yield return new WaitForSeconds(SecondsBetweenSpawn);
        }
    }

}
