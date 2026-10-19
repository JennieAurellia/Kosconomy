using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCuciPiring : MonoBehaviour
{
    // public float speed;
    public int scorePiring = 0;
    private int pressCount = 0;
    private Boolean isAPressed = false;
    public GameObject SponsCuci;
    [SerializeField] TextMeshProUGUI ScoreTxt;
    [SerializeField] GameObject piring;
    private Vector3 sponsPos;

    void Start() 
    {   
        sponsPos = SponsCuci.transform.position;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isAPressed)
        {
            isAPressed = true;
            SponsCuci.transform.position = new Vector3(sponsPos.x - 1, sponsPos.y - 1, sponsPos.z);
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isAPressed)
        {
            pressCount++;
            isAPressed = false;
            SponsCuci.transform.position = sponsPos;
        }

        if (pressCount >= 4)
        {
            scorePiring++;
            pressCount = 0;
            ScoreTxt.text = scorePiring.ToString();

            Transform piringTransform = piring.transform;
            if (piringTransform.GetChild(1).gameObject.activeSelf && piringTransform.childCount <= 5)
            {
                InitPiringBersih(piringTransform);
            }
            else
            {
                if(!piringTransform.GetChild(0).gameObject.activeSelf)
                {
                    piringTransform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    piringTransform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    private void InitPiringBersih(Transform piringTransform)
    {
        // Get last two children
        Transform topChild = piringTransform.GetChild(piringTransform.childCount - 1);
        Transform belowTopChild = piringTransform.GetChild(piringTransform.childCount - 2);
        // Calculate Y distance between the two children
        float distanceY = topChild.localPosition.y - belowTopChild.localPosition.y;
        // Spawn position (stacking upward)
        Vector3 spawnLocalPos = topChild.localPosition + new Vector3(0, distanceY, 0);
        // Instantiate
        GameObject clonePiring = Instantiate(belowTopChild.gameObject, piringTransform);
        clonePiring.transform.localPosition = spawnLocalPos;
        clonePiring.transform.localRotation = belowTopChild.localRotation;
        clonePiring.transform.localScale = belowTopChild.localScale;
    }
}