﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeableObject : InteractableObject
{
    [SerializeField] protected ObjectData m_ObjectData; 

    public void TakeItem()
    {
        if (Inventory.Instance.CheckIfSpace(m_ObjectData))
        {
            base.PlayerActionEvent();
            Inventory.Instance.AddItem(m_ObjectData);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Cant pick up backpack is full");
        }
    }
}
