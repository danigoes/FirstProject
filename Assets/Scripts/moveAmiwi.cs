using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveAmiwi : MonoBehaviour
{
    
    private NavMeshAgent navMeshAgent;
    private Vector3 newPos;
    public float targetDistance = 1.5f;
    public float randomPointRange = 5f;

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(newPos, 0.3f);

        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, randomPointRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        RandomPoint(transform.position, randomPointRange, out newPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, newPos) < targetDistance && !RandomPoint(transform.position, randomPointRange, out newPos))
        {
            Debug.Log("ERROR");
        }
        navMeshAgent.destination = newPos;
    }
}
