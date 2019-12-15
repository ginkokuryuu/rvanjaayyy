using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using SimpleInputNamespace;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        [SerializeField] Transform spawnPoint = null;
        public GameObject[] pointCanvas;
        float timeCD = 5f;
        bool isShowing = false;

        Rigidbody rb;

        private CarController m_Car; // the car controller we want to use

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            rb = GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {

            // pass the input to the car!
            float h = SimpleInput.GetAxis("Horizontal");
            float v = SimpleInput.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = 0f;
            if (Input.GetKey(KeyCode.Space))
            {
                handbrake = 1f;
            }
            else
            {
                handbrake = 0f;
            }
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }

        private void Update()
        {
            if (transform.position.y < -5f)
            {
                transform.position = spawnPoint.position;
                rb.velocity = Vector3.zero;
            }

            if (isShowing)
            {
                timeCD -= Time.deltaTime;
                if(timeCD < 0f)
                {
                    isShowing = false;
                    CloseInfo();
                    timeCD = 5f;
                }
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Respawn"))
            {
                transform.position = spawnPoint.position;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Point"))
            {
                OpenInfo(other.gameObject.name[0] - '0');
            }
        }

        void OpenInfo(int index)
        {
            pointCanvas[index].SetActive(true);
            isShowing = true;
        }

        void CloseInfo()
        {
            foreach(GameObject g in pointCanvas)
            {
                g.SetActive(false);
            }
        }
    }
}
