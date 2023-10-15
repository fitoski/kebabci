using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public int moneyCount = 0;

    private void OnEnable()
    {
        TriggerManager[] triggerManagers = FindObjectsOfType<TriggerManager>();
        foreach (TriggerManager triggerManager in triggerManagers)
        {
            triggerManager.OnMoneyCollected += IncreaseMoney;
            triggerManager.OnBuyingDesk += BuyArea;
        }
    }

    private void OnDisable()
    {
        TriggerManager[] triggerManagers = FindObjectsOfType<TriggerManager>();
        foreach (TriggerManager triggerManager in triggerManagers)
        {
            triggerManager.OnMoneyCollected -= IncreaseMoney;
            triggerManager.OnBuyingDesk -= BuyArea;
        }
    }

    void BuyArea()
    {
        if (TriggerManager.Instance.areaToBuy != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.Instance.areaToBuy.Buy(1);
                moneyCount -= 1;
            }
        }
    }

    void IncreaseMoney()
    {
        moneyCount += 50;
    }
}