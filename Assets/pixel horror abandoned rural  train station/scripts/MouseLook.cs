using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace littleDog
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 250f;   // raw input needs high values
        public Transform PlayerBody;

        float xRotation = 0f;
        public static bool CanMove = true;

        void Start()
        {
            LockCursor(true);
        }

        void Update()
        {
            // Toggle pause with ESC
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CanMove = !CanMove;
                LockCursor(CanMove);
                Time.timeScale = CanMove ? 1 : 0;
            }

            // Stop camera if paused
            if (!CanMove) return;

            // Use RAW input (true FPS)
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Vertical rotation
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Horizontal rotation (player body)
            PlayerBody.Rotate(Vector3.up * mouseX);
        }

        void LockCursor(bool state)
        {
            if (state)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
