using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed = 5f;
    private Vector2 InputAxis;
    [SerializeField]
     private  PlayerInputs Input;
   // private Camera  mainCamera;
   // private Vector2 CameraForward ;
    public Transform mainCamera;

    public float RotationSpeed = 100f;

    //  private Vector2 Cameraright ;


    // Start is called before the first frame update
    void Start()
    {
        Input = gameObject.GetComponent<PlayerInputs>();
      //  mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.MoveDirection);
      //  RotateTowardMovement(Input.MoveDirection);
    }

    public void Move (Vector2 direction)
    {
        InputAxis = direction;
      //  Debug.Log(InputAxis.x);
        //Debug.Log(InputAxis.y);
        Vector3 Cameraright = mainCamera.transform.right;
        Vector3 CameraForward = mainCamera.transform.forward;
        CameraForward = CameraForward.normalized;
        Cameraright = Cameraright.normalized;
        Cameraright.y = 0;
        CameraForward.y = 0;
        

        Vector3 ForwardrelativedirectionInput = CameraForward * InputAxis.y;
        Vector3 RightrelativedirectionInput = Cameraright * InputAxis.x;

        Vector3 CameraRelativeMovement = ForwardrelativedirectionInput + RightrelativedirectionInput;




          transform.Translate(CameraRelativeMovement*MovementSpeed*Time.deltaTime, Space.World);


        //  RotateTowardMovement(ForwardrelativedirectionInput);
        RotateTowardMovement(CameraRelativeMovement);
    }

    void RotateTowardMovement(Vector3 relativeMovement)
    {
        
        //transform.Rotate(relativeMovement);
        if(relativeMovement!= Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(relativeMovement);
           
           transform.rotation = Quaternion.RotateTowards(    transform.rotation,      targetRotation,   RotationSpeed*Time.deltaTime);
        }

    }

}
