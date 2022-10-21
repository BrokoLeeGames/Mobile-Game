using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    public float jumpForce;
    //public float speed;
    Rigidbody rb;
    bool jumpAble;
    // Start is called before the first frame update
    private void Awake() {
        jumpAble = true;
        rb = GetComponent<Rigidbody>();
        inputManager = InputManager.Instance;
    }
    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        
    }
    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        
    }
    private void SwipeStart(Vector2 position, float time)
    {
        if (jumpAble)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jumpAble = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && jumpAble)
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        //    jumpAble = false;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpAble = true;
        }
    }
    public void Die()
    {
        Debug.Log("Player Dead");
    }
}
