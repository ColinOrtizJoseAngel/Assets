using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleScript : MonoBehaviour
{

    public Transform Target;

    public Transform NewPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target, Vector3.left);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, NewPosition.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, NewPosition.position, step);
    }
}
