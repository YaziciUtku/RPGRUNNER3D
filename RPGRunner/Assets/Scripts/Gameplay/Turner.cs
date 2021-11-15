using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Turner : MonoBehaviour
    {
        [SerializeField] float angle = -45f;      

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerForwardMover")) 
            {
                StartCoroutine(Rotater(other, Vector3.up * angle));
            }
        }

        IEnumerator Rotater(Collider other, Vector3 byAngles) 
        {
            var fromAngle = other.transform.rotation; 
            var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);

            for (var t = 0f; t < 1; t += Time.deltaTime / 0.8f) 
            { 
                other.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t); 
                yield return null; 
            }
        }
    }
}

