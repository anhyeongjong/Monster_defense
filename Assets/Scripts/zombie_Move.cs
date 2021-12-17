using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie_Move : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.destination != target.transform.position && nav.isStopped == false)
        {
            nav.SetDestination(target.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }
    }

    public void Stop_Nav()
    {
        nav.isStopped = true;
    }
}
