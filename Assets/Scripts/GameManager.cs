using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ThrowingParentController _throwingParentController;
        [SerializeField] private Camera _camera;
        
        private void Start()
        {
            _throwingParentController.AllBallsFinished += Win;
            foreach (var throwingBallController in FindObjectsOfType<ThrowingBallController>())
            {
                throwingBallController.FailEvent += GameOver;
            }
        }

        private void GameOver()
        {
            _camera.backgroundColor = Color.red;
        }

        private void Win()
        {
            _camera.backgroundColor = Color.green;
        }
        
        private void OnDisable()
        {
            foreach (var throwingBallController in FindObjectsOfType<ThrowingBallController>())
            {
                throwingBallController.FailEvent -= GameOver;
            }
            _throwingParentController.AllBallsFinished -= Win;

            SceneManager.LoadScene(0);
            SceneManager.LoadScene(1);
        }
    }
}