using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float bounceForce = 6;
    private void Start()
    {
        rb =GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
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
        }
        else if (materialName == "LastRing (Instance)")
        {
            // level completed
            GameManager.levelCompleted= true;
        }

    }
}
