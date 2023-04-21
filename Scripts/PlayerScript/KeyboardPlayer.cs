using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardPlayer : MonoBehaviour
{
    public bool ControllerActive = true;
    public bool youdeath = false;
    //--------------------------------
    public string EnemyScream = "none";
    public Animator animator1;
    //--------------------------------Movement
    public Rigidbody rb;
    public float movementSpeed = 0.09f;
    public float forceJump;
    public bool Grounded = true;
    //--------------------------------

    public string BuildName;

    public AudioSource AudioEnemy;



    public Camera_Shake cameraShake;
    public float magnitude;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        JumpPlayer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        Die();


        if (ControllerActive == true)
        {

            ControllPlayer();
        }

    }
    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxis("Vertical"); float moveVertical = Input.GetAxis("Horizontal");
        if (moveHorizontal == 0 && moveVertical == 0) return;
        Vector3 movement = new Vector3(moveVertical, 0f, moveHorizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);

        }

        //transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        rb.AddForce(transform.forward * movementSpeed);
        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, movementSpeed);


    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown("z"))
        {
            if(Grounded == true)
            {
                rb.velocity = new Vector3(0, 7, 0);
            }
            //rb.AddForce(Vector3.up * 1000);
            
        }
    }



    public void Die()
    {

        if (youdeath == true)
        {
            //AudioEnemy.Play();
            //StartCoroutine(cameraShake.Shake(0.09f, magnitude));

        }

        switch (EnemyScream)
        {
            case "DieDrown":
                ControllerActive = false;
                animator1.SetBool("DieDrown", true);
                StartCoroutine(YouAreMuriendo());
                
                break;

            default:
                // code block
                break;
        }


    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        EnemyScream = collider.gameObject.name;
        switch (collider.gameObject.tag)
        {

            case "DieDrown":
                youdeath = true;
                break;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {

            case "Build":    // Player Salio de la construccion

                BuildName = other.gameObject.name;



                break;

        }
    }

    IEnumerator YouAreMuriendo()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //my code here after 1 seconds
    }
    //--------------------------------Collisions
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            Grounded = false;
        }
      
    }
}
