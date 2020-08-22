using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Text _treasureText;
    private int _treasureAmount = 0;
    public int TreasureAmount { get { return _treasureAmount; } }

    private void Start()
    {
        SetInventoryUI();
    }

    public void SetInventoryUI()
    {
        _treasureText.text = "Treasure: " + _treasureAmount;
    }

    public void IncreaseTreasure(int amount)
    {
        _treasureAmount += amount;
        SetInventoryUI();
    }
}
