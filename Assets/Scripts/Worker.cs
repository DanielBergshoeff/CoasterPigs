using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Pathfinding pathfinding;
    public Transform Target;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<Node> nodes = pathfinding.FindPath(transform.position, Target.position);
        if(nodes.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, nodes[0].vPosition, Time.deltaTime * Speed);
            transform.LookAt(nodes[0].vPosition);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, VectorMinHeight(Target.transform.position), Time.deltaTime * Speed);
            transform.LookAt(VectorMinHeight(Target.transform.position));
        }
    }

    private Vector3 VectorMinHeight(Vector3 vector)
    {
        return new Vector3(vector.x, 0f, vector.z);
    }
}
