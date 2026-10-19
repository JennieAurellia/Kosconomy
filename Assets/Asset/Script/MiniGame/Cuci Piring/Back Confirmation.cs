using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BackConfirmation : MonoBehaviour
{
    [SerializeField] GameObject mCamera;
    PostProcessVolume ppVolume;
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject gameManager;
    CountDown minigameCountDown;

    void Start()
    {
        ppVolume = mCamera.GetComponent<PostProcessVolume>();
        minigameCountDown = gameManager.GetComponent<CountDown>();

        ppVolume.enabled = false;
        MenuCanvas.SetActive(false);
    }

    public void ShowConfirmationPanel()
    {
        minigameCountDown.IsPaused = true;
        ppVolume.enabled = true;
        MenuCanvas.SetActive(true);
    }

    public void ContinueMinigame()
    {
        minigameCountDown.IsPaused = false;
        ppVolume.enabled = false;
        MenuCanvas.SetActive(false);
    }

    public void BackToMap()
    {
        minigameCountDown.IsPaused = false;
        ppVolume.enabled = false;
        MenuCanvas.SetActive(false);
        LoadScene.LoadSceneByName("Map Scene");
    }

    public void FinishGame()
    {
        LoadScene.LoadSceneByName("Map Scene");
    }
}
