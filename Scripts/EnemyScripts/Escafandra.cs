using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Escafandra : MonoBehaviour
{

    public Transform Target;
    private NavMeshAgent Enemy;

    public Transform Position1;
    public Transform Position2;

    //public GameObject FOV;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //string HeadName = FOV.name;
        //if (GameObject.Find(HeadName).GetComponent<FOVDetection>().isInFov == true)
        //{
            Position1.position = Position2.position;
            Enemy.SetDestination(Target.position);
        //}
        
    }
}
