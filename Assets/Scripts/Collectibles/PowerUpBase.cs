using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class PowerUpBase : CollectibleBase
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    protected float _durationTimeSecs = 5f;
    private Coroutine _powerUpCoroutine;
    protected Collider _collider;

    [SerializeField] GameObject _visuals;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _collider = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            //spawn particles/fx beause we need to disable visuals
            CollectFeedback();
            DisableVisuals();
            DisableCollider();
        }
    }

    protected override void Collect(Player player)
    {
        _powerUpCoroutine = StartCoroutine(PowerUpTimer(player, _durationTimeSecs));
    }

    IEnumerator PowerUpTimer(Player player, float timeInSeconds)
    {
        PowerUp(player);
        yield return new WaitForSeconds(timeInSeconds);
        PowerDown(player);
        DisableSelf();
    }

    protected virtual void DisableVisuals()
    {
        _visuals.SetActive(false);
    }

    protected virtual void DisableCollider()
    {
        _collider.enabled = false;
    }
}
