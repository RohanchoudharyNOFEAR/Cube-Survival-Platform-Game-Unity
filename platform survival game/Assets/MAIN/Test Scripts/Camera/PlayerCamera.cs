using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestOnly
{
    public class PlayerCamera : MonoBehaviour
    {
        public CameraFollow cameraFollow;

        [Header("Camera Shake")]
        Vector3 InitialPosition = Vector3.zero;
        public float ShakeMagnitude = 0.2f;
        private bool ShakeCamera = false;
        [SerializeField] private float cameraShakeTime = 1.5f;
        [SerializeField] private WaitForSeconds waitforSecondCameraShake;

        private void Start()
        {
            cameraFollow =  GetComponent<CameraFollow>();
            waitforSecondCameraShake = new WaitForSeconds(cameraShakeTime);
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            InitialPosition = transform.position;
        }

        private void LateUpdate()
        {
            if (ShakeCamera == true)
            {
                StartCoroutine(ShakingEffect());
               
            }
            //else
            //{
            //    StopCoroutine(ShakingEffect());
            //}
        }

       public void StartShakeCoroutine()
        {
            ShakeCamera = true;
        }

        //void StopShakeCoroutine()
        //{
        //    ShakeCamera = false;
        //}

        public IEnumerator ShakingEffect()
        {

            gameObject.transform.position = InitialPosition + (Random.insideUnitSphere * ShakeMagnitude);
            yield return waitforSecondCameraShake;
            ShakeCamera = false;
        }

    }
}