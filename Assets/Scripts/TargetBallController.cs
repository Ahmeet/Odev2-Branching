using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TargetBallController : MonoBehaviour
    {
        [SerializeField] private float _rotatingSpeed;
        
        private void Update()
        {
            transform.Rotate(new Vector3(0,0,_rotatingSpeed));
        }
    }
}