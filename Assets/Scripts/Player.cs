using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 7f;
    Collider2D myCollider;
    LifeKeeper theLiveKeeper;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        theLiveKeeper = FindObjectOfType<LifeKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }
    private void Run()
    {
        float controlDirection = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlDirection * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

    }
    private void Jump()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Debug.Log("Teet0");
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Teet1");
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        theLiveKeeper.DecreaseLive();
        Destroy(gameObject);
    }
}
