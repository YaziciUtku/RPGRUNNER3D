using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class SstackController : MonoBehaviour
    {
        public Transform currentStackPos, previousStackPos;
        public float initialStuckSpeed = 8f;
        public float stackFollowSpeed = 4.7f;
        public float waitTimeBeforeMovingStack = 0.05f;
    }
}
