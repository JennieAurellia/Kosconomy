using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Testing : MonoBehaviour
{
    [SerializeField] GameObject mCamera;
    [SerializeField] GameObject Menu;
    PostProcessVolume ppVolume;

    void Start() 
    {
        ppVolume = mCamera.GetComponent<PostProcessVolume>();
        
        ppVolume.enabled = false;
        Menu.SetActive(false);
    }

    public void test()
    {
        ppVolume.enabled = true;
        Menu.SetActive(true);
    }
}
