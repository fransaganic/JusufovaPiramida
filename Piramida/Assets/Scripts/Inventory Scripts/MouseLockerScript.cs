using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void mouseLocker(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
