using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
   public  Vector2 MoveDirection;
    public Joystick Joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        MoveDirection = new Vector2(Joystick.Horizontal, Joystick.Vertical);
    }
}
