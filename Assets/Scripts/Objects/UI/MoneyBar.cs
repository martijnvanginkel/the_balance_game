﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : Bar
{
    [SerializeField] private GameObject m_MoneyDifferenceBox;
    [SerializeField] private TMPro.TextMeshProUGUI m_MoneyDifferenceIcon;
    [SerializeField] private TMPro.TextMeshProUGUI m_MoneyDifferenceText;

    private float m_ShowTime = 2f;
    private bool m_ShowMoneyDifference;

    private Color m_DefaultTextColor;
    public Color DefaultTextColor
    {
        get { return m_DefaultTextColor; }
        set { m_DefaultTextColor = value; }
    }

    protected override void Start()
    {
        base.Start();
        m_DefaultTextColor = m_CurrentValueText.color;
    }

    private void Update()
    {
        if (m_ShowMoneyDifference)
        {
            ShowMoneyTimer();
        }
    }

    public void GainMoney(ObjectData objectData)
    {
        m_CurrentValue += objectData.SellingCost;
        SetAmountText(m_CurrentValue);
        m_MoneyDifferenceIcon.text = "+";
        m_MoneyDifferenceText.text = objectData.SellingCost.ToString();

        ShowDifferenceBox(true);
    }

    public void LoseMoney(ObjectData objectData)
    {
        m_CurrentValue -= objectData.BuyingCost;
        SetAmountText(m_CurrentValue);
        m_MoneyDifferenceIcon.text = "-";
        m_MoneyDifferenceText.text = objectData.BuyingCost.ToString();

        ShowDifferenceBox(true);
    }

    private void ShowDifferenceBox(bool show)
    {
        m_MoneyDifferenceBox.SetActive(show);
        m_ShowMoneyDifference = show;
    }


    private void ShowMoneyTimer()
    {
        m_ShowTime -= Time.deltaTime;

        if(m_ShowTime <= 0f)
        {
            ShowDifferenceBox(false);
            m_ShowTime = 2f;
        }
    }

    public void CantAffordBlink()
    {
        StartCoroutine("BlinkMoney", Color.red);
    }

    private IEnumerator BlinkMoney(Color color)
    {
        m_CurrentValueText.color = color;
        yield return new WaitForSeconds(0.5f);
        m_CurrentValueText.color = m_DefaultTextColor;
    }

}
