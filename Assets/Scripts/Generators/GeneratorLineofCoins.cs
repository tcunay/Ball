using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLineofCoins : Generator
{
    protected override bool GetDesiredPlayerState()
    {
        if (Player.gameObject.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected override Vector2 GetInitPosition()
    {
        InitPosition = new Vector2(Player.position.x + ViewRadius, Random.Range(MinSpawnPositionY, MaxSpawnPositionY));

        return InitPosition;
    }
}

