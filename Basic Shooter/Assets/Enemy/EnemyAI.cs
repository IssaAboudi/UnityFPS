using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f; //how close player to get before enemy chase
    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    
    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update() {
        setDestination();
        
    }

    void setDestination() {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) {
            engageTarget();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
    }


    void engageTarget() {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            chaseTarget();
        }

        if (distanceToTarget < navMeshAgent.stoppingDistance) {
            attackTarget();
        }
    }

    void chaseTarget() {
        navMeshAgent.SetDestination(target.position);
    }

    void attackTarget() {
        Debug.Log(name + "Attacked " + target.name);
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

