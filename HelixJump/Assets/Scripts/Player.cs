using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float bounceForce = 6;
    AudioManager audioManager;
    private void Start()
    {
        rb =GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
       
        rb.velocity = new Vector3(rb.velocity.x,bounceForce,rb.velocity.z);
        string materialName =collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            // Ball safe area
        }
        else if (materialName == "Unsafe (Instance)")
        {
            // Ball Unsafe area

           GameManager.gameOver = true;
           audioManager.Play("game over");

        }
        else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            // level completed
            GameManager.levelCompleted= true;
            audioManager.Play("win level");

        }

    }
}
