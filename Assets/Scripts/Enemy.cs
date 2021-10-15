using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private bool movingToStart;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToStart)
        {
            //overtime mov towards the start psition
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            //have we reach our target?
            if(transform.position == startPos)
            {
                movingToStart = false;
            }
        }
        //are we moving away from the start?
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);

            if (transform.position == startPos + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the collider tag is 'Player'...
        if (other.CompareTag("Player"))
        {
            //Call GameOver() that is inside "Player" class.
            other.GetComponent<Player>().GameOver();
        }
    }
}
