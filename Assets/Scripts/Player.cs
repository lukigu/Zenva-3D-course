using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;
    private bool isGrounded;

    public int score;

    // Update is called once per frame
    void Update()
    {
        //horizontal and vertical inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //set velocity based on inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        //create a copy of our velocity variable and set Y axis to be 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //if moving rotate face to the moving direction
        if(vel.x != 0 || vel.z !=0)
        {
            transform.forward = vel;
        }

        //checking if the space is pressed and if we stand on the ground
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;

            //adding impulse force upwards
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    //this function is called whenever a player has a collision
    private void OnCollisionEnter(Collision collision)
    {
        //checking if point of contact is facing upwards
        if(collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
