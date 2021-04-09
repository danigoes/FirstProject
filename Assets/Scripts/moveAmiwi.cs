using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveAmiwi : MonoBehaviour
{
    
    private NavMeshAgent navMeshAgent;
    private Vector3 newPos;
    private GameObject reference;
    
    // Start is called before the first frame update
    void Start()
    {
        reference = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
        navMeshAgent = GetComponent<NavMeshAgent>();
        newPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        reference.transform.position = newPos;
        if (Vector3.Distance(transform.position, newPos) < 2.5f)
        {
            newPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            Debug.Log(newPos);
        }
        navMeshAgent.destination = newPos;
    }
}
