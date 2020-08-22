using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField] int _treasureAmount = 1;

    protected override void Collect(Player player)
    {
        Inventory inv = player.GetComponent<Inventory>();
        if (inv != null)
        {
            inv.IncreaseTreasure(_treasureAmount);
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        //calc rotation
        Quaternion turnOffset = Quaternion.Euler(0, 0, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
