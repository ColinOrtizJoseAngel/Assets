using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetsPuzzle : MonoBehaviour
{

    public bool Order1;
    //public bool Order2;

    public GameObject Closet1;

    public bool mistakes = false;
    //public GameObject Closet2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Order1 = GameObject.Find("LockersScript1").GetComponent<ClosetScript>().Button1;
        
            
        
    }
}
