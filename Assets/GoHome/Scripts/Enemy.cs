using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //all variables needs to be weritten here...

    // <Access-Specifier>   <Data-Type>     <Variable-Name> (How to write variables)
         public             Transform        waypointParent; //transform because you want to move or transform the waypoint.
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;


	// Use this for initialization
	void Start ()
    {
        //Get Children of waypointParent.
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        // Get reference to NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }


    void Patrol()
    {
        // 1 - Get the current waypoint
        Transform point = waypoints[currentIndex];
        // 2 - Get distance to waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        // 3 - If close to waypoint
        if(distance < stoppingDistance)
        {
            //  4 - Switch to next waypoint
            currentIndex++; // currentIndex = currentIndex + 1 / Adds 1 to number
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }


        // 5 - Translate enemy to waypoint
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

        // 5 - Tell NavMeshAgent it's destination
        agent.SetDestination(point.position);
    }
}
