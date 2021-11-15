using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Movement
{
    public class PlayerForwardMover : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        
        void Update()
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}

