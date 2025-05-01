using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallSpawner : MonoBehaviour
{
    public int lastHit;
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Begin();
    }

    //tells system who was the last to it the ball
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player1"))
            lastHit = 1;
        else if(other.gameObject.CompareTag("Player2"))
            lastHit = 2;
    }

    //Resets the Ball
    public void Reset()
    {
        lastHit = 0;
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Begin();
    }

    private void Begin()
    { 
        float x = Random.Range(0, 3) == 0 ? -1 : 1;
        float y = Random.Range(0, 3) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
}
