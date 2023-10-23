using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class CameraFollow : MonoBehaviour
    {
        
        public Transform player;
        [SerializeField]
        private float _smoothTime;
        private Vector3 _currentVelocity = Vector3.zero;
        private Vector3 _offSet;//follow offset

      

        // Start is called before the first frame update
        void Start()
        {
           // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
          //  _offSet = transform.position - player.position;
        }

        //these are initialze offset for keeping camera centered toward player whick is not in centre
         float InititialYOffset = 26.91f;
         float InititialXOffset = -41.3f;
         float InititialZOffset = 32.5f;
        public void Initilize(Transform player)
        {
          
            this.player = player;
            transform.position = player.transform.position;
            transform.position += new Vector3(InititialXOffset, InititialYOffset, InititialZOffset);

            _offSet = transform.position - player.position;
           
        }

        // Update is called once per frame
        void LateUpdate()
        {
            playerFollow();
        }


        void playerFollow()
        {
            if (player != null)
            {
                var TargetedPosition = player.position + _offSet;
                transform.position = Vector3.SmoothDamp(transform.position, TargetedPosition, ref _currentVelocity, _smoothTime);
                //  transform.position = Player.position - transform.position;
            }
        }
    }
}