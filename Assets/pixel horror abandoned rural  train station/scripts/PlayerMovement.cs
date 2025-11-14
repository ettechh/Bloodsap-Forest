using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace littleDog
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        public float speed = 12f;
        public float gravity = -9.81f;
        public float JumpHight = 3;
        Vector3 V;

        private void Awake()
        {
            controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {
            if (MouseLook.CanMove == false) return;

            // Ground logic
            if (controller.isGrounded)
            {
                // Keep player snapped to ground
                if (V.y < 0)
                    V.y = -2f;

                // Only jump when grounded
                if (Input.GetButtonDown("Jump"))
                {
                    V.y = Mathf.Sqrt(JumpHight * -2f * gravity);
                }
            }

            // Movement input
            float X = Input.GetAxis("Horizontal");
            float Z = Input.GetAxis("Vertical");

            Vector3 M = transform.right * X + transform.forward * Z;

            // Move horizontally
            controller.Move(M * speed * Time.deltaTime);

            // Apply gravity
            V.y += gravity * Time.deltaTime;

            // Apply vertical movement
            controller.Move(V * Time.deltaTime);
        }
    }
}
