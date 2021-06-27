using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Generator))]
public class ObjectOnlyInFreePlacesLeaver : MonoBehaviour
{
    private Generator _generator;

    private void Awake()
    {
        _generator = GetComponent<Generator>();
    }

    private void OnEnable()
    {
        _generator.Spawned += OnSpawnObjectHandler;
    }

    private void OnDisable()
    {
        _generator.Spawned -= OnSpawnObjectHandler;
    }

    private void OnSpawnObjectHandler(GameObject spawnObject)
    {
        StartCoroutine(TryDestroyObject(spawnObject));
    }

    private IEnumerator TryDestroyObject(GameObject spawnObject)
    {
        yield return new WaitForFixedUpdate();

        if (PlaceIsTaken(spawnObject.GetComponent<Collider2D>()))
        {
            Destroy(spawnObject);
        }
    }

    private bool PlaceIsTaken(Collider2D collider)
    {
        return collider.IsTouchingLayers();
    }
}
