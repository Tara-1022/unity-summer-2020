using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;//reference to animator
    public ParticleSystem explosion;//since it is not a component of the player
    public ParticleSystem dirtSplatter;

    private AudioSource playerAudio;//getting the audiosource of our player so it can emit sounds
    public AudioClip jumpSound;//getting audioclips to play on trigger
    public AudioClip crashSound;

    public float jumpForce = 10f;
    public bool isOnGround = true;

    private int timesJumped = 0;//to keep track of no. of times jumped

    public float gravityModifier;

    private GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();//get the rigidbody component
        playerAnim = GetComponent < Animator >();//""
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();


        Physics.gravity *= gravityModifier;//modify gravity

        dirtSplatter.Play();//play anim
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.gameOver && timesJumped<2)//applying force to jump if on ground, game not over and either normal or double jump
        {
            timesJumped += 1;
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            dirtSplatter.Stop();//stop anim
            playerAnim.SetTrigger("Jump_trig");//play jump animation; run happens all the time cause we have set the parameter.
            playerAudio.PlayOneShot(jumpSound);//play once
        }
        playerAnim.SetFloat("speedMultiplierAnim", gameManager.speedMulitiplier);//the animation speed has a multiplier called speed..anim; setting it to speedmultiplier everytime
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//if collided with ground; game not over, player not jumped
        {
            isOnGround = true;
            dirtSplatter.Play();
            timesJumped = 0;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.gameOver = true;

            playerAnim.SetBool("Death_b", true);//setting the bool to true so animation occurs
            playerAnim.SetInteger("DeathType_int", 1);//second condition for animation
            
            explosion.Play();///play the effect
            playerAudio.PlayOneShot(crashSound);
            dirtSplatter.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)//on entering the trigger over the obstacle
    {
        gameManager.IncreaseScore();
    }
}


