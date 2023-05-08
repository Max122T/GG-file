using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent myAgent;
    private AudioSource _source;
    Animator myAnim;
    float distance;
    public Transform target;
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAnim = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance > 10)
        {
            myAgent.enabled = false;
            myAnim.SetBool("Idle", true);
            myAnim.SetBool("Run", false);
            myAnim.SetBool("Attack", false);
        }

        if (distance <= 10 & distance > 4.5f)
        {
            myAgent.enabled = true;
            myAgent.SetDestination(target.position);
            myAnim.SetBool("Idle", false);
            myAnim.SetBool("Run",true);
            myAnim.SetBool("Attack", false);
            _source.Play();
        }

        if (distance <= 4.5f)
        {
            myAgent.enabled = true;
            myAnim.SetBool("Idle", false);
            myAnim.SetBool("Run", false);
            myAnim.SetBool("Attack", true);
            _source.Play();
        }
    }
}
