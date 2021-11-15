using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] Transform currentStackPos,previousStackPos;

        public bool lockedIn,coroutineStarted = false;
        SstackController sstackController;

        private void Start()
        {
            sstackController = FindObjectOfType<SstackController>();
        }

        private void Update()
        {
            HandlePositioning();
        }

        private void HandlePositioning()
        {
            if (lockedIn)
            {

                if (currentStackPos.position.x == previousStackPos.position.x)
                {
                    if (coroutineStarted)
                    {
                        StopCoroutine(FollowWithDelay());
                        coroutineStarted = false;
                    }
                }
                else
                {
                    if (!coroutineStarted)
                    {
                        StartCoroutine(FollowWithDelay());
                        coroutineStarted = true;
                    }
                }

                AlignYandZ();

                transform.position = currentStackPos.position;
                transform.rotation = currentStackPos.rotation;

            }
        }

        IEnumerator FollowWithDelay() 
        {
            yield return new WaitForSeconds(sstackController.waitTimeBeforeMovingStack);
            while (coroutineStarted) 
            {
                AlignX(sstackController.stackFollowSpeed);
                yield return new WaitForEndOfFrame();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((other.CompareTag("Item") || other.CompareTag("Player")) && !lockedIn)
            {
                previousStackPos = sstackController.previousStackPos;
                currentStackPos = sstackController.currentStackPos;
                
                AlignX(sstackController.initialStuckSpeed);
                AlignYandZ();

                Transform newStackPos = Instantiate(currentStackPos, currentStackPos.position + transform.forward, Quaternion.identity);

                sstackController.previousStackPos = sstackController.currentStackPos;
                sstackController.currentStackPos = newStackPos;

                lockedIn = true;
            }
        }

        private void AlignX(float speed)
        {
            currentStackPos.position = new Vector3(Mathf.MoveTowards(currentStackPos.position.x, previousStackPos.position.x, speed * Time.deltaTime), currentStackPos.position.y, currentStackPos.position.z);
        }

        private void AlignYandZ() 
        {
            currentStackPos.position = new Vector3(currentStackPos.position.x, previousStackPos.position.y, previousStackPos.position.z) + transform.forward;
            currentStackPos.rotation = previousStackPos.localRotation;
        }
    }
}

