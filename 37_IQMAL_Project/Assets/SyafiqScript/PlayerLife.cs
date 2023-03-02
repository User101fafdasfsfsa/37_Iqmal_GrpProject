using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public PlayerMovement Player;
    [SerializeField] private Text Lives;
    public int LivesCount = 3;
    private Rigidbody2D rb;
    private Animator anim;

    private Vector3 RespawnPoint;
    [SerializeField] private AudioSource DeathFX;
    [SerializeField] private AudioSource CheckpointFX;
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        RespawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            DeathFX.Play();
            LivesCount--;
            Lives.text = "Lives: " + LivesCount;
            Die();
            //Put the if LivesCount <= 0 down here if you want the player to die completely and get to game over scene

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            CheckpointFX.Play();
            RespawnPoint = transform.position;
        }
    }

    private void Die()
    {
        //If you want to stop the game use the code below
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }


    //Automatically Restarts Level after dying (Takign away lives)
    private void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("respawn");
        transform.position = RespawnPoint;
    }
}
