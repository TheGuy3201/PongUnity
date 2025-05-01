using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Input.GetAxis("Second Vertical");
        Vector2 newVelocity = new Vector2(0, verticalMove);
        GetComponent<Rigidbody2D>().velocity = newVelocity * playerSpeed;
    }
}
