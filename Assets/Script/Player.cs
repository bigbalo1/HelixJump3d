using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody playerRB;
    public float bounceForce = 6;

    AudioManager audioManager;
    //  public AudioSource bounceAudio; this is for alternaltive

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
      //  bounceAudio.Play(); this is for altenative
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        // Debug.Log(collision.transform.GetComponent<MeshRenderer>().material.name);
        string matetialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (matetialName == "Safe (Instance)")
        {
            //the ball hits the safe
            Debug.Log("Game on");

        }
        else if (matetialName == "Unsafe (Instance)")
        {
            //the ball hits the unsafe
            GameManager.gameover = true;
            audioManager.Play("game over");
            //  Debug.Log("Game Over");
        }
        else if (matetialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            // we completed the level
            GameManager.levelCompleted = true;
            audioManager.Play("win level");
           // Debug.Log("level Completed");
        }

    }
}
