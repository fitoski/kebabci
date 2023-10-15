using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KebabGeneratorManager : MonoBehaviour {
    public static KebabGeneratorManager Instance { get; private set; }
    public List<KebabManager> KebabGenerators = new();
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

        KebabManager[] kebabManagersTemp = FindObjectsOfType<KebabManager>();
        KebabGenerators = new(kebabManagersTemp);
    }
}
