using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;
    private Vector3 move_Direction;

    public float speed = 5f;
    [SerializeField]
    private float gravity = -20;

    public float jump_Force = 10f;
    public float vertical_Velocity = 0;

    private void Awake() {
        character_Controller = GetComponent<CharacterController>();

    }

    private void Update() {
        if (!PauzaSkripta.isPaused){
        MoveThePlayer();
        }
    }

    void MoveThePlayer() {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        AppyGravity();
        character_Controller.Move(move_Direction);
    }

    void AppyGravity() {
        if(vertical_Velocity > -20){
            vertical_Velocity -= gravity * Time.deltaTime;
        }
        
        PlayerJump();
        move_Direction.y = vertical_Velocity*Time.deltaTime;
    }

    void PlayerJump() {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            vertical_Velocity = jump_Force;
        }
    }
}
