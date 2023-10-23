using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class PlayerInputs : MonoBehaviour
{


    public Vector2 MoveDirection;
    public Joystick Joystick;

    //// Start is called before the first frame update
    void Start()
    {

        //Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
    }

    //public void getJoystick(Scene current, Scene next)
    //{
    //    if (GameObject.Find("Floating Joystick")!=null)
    //    {
    //        Debug.Log("getjoystick called");
    //        Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
           
    //    }
    //    // Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();

    //}



    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // MoveDirection = context.ReadValue<Vector2>();

    }

    public void GetInput()
    {
        if (Joystick != null)
        {
            MoveDirection = new Vector2(Joystick.Horizontal, Joystick.Vertical);
        }
    }
}
