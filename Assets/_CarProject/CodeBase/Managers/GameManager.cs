using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _cars = Array.Empty<GameObject>();
    [SerializeField] private GameObject _showRoom;
    [SerializeField] private GameObject _playTerrain;

    [SerializeField] private GameObject _roomCamera;
    [SerializeField] private GameObject _playModeCamera;

    private bool _isInPlayMode;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_isInPlayMode)
            {
                RunRoomScene();
            }
        }
    }

    public void StartPlayMode(int carIndex)
    {
        DeactivateShowRoom();
        ActivatePlayMap(carIndex);
        if (carIndex >= 0 && carIndex < _cars.Length)
        {
            _cars[carIndex].SetActive(true);
        }
        _isInPlayMode = true;
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
