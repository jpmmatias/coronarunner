using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerYo : MonoBehaviour
{
    public float startMove;
    public AudioSource jumpSound;
    public int playerSpeed = 10;
    public int speedMultiplaier;
    public float increaseSpeedMillestone;
    private float increaseSpeedMillestoneCount;
    public bool grounded;
    private float colliderHeight;
    private bool hasPlayed;
    public bool dash=false;

    private Animator MyAni;
  

   
    private Rigidbody MyRB;

    public AudioSource Running;
    
   

    public float jumpHeight;

    public float jumpTime;
    private float jumpTimeCounter;
    public CapsuleCollider colliderCapsule;

    private float RunningSoundTime;
    private bool RunningIsPlaying = false;




   
    void Start()
    {
        MyRB = GetComponent<Rigidbody>();
        MyAni=GetComponent<Animator>();
        jumpTimeCounter=jumpTime;
        increaseSpeedMillestoneCount =increaseSpeedMillestone;
        colliderCapsule = colliderCapsule.GetComponent<CapsuleCollider>();
        colliderHeight = colliderCapsule.height;
        RunningSoundTime = 0;





    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate() 
    {
        if (transform.position.x>increaseSpeedMillestoneCount)
        {
            increaseSpeedMillestoneCount+=increaseSpeedMillestone;
            playerSpeed=playerSpeed*speedMultiplaier;
            increaseSpeedMillestone+=increaseSpeedMillestone*speedMultiplaier;
        }
        if (Input.GetKey("up")|| Input.GetAxis("Jump") > 0 )
        {
            if (hasPlayed == false)
            {
                hasPlayed = true;
                jumpSound.Play();
               
            }
            


            if (jumpTimeCounter>0)
            {
               
                MyRB.AddForce(new Vector3(0, jumpHeight, 0));
                Running.volume = 0;
                jumpTimeCounter -=Time.deltaTime;


            }
    
        }

        if (Input.GetKeyUp("up")|| Input.GetAxisRaw("Jump")<=0)
        {
            jumpTimeCounter=0;
           


        }

        if (grounded)
        {
            
                jumpTimeCounter =jumpTime;
            Running.volume=1;

        }

        

        if (Input.GetKey(KeyCode.DownArrow) && dash==false)
        {
            
            dash =true;
            Running.Pause();
            colliderCapsule.height = colliderCapsule.height/1.65f;
                colliderCapsule.center = new Vector3(0, 0.3f, 0);
            if (jumpSound.isPlaying)
            {
                jumpSound.Stop();
                // jumpSound.Play();
            }




        }

        if (Input.GetKeyUp(KeyCode.DownArrow))

        {
            dash=false;
            Running.UnPause();

            colliderCapsule.height = colliderHeight;
            colliderCapsule.center = new Vector3(0, 0.8f, 0);
            if (jumpSound.isPlaying)
            {
                jumpSound.Stop();
                // jumpSound.Play();
            }

        }

        startMove -= Time.fixedDeltaTime;

        if (startMove < 10.00f)
        {
            

            RunningSoundTime -= Time.fixedDeltaTime;

            if (RunningSoundTime <= 0.0f && RunningIsPlaying == false)
            {
                Running.Play();
                RunningIsPlaying = true;
                RunningSoundTime = 16f;
               
            }
            else
            {
                RunningIsPlaying = false;
            }




            gameObject.transform.Translate(Vector3.forward * playerSpeed * Time.fixedDeltaTime);
        }

        MyAni.SetBool("Grounded",grounded);
        MyAni.SetBool("Dash",dash);

       
    }
     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.layer == 8 
             && !grounded){
             grounded = true;
           

        }
     }
     void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.layer == 8 
             && grounded){
             grounded = false;
            hasPlayed = false;
            Running.UnPause();




        }
     }

    void SoundRunning()
    {
        

    }

     
    

    
}
