using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject mCamera;
    [SerializeField] GameObject Map;
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject Kampus;
    [SerializeField] GameObject Kos;
    [SerializeField] GameObject Cafe;
    PostProcessVolume ppVolume;
    Button KampusBtn;
    Button KosBtn;
    Button CafeBtn;

    void Start()
    {
        ppVolume = mCamera.GetComponent<PostProcessVolume>();
        KampusBtn = Kampus.GetComponent<Button>();
        KosBtn = Kos.GetComponent<Button>();
        CafeBtn = Cafe.GetComponent<Button>();

        CloseMenu();
    }

    public void OpenMenu()
    {
        KampusBtn.enabled = false;
        KosBtn.enabled = false;
        CafeBtn.enabled = false;
        ppVolume.enabled = true;
        MenuCanvas.SetActive(true);
    }

    public void CloseMenu()
    {
        KampusBtn.enabled = true;
        KosBtn.enabled = true;
        CafeBtn.enabled = true;
        ppVolume.enabled = false;
        MenuCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
