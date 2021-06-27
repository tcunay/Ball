using UnityEngine;

public class WidthObjectCalculator
{
    public bool TryCalculateWidth(GameObject target, out float width)
    {
        width = 0;

        if (target.TryGetComponent(out BoxCollider2D boxCollider))
            width = boxCollider.size.x;
        else if (target.TryGetComponent(out CircleCollider2D circleCollider))
            width = circleCollider.radius * 2;
        else
            return false;

        width *= target.transform.localScale.x;
        return true;

    }
}
