using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestOnly
{
    public class PlayerLocomotionManager : MonoBehaviour
    {
        [HideInInspector]
        public float MovementSpeed = 5f;
      
        public float InitialMovementSpeed = 8f;
      //  private Vector2 InputAxis;
        [HideInInspector]
        public Vector3 CameraRelativeMovement;
        public float RotationSpeed = 100f;

        [SerializeField] private PlayerManager playerManager;

        // Start is called before the first frame update
        void Start()
        {
            MovementSpeed = InitialMovementSpeed;
            playerManager = GetComponent<PlayerManager>();
        }

        public void Move()
        {
            Vector2 InputAxis = playerManager.playerInputs.MoveDirection;
            //  Debug.Log(InputAxis.x);
            Vector3 Cameraright = playerManager.playerCamera.transform.right;
            Vector3 CameraForward = playerManager.playerCamera.transform.forward;
            CameraForward = CameraForward.normalized;
            Cameraright = Cameraright.normalized;
            Cameraright.y = 0;
            CameraForward.y = 0;

            Vector3 ForwardrelativedirectionInput = CameraForward * InputAxis.y;
            Vector3 RightrelativedirectionInput = Cameraright * InputAxis.x;

            CameraRelativeMovement = ForwardrelativedirectionInput + RightrelativedirectionInput;

            transform.Translate(CameraRelativeMovement * MovementSpeed * Time.deltaTime, Space.World);

            RotateTowardMovement(CameraRelativeMovement);
        }

        void RotateTowardMovement(Vector3 relativeMovement)
        {

            //transform.Rotate(relativeMovement);
            if (relativeMovement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(relativeMovement);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            }

        }

    }
}