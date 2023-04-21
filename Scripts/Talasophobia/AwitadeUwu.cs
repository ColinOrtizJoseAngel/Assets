using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwitadeUwu : MonoBehaviour
{
    AudioSource aud;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aud.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {

            case "Player":    // Player Salio de la construccion

                Enemy.SetActive(true);



                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {

            case "Player":    // Player Salio de la construccion

                Enemy.SetActive(false);



                break;

        }
    }
}
