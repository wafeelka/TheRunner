using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private Animator playerAnim;
    public float JumpForce = 10.0f;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem ParticleCrush, DirtUnderLegs;
    public AudioClip jumpSound, deathSound;
    private AudioSource audioSource;
      
    // Start is called before the first frame 
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
          
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            PlayerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            DirtUnderLegs.Stop();
            audioSource.PlayOneShot(jumpSound, 0.9f);
                  
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            DirtUnderLegs.Play();
        }
        else if (collision.gameObject.CompareTag("Obstracle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            ParticleCrush.Play();
            DirtUnderLegs.Stop();
            audioSource.PlayOneShot(deathSound, 0.9f);

        }
    }
}
