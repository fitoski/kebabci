using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class WaiterController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = KebabGeneratorManager.Instance.KebabGenerators[0].waiterExitPoint;
    }

    public Transform FindClosestExitPoint()
    {
        Transform closestExitPoint = null;
        float closestDistance = Mathf.Infinity;
        List<KebabManager> kebabGenerators = KebabGeneratorManager.Instance.KebabGenerators;

        Vector3 myPositionXZ = new Vector3(transform.position.x, 0f, transform.position.z);
        foreach (KebabManager kebabManager in kebabGenerators)
        {
            Transform waiterExitPoint = kebabManager.waiterExitPoint;
            Vector3 exitPointXZ = new Vector3(waiterExitPoint.position.x, 0f, waiterExitPoint.position.z);

            float distanceToExitPoint = Vector3.Distance(myPositionXZ, exitPointXZ);
            if (distanceToExitPoint < closestDistance)
            {
                closestDistance = distanceToExitPoint;
                closestExitPoint = waiterExitPoint;
            }
        }

        return closestExitPoint;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
