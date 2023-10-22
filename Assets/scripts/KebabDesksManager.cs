using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KebabDesksManager : MonoBehaviour
{
    public static KebabDesksManager Instance { get; private set; }
    public List<WorkerManager> kebabDesks = new();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        UpdateAllKebabDesks();
    }

    public void UpdateAllKebabDesks()
    {
        WorkerManager[] kebabManagersTemp = FindObjectsOfType<WorkerManager>();
        kebabDesks = new(kebabManagersTemp);
    }
}

