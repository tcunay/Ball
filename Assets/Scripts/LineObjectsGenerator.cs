using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObjectsGenerator : Generator
{
    [SerializeField] private int _objectQuantity;

    private float _step;

    protected override void CreateObject(GameObject template, Vector2 position, Quaternion rotation, Transform parent)
    {
        TryCreateStep(template);

        for (int i = 0; i < _objectQuantity; i++)
        {
            base.CreateObject(template, new Vector2(position.x + _step * i, position.y), rotation, parent);
        }
    }

    private void TryCreateStep(GameObject target)
    {
        if (target.TryGetComponent(out BoxCollider2D boxCollider))
            _step = boxCollider.size.x;
        else if (target.TryGetComponent(out CircleCollider2D circleCollider))
            _step = circleCollider.radius * 2;

        _step *= target.transform.localScale.x;
    }
}
