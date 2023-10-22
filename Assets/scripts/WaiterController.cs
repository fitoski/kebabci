using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class WaiterController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    WaiterState waiterState = WaiterState.GetKebab;
    private CollectManager collectManager;

    private bool foundDesk = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        collectManager = GetComponent<CollectManager>();
    }

    void Update()
    {
        if (waiterState == WaiterState.Idle)
        {
            target.position = transform.position;
            foundDesk = false;
        }

        else if (waiterState == WaiterState.SellKebab)
        {
            if (!foundDesk)
            {
                target = FindClosestKebabDesk();
            }

            if (collectManager.kebabList.Count == 0)
            {
                waiterState = WaiterState.GetKebab;
            }
        }

        else if (waiterState == WaiterState.GetKebab)
        {
            target = KebabGeneratorManager.Instance.KebabGenerators[0].waiterExitPoint;
            foundDesk = false;

            if (collectManager.kebabList.Count >= collectManager.KebabLimit)
            {
                waiterState = WaiterState.SellKebab;
            }
        }

        agent.SetDestination(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    public Transform FindClosestKebabDesk()
    {
        Transform closestExitPoint = null;
        float closestDistance = Mathf.Infinity;
        List<WorkerManager> kebabDesks = KebabDesksManager.Instance.kebabDesks;

        foreach (WorkerManager deskManager in kebabDesks)
        {
            Transform waiterExitPoint = deskManager.waiterExitPoint;
            Vector3 exitPointXZ = new Vector3(waiterExitPoint.position.x, transform.position.y, waiterExitPoint.position.z);

            float distanceToExitPoint = Vector3.Distance(transform.position, exitPointXZ);
            if (distanceToExitPoint < closestDistance)
            {
                closestDistance = distanceToExitPoint;
                closestExitPoint = waiterExitPoint;
            }
        }

        foundDesk = true;
        return closestExitPoint;
    }

    enum WaiterState
    {
        Idle,
        GetKebab,
        SellKebab,
    }
}
