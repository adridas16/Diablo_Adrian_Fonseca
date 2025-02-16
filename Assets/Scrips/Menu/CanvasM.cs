using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasM : MonoBehaviour
{
    [SerializeField] private GameObject Pause;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale==1)
        {
            Time.timeScale = 0;
            Pause.SetActive(true);

        }
    }
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();

    }
    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void Respawn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);

    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        Pause.SetActive(false);
    }
}
