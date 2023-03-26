using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ThrowingParentController : MonoBehaviour
    {
        [SerializeField] private List<ThrowingBallController> _availableBalls = new List<ThrowingBallController>();
        [SerializeField] private GameObject _throwingBallPrefab;
        [SerializeField] private int _totalBallAmount = 5;

        public event Action AllBallsFinished;
        
        private void Awake()
        {
            for (int i = 0; i < _totalBallAmount; i++)
            {
                GameObject instantiatedBall = Instantiate(_throwingBallPrefab);
                instantiatedBall.transform.SetParent(gameObject.transform);
                instantiatedBall.transform.localPosition = new Vector3(0, -i, 0);
                
                _availableBalls.Add(instantiatedBall.GetComponent<ThrowingBallController>());
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _availableBalls.Count > 0)
            {
                _availableBalls[0].Shoot();
                _availableBalls.RemoveAt(0);
                MoveForward();
                if (_availableBalls.Count < 1)
                {
                    AllBallsFinished?.Invoke();
                }
            }
        }

        private void MoveForward()
        {
            gameObject.LeanMoveY(transform.position.y + 1, 0.1f);
        }
    }
}