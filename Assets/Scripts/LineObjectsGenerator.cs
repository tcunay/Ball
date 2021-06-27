using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObjectsGenerator : Generator
{
    [SerializeField] private int _objectQuantity;

    private WidthObjectCalculator _widthObjectCalculator = new WidthObjectCalculator();

    protected override void CreateObject(GameObject template, Vector2 position, Quaternion rotation, Transform parent)
    {
        if(_widthObjectCalculator.TryCalculateWidth(template, out float step))
        {
            for (int i = 0; i < _objectQuantity; i++)
            {
                base.CreateObject(template, new Vector2(position.x + step * i, position.y), rotation, parent);
            }
        }
    }
}
