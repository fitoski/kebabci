using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> kebabList = new List<GameObject>();
    List<GameObject> moneyList = new List<GameObject>();

    public Transform kebabPoint,moneyDropPoint;
    public GameObject kebabPrefab,moneyPrefab;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if(kebabList.Count>0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x,((float)moneyList.Count / 10), moneyDropPoint.position.z);
                moneyList.Add(temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void GetKebab()
    {
        GameObject temp = Instantiate(kebabPrefab);
        temp.transform.position = new Vector3(kebabPoint.position.x, 0.8f + ((float)kebabList.Count / 20), kebabPoint.position.z);
        kebabList.Add(temp);
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
