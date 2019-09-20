using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pig : MonoBehaviour
{
    public bool Free = false;
    public bool Nuzzled = false;

    private NavMeshAgent myNavMeshAgent;
    private Selector rootSelector;

    // Start is called before the first frame update
    void Start()
    {
        ActionNode walkRandomly;
        ActionNode moveToDoor;
        ActionNode exitDoor;

        rootSelector = new Selector(new List<Node>() { });
    }

    // Update is called once per frame
    void Update()
    {
        if (Free)
        {
            rootSelector.Evaluate();
        }
    }

    private void WalkRandomly()
    {
        myNavMeshAgent.SetDestination(RandomNavmeshLocation(4f));
    }

    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
