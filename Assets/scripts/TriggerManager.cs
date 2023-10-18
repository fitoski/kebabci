using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnKebabCollect;
    public static KebabManager kebabManager;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnKebabGive;
    public static WorkerManager workerManager;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollected;

    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingDesk;
    public static BuyArea areaToBuy;

    bool isCollecting, isGiving;

    void Start()
    {
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnKebabCollect();
            }
            if (isGiving==true)
            {
                OnKebabGive();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            kebabManager = other.gameObject.GetComponent<KebabManager>();
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            OnBuyingDesk();
            areaToBuy = other.gameObject.GetComponent<BuyArea>();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            kebabManager = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = false;
            workerManager = null;
        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            areaToBuy = null;
        }
    }
}