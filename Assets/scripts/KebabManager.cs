using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KebabManager : MonoBehaviour
{
    public List<GameObject> kebabList = new List<GameObject>();
    public GameObject kebabPrefab;
    public Transform exitPoint;
    bool isWorking;
    int stackCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeKebab());
    }

    public void RemoveLast ()
    {
        if(kebabList.Count > 0)
        {
            Destroy(kebabList[kebabList.Count - 1]);
            kebabList.RemoveAt(kebabList.Count - 1);
        }
    }


    IEnumerator MakeKebab()
    {
        while (true)

        {
            float kebabCount = kebabList.Count;
            int rowCount = (int)kebabCount / stackCount;
            if (isWorking == true)
            {
                GameObject temp = Instantiate(kebabPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x+((float)rowCount/3), kebabCount / 20, exitPoint.position.z);
                kebabList.Add(temp);
                if (kebabList.Count >= 30)
                {
                    isWorking = false;
                }
            }

            else if(kebabList.Count<30)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1);
        }
    }
}