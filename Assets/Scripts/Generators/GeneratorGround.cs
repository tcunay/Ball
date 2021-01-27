using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorGround : Generator
{
    private float _groundWidth = 18;

    protected override Vector2 GetInitPosition()
    {
        InitPosition += new Vector2(Templates[0].transform.position.x + _groundWidth, Templates[0].transform.position.y);

        return InitPosition;
    }

    protected override bool GetDesiredPlayerState()
    {
        if (Player.transform.position.x > InitPosition.x - _groundWidth / 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
