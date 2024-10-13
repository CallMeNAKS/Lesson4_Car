using Cinemachine;
using CodeBase.Enemy;
using CodeBase.Enemy.Factory;
using System;
using UnityEngine;

namespace CodeBase.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject[] _cars = Array.Empty<GameObject>();
        [SerializeField] private GameObject _showRoom;
        [SerializeField] private GameObject _playTerrain;

        [SerializeField] private GameObject _roomCamera;
        [SerializeField] private GameObject _playModeCamera;

        [SerializeField] private Transform _playerTransform;

        [SerializeField] private float _minDistance = 5f;
        [SerializeField] private float _maxDistance = 15f;

        [SerializeField] private int _enemiesToSpawn = 5;

        [SerializeField] private RedEnemy _redEnemyPrefab;
        
        private RedEnemyFactory _redEnemyFactory;

        private bool _isInPlayMode;

        private void Awake()
        {
            _redEnemyFactory = new RedEnemyFactory(_redEnemyPrefab, 15);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (_isInPlayMode)
                {
                    RunRoomScene();
                }
            }
            if (Input.GetKeyUp(KeyCode.G))
            {
                if (_isInPlayMode)
                {
                    SpawnRedEnemy();
                }
            }
        }

        public void StartPlayMode(int carIndex)
        {
            SpawnRedEnemy();

            DeactivateShowRoom();
            ActivatePlayMap(carIndex);
            if (carIndex >= 0 && carIndex < _cars.Length)
            {
                _cars[carIndex].SetActive(true);
            }
            _isInPlayMode = true;
        }

        private void SpawnRedEnemy()
        {
            for (int i = 0; i < _enemiesToSpawn; i++)
            {
                Vector3 spawnPosition = GetRandomPositionAroundPlayer();
                AbstractEnemy redEnemy = _redEnemyFactory.CreateEnemy(spawnPosition);
                redEnemy.Move();
            }
        }

        private Vector3 GetRandomPositionAroundPlayer()
        {
            float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f);

            float distance = UnityEngine.Random.Range(_minDistance, _maxDistance);

            Vector3 spawnPosition = new Vector3(
                Mathf.Cos(angle) * distance,
                0,
                Mathf.Sin(angle) * distance
            );

            return _playerTransform.position + spawnPosition;
        }

        public void RunRoomScene()
        {
            DeactivatePlayMap();
            ActivateShowRoom();
            _isInPlayMode = false;
        }

        private void DeactivateShowRoom()
        {
            _showRoom.SetActive(false);
            _roomCamera.SetActive(false);
        }

        private void ActivateShowRoom()
        {
            _showRoom.SetActive(true);
            _roomCamera.SetActive(true);
        }

        private void ActivatePlayMap(int carIndex)
        {
            _playTerrain.SetActive(true);
            _playModeCamera.SetActive(true);

            CinemachineVirtualCamera cameraComponent = _playModeCamera.GetComponent<CinemachineVirtualCamera>();
            var selectedCarTransform = _cars[carIndex].transform;

            cameraComponent.Follow = selectedCarTransform;
            cameraComponent.LookAt = selectedCarTransform;

            _playerTransform = selectedCarTransform;
        }

        private void DeactivatePlayMap()
        {
            _playTerrain.SetActive(false);
            _playModeCamera.SetActive(false);

            foreach (var car in _cars)
            {
                car.SetActive(false);
            }
        }
    }

}