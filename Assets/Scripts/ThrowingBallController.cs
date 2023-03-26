using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ThrowingBallController : MonoBehaviour
    {
        [SerializeField] private GameObject _stick;
        [SerializeField] private float _speed;
        private bool _isActive;
        public event Action FailEvent;
        private void Start()
        {
            _stick.SetActive(false);
        }

        private void Update()
        {
            if(!_isActive) return;

            transform.position += new Vector3(0, _speed*Time.deltaTime, 0);
        }

        private void OnTriggerEnter2D(Collider2D otherObject)
        {
            if (otherObject.GetComponent<TargetBallController>()) //!=null
            {
                // _stick.GetComponent<SpriteRenderer>().enabled = true;
                _stick.SetActive(true);
                _speed = 0;
                transform.SetParent(otherObject.transform);
                // transform.SetParent(null); parentsiz birakmak icin
            }

            if (otherObject.GetComponent<ThrowingBallController>())
            {
                FailEvent?.Invoke();
            }
        }

        public void Shoot()
        {
            transform.SetParent(null);
            _isActive = true;
        }
        
    }
}