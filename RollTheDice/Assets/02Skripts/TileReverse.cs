using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileReverse : Tile
{
    public override void OnHere()
    {
        base.OnHere();
        ReverseDirection();
    }

    private void ReverseDirection()
    {
        Player.instance.direction = Player.DIRECTION_BACKWARD;
    }
}