using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numAmiwi = 5;
    public Transform prefab;
    public float waitTime = 2f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = 0; i < numAmiwi; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
