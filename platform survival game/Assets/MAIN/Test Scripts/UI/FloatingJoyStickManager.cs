using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TestOnly
{
    public class FloatingJoyStickManager : MonoBehaviour
    {
        public GameObject floatingJoyStick;
       // private PlayerManager playerManager;

        private void Awake()
        {
           // floatingJoyStick.SetActive(true);
        }

        // Start is called before the first frame update
        void Start()
        {
            
           
        }

        public void DisableFloatingJoyStick()
        {

            floatingJoyStick.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}