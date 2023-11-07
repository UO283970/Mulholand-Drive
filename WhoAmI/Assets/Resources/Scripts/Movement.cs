using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

///--------------------------------
///   Author: Victor Alvarez, Ph.D.
///   University of Oviedo, Spain
///--------------------------------

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    Animator animation;
    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public string goal ="RabbitHole";
    public string nextScene = "Menu"; 

    Vector3 velocity;
   

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt (jumpHeight * -2f * gravity);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Math.Abs(x) < 1 && Math.Abs(z) < 1 && (Math.Abs(x) > 0 || Math.Abs(z) > 0)){
            animation.SetBool("isRunning", false);
            animation.SetBool("isWalking", true);
            animation.SetBool("isStanding", false);
        } else if(Math.Abs(x) == 1 || Math.Abs(z) == 1){
            animation.SetBool("isRunning", true);
            animation.SetBool("isWalking", false);
            animation.SetBool("isStanding", false);
        } else{
            animation.SetBool("isRunning", false);
            animation.SetBool("isWalking", false);
            animation.SetBool("isStanding", true);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(goal))
        {
            Debug.Log("I'm Late & Down the Rabbit Hole");
            SceneManager.LoadScene(nextScene);
        }        
    }
}
