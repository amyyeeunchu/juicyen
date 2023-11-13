using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayerAttack;
using PlayerStatus;

public class PlayerMovement : MonoBehaviour {
    // speed constants
    public float speed = 5.0f;
    public float runspeed = 7.0f;

    private Rigidbody2D body;
    private SceneHandler scene;

    public float chargeTimer = 0;    

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); // access components  
    }

    // Update is called once per frame
    void Update()
    {
        // the angle that the player is looking at follows the mouse position
        public Vector3 mousePos = Input.mousePosition;

        //if current status is disabled, the player cannot move or attack
        if (disabled == FALSE){

            // press Space to attack
            if(Input.GetKeyDown(KeyCode.Space)) {
                // check  weapon selected, then call attack function
                if (weaponSelected == 1) {
                    Attack1();
                }
                else if(weaponSelected == 2) {
                    Attack2();
                } else if (weaponSelected == 3) {
                    if(Input.GetKey(KeyCode.Space)){
                        chargeTimer += Time.deltaTime;
                        if (chargeTimer >= 2.0f) {
                        Attack3(chargeTimeMax);
                        chargeTimer = 0.0f;
                        }
                    }
                    else if (Input.GetKeyUp (KeyCode.Space)) {
                        Attack3(chargeTimer);
                        chargeTimer = 0.0f;
                    }
                } 
            }

            // press E for special attack
            if(Input.GetKeyDown(KeyCode.E)) {
                if (weaponSelected == 1)
                {
                    SpecialAttack1();
                }
                else if(weaponSelected == 2) 
                {
                    SpecialAttack2();
                } else if (weaponSelected == 3) 
                {
                    SpecialAttack3();
                } 
            }

            // press D to move right
            if(Input.GetKeyDown(KeyCode.D)) {
                MoveRight();
            }
        
            // press W to move up
            if(Input.GetKeyDown(KeyCode.W)) {
                MoveUp();
            }

            // press A to move left
            if(Input.GetKeyDown(KeyCode.A)) {
                MoveLeft();
            }

            // press S to move down
            if(Input.GetKeyDown(KeyCode.S)) {
                MoveDown();
            }        
        }

    void MoveRight() {   
        //if left shift key is pressed at the same time, use runspeed instead of speed 
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            transform.position +=
                new Vector3(runspeed, 0.0f, 0.0f) * Time.deltaTime;
        } else {
            transform.position +=
                new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
        }
    }

    void MoveLeft() { 
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            transform.position +=
                new Vector3(-runspeed, 0.0f, 0.0f) * Time.deltaTime;
        } else {
            transform.position +=
                new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime;
        }  
    }

    void MoveUp() {   
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            transform.position +=
                new Vector3(0.0f, runspeed, 0.0f) * Time.deltaTime;
        } else {
            transform.position +=
                new Vector3(0.0f, speed, 0.0f) * Time.deltaTime;
        }  
    }

    void MoveDown() {   
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            transform.position +=
                new Vector3(0.0f, -runspeed, 0.0f) * Time.deltaTime;
        } else {
            transform.position +=
                new Vector3(0.0f, -speed, 0.0f) * Time.deltaTime;
        }  
    }

}