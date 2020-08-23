using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMotor))]
[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;

    bool _canBeDamaged = true;
    public bool CanBeDamaged 
    { 
        set { _canBeDamaged = value; } 
        get { return _canBeDamaged; } 
    }

    bool _isPoweredUp = false;
    public bool IsPoweredUp
    {
        set { _isPoweredUp = value; }
        get { return _isPoweredUp; }
    }

    BallMotor _ballMotor;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's Health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (_canBeDamaged)
        {
            _currentHealth -= amount;
            Debug.Log("Player's Health: " + _currentHealth);
        }
        else
        {
            Debug.Log("No Damage - Invincible");
        }
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //play particles
        //play sound
    }
}
