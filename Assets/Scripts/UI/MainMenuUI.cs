using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button cineTutoButton;
    private void Awake() {
        playButton.onClick.AddListener(() =>{
            Loader.Load(Loader.Scene.SampleScene);
            //SceneManager.LoadScene(1);
        });
        quitButton.onClick.AddListener(() =>{
            Application.Quit();
        });
        cineTutoButton.onClick.AddListener(() =>{
            Loader.Load(Loader.Scene.CinemachiScene);
        });
        Time.timeScale = 1f;
    }
}
