using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Jeffrin Dumas
/// </summary>
public class Menus : MonoBehaviour
{
    public GameObject panel;
    public GameObject PauseMenuCanvas;

    private Transform _cameraTransform;
    private Transform _cameraPrefferedLookat;


    private const float _rotationSpeed = 2.5f;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (_cameraPrefferedLookat != null)
        {
            _cameraTransform.rotation = Quaternion.Slerp(_cameraTransform.rotation, _cameraPrefferedLookat.rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public void Start()
    {
        panel.SetActive(false);
        PauseMenuCanvas.SetActive(false);
    }

    public void NewGameLoad()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScenes(int SceneNumb)
    {
        SceneManager.LoadScene(SceneNumb);
    }

    public void InstructionMenu()
    {
        panel.SetActive(true);
    }

    public void Back()
    {
        panel.SetActive(false);
    }

    public void Resume()
    {
        PauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {

        if (PauseMenuCanvas.gameObject.activeInHierarchy == false)
        {
            PauseMenuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            PauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public void LookAtMenu(Transform menuTransform)
    {
        _cameraPrefferedLookat = menuTransform;
    }


}