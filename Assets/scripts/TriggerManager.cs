using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    private KebabManager kebabManager;
    private WorkerManager workerManager;
    private BuyArea areaToBuy;

    private CollectManager collectManager;

    private bool isCollecting, isGiving;

    void Start()
    {
        collectManager = GetComponent<CollectManager>();
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting)
            {
                if (kebabManager != null)
                {
                    collectManager.GetKebab(kebabManager);
                }
            }
            if (isGiving)
            {
                if (workerManager != null)
                {
                    collectManager.GiveKebab(workerManager);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money") && transform.CompareTag("Player"))
        {
            GetComponent<BuyManager>().IncreaseMoney();
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