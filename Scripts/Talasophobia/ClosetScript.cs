using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetScript : MonoBehaviour
{
    public Animator animator1;
    //public Animator animator2;
    //public Animator animator3;
    //public Animator animator4;

    public GameObject Closet1;
    //public GameObject Closet2;
    //public object Closet3;
    //public object Closet4;

    public bool Button1 = true;
    //public bool Button2 = true;
    //public bool Button3 = false;
    //public bool Button4 = false;
    public bool mistake = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mistake = GameObject.Find("Entrance").GetComponent<ClosetsPuzzle>().mistakes;
        animator1.SetBool("ItsOpen", Button1);
        //animator2.SetBool("ItsOpen", Button2);
        //animator3.SetBool("ItsOpen", Button1);
        //animator4.SetBool("ItsOpen", Button1);

        if (Button1 == false)
        {
            Debug.Log("YouMadeIt");
        }

        if(mistake == true)
        {
            Button1 = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        

        if (Input.GetKeyDown("z"))
        {
            //Button1 = false;
            
        }
    }

    public void ResetPuzzle()
    {
        
    }
}
