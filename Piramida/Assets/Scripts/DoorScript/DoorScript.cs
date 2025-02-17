using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;

    private bool opened = false;
    private Animator anim;

    [SerializeField]
    GameObject text;


    void Update() {
        //This will tell if the player press  on the Keyboard. P.S. You can change the key if you want.
        if (Input.GetKeyDown(KeyCode.R)) {
            Pressed();
            //Delete if you dont want Text in the Console saying that You Press F.
           
        }

        PressR();
    }

    void Pressed() {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance)) {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (doorhit.transform.tag == "Door") {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("IntroGame1");

                //This line will get the Animator from  Parent of the door that was hit by the raycast.
                //anim = doorhit.transform.GetComponentInParent<Animator>();

                //This will set the bool the opposite of what it is.
                //opened = !opened;

                //This line will set the bool true so it will play the animation.
                //anim.SetBool("Opened", !opened);
            }
        }
    }

    void PressR() {
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance)) {
            if (doorhit.transform.tag == "Door" && MainMenu.SampleSceneFinishedGame == false) {
                text.SetActive(true);
            }
        } else {
            text.SetActive(false);
        }
    }
}
