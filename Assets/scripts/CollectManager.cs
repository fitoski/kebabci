using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> kebabList = new List<GameObject>();
    public GameObject kebabPrefab;
    public Transform collectPoint;

    int kebabLimit = 10;

    private void OnEnable()
    {
        TriggerManager.OnKebabCollect += GetKebab;
        TriggerManager.OnKebabGive += GiveKebab;

    }

    private void OnDisable()
    {
        TriggerManager.OnKebabCollect -= GetKebab;
        TriggerManager.OnKebabGive -= GiveKebab;

    }

    void GetKebab()
    {
        if(kebabList.Count<= kebabLimit)
        {
            GameObject temp = Instantiate(kebabPrefab,collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 0.5f+((float)kebabList.Count / 20), collectPoint.position.z);
            kebabList.Add(temp);
            if(TriggerManager.kebabManager!=null)
            {
                TriggerManager.kebabManager.RemoveLast();
            }
        }
    }

    void GiveKebab()
    {
        if(kebabList.Count>0)
        {
            TriggerManager.workerManager.GetKebab();
            RemoveLast();
        }
    }

    public void RemoveLast()
    {
        if (kebabList.Count > 0)
        {
            Destroy(kebabList[kebabList.Count - 1]);
            kebabList.RemoveAt(kebabList.Count - 1);
        }
    }
}
