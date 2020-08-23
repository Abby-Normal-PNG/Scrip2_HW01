using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Material _powerUpStateMaterial;
    [SerializeField] Material _powerDownStateMaterial;
    private MeshRenderer _playerMeshRenderer;

    protected override void PowerUp(Player player)
    {
        player.CanBeDamaged = false;
        _playerMeshRenderer = player.GetComponent<MeshRenderer>();
        _playerMeshRenderer.material = _powerUpStateMaterial;
    }

    protected override void PowerDown(Player player)
    {
        player.CanBeDamaged = true;
        _playerMeshRenderer.material = _powerDownStateMaterial;
    }

    protected override void Movement(Rigidbody rb)
    {
        base.Movement(rb);
    }
}
