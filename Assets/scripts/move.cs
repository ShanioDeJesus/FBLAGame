using UnityEngine;
using System.Collections;

public class move : MonoBehaviour
{
    int jumpCount = 0;

    //Used to stop player when is moving in another direction
    int curMove = 0; //0 = Right, 1= left, 2 for sprint right, 3 for sprint left


    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("hora"), 0, Input.GetAxis("verta"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    //void Update()
    //{
    //    //Using a CharecterController provides real life physics in collisions and movement
    //    CharacterController controller = GetComponent<CharacterController>();
    //    if (Input.GetButton("Jump") && jumpCount <=maxJump)
    //    {
    //      jumpCount += 1;
    //        moveDirection = new Vector3(Input.GetAxis("hora"), jumpSpeed, 0);
    //    }
    //    else
    //    {
    //       // jumpCount = 0;
           
    //     //   moveDirection = new Vector3(Input.GetAxis("hora"),0,0);
    //    }
    //   //// moveDirection.y -= gravity * Time.deltaTime;
    //   // moveDirection = transform.TransformDirection(moveDirection);
    //   // moveDirection *= speed;



        
    //   // controller.Move(moveDirection * Time.deltaTime);

    //}
    void OnCollisionEnter(Collision hit)
    {
        //Resets jumps (Prevents double jump)
        if (hit.gameObject.tag == "ground")
        {
            jumpCount = 0;

        }

        //stops player
        if (hit.gameObject.tag == "solid")
        {


        }
    }
}
