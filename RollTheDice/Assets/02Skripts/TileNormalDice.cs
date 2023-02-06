using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNormalDice : Tile
{
    public override void OnHere()
    {
        base.OnHere();
        IncreaseNormalDice();
    }

    private void IncreaseNormalDice()
    {
        DiceManager.instance.normalDice++;
    }
}
