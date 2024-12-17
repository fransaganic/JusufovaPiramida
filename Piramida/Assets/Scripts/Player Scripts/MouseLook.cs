using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_Unlock = true;

    [SerializeField]
    private float sensivity = 5f;

    [SerializeField]
    private int smooth_Steps = 10;

    [SerializeField]
    private float smooth_Wait = 0.4f;

    [SerializeField]
    private float roll_Angle = 10f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);

    private Vector2 look_Angles;

    private Vector2 current_Mouse_Look;
    private Vector2 smooth_Move;

    private float current_Roll_Angle;

    private int last_Look_Frame;


    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update() {
        if (Cursor.lockState == CursorLockMode.Locked) {
            LookAround();
        }
    }
   

    void LookAround() {
        current_Mouse_Look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));
        look_Angles.x += current_Mouse_Look.x * sensivity * (invert ? 1f : -1f);
        //invert ako pomaknemo mis gore, slika ode dolje, invert kao u igrama
        look_Angles.y += current_Mouse_Look.y * sensivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y);
        //clamp ne dozvoljava vrijednosti look_Angles.x da ode izvan rangea [default_Look_Limits.x, default_Look_Limits.y]

        /*current_Roll_Angle = Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * roll_Angle, Time.deltaTime * roll_Speed);*/
        //dodavanje rotacije na z osi, osjecaj vrtoglavice


        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0f,0f); //na z parametar staviti current_Roll_Angle
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);
    }
}
