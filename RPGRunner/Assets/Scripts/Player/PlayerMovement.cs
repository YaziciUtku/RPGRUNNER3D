using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] Joystick joystick;
        [SerializeField] float speed = 5f;
        [SerializeField] float clampFactor = 5f;

        private void Update()
        {
            MoveLeftRight();
            ClampPosition();
        }

        private void MoveLeftRight()
        {
            transform.localPosition += new Vector3(joystick.Horizontal * Time.deltaTime * speed, 0, 0);
        }

        private void ClampPosition()
        {
            Vector3 clampedPos = transform.localPosition;
            clampedPos.x = Mathf.Clamp(clampedPos.x, - clampFactor, clampFactor);
            transform.localPosition = clampedPos;
        }
    }
}

