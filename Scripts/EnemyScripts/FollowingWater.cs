using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingWater : MonoBehaviour
{
    

    private NavMeshAgent enemy;

    public Transform PlayerTarget;

    // Start is called before the first frame update
    void Start()
    {
        
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(PlayerTarget.position);
        //transform.position += Vector3.back * Time.deltaTime * 5;
    }
}
