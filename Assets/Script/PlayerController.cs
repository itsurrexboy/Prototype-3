using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem particleExplosion;
    public ParticleSystem particleSplatter;
    public AudioClip jumpSfx;
    public AudioClip crashSfx;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
        Physics.gravity *= gravityModifier;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            particleSplatter.Stop();
            playerAudio.PlayOneShot(jumpSfx);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            particleSplatter.Play();
            isOnGround = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            particleExplosion.Play();
            particleSplatter.Stop();
            Debug.Log("Game Over!! ");
            playerAudio.PlayOneShot(crashSfx);
        }
    }
}
