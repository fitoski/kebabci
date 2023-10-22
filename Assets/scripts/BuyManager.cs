using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public int moneyCount = 0;

    public void BuyArea(BuyArea areaToBuy)
    {
        if (areaToBuy != null)
        {
           if (moneyCount >= 1)
           {
                areaToBuy.Buy(1);
                moneyCount -= 1;
           }
        }
    }

    public void IncreaseMoney()
    {
        moneyCount += 50;
    }
}