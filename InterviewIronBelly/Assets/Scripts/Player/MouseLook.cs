using IronBelly.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    [SerializeField]
    private Transform playerRoot, lookRoot;
    [SerializeField]
    private float sensivity = 5f;
    [SerializeField]
    private Vector2 lookAtLimit = new Vector2(-40f, 40f);

    private Vector2 lookAngles;
    private Vector2 currentMouseLook;

    void Start () 
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
        LockUnlockCursor();
        LookAround();
	}

    void LockUnlockCursor() 
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(Cursor.lockState == CursorLockMode.Locked) 
            {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void LookAround() {

        currentMouseLook = new Vector2(
            Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        lookAngles.x += currentMouseLook.x * sensivity * -1f;
        lookAngles.y += currentMouseLook.y * sensivity;

        lookAngles.x = Mathf.Clamp(lookAngles.x, lookAtLimit.x, lookAtLimit.y);

        lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
    } 
}













































