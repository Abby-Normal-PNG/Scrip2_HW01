using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    [SerializeField] float _bounceForce = 10;
    protected override void PlayerImpact(Player player)
    {
        base.PlayerImpact(player);
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        if (playerRB != null)
        {
            Vector3 bounceVector = player.transform.position - transform.position;
            Debug.Log("bounceVector: " + bounceVector);
            playerRB.AddForce(bounceVector * _bounceForce);
        }
    }
}
