using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> kebabList = new List<GameObject>();
    public GameObject kebabPrefab;
    public Transform collectPoint;
    [SerializeField] private float kebabSize = 5f;

    private int kebabLimit = 10;
    public int KebabLimit => kebabLimit;

    public void GetKebab(KebabManager kebabManager)
    {
        if (kebabList.Count < kebabLimit)
        {
           GameObject temp = Instantiate(kebabPrefab,collectPoint);
           temp.transform.parent = null;
           temp.transform.localScale = new Vector3(1, 1, 1);
           temp.transform.parent = collectPoint;
           temp.transform.localPosition = new Vector3(collectPoint.position.x, collectPoint.position.y + (kebabList.Count * kebabSize), collectPoint.position.z);
           kebabList.Add(temp);
           kebabManager.RemoveLast();
        }
    }

    public void GiveKebab(WorkerManager workerManager)
    {
        if(kebabList.Count>0)
        {
            workerManager.GetKebab();
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
