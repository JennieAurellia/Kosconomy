using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCuciPiring : MonoBehaviour
{
    // public float speed;
    public int scorePiring = 0;
    private int pressCount = 0;
    private Boolean isAPressed = false;
    [SerializeField] GameObject SponsCuci;
    [SerializeField] TextMeshProUGUI ScoreTxt;
    [SerializeField] GameObject piring;
    [SerializeField] GameObject gameManager;
    CountDown minigameCountDown;

    void Start()
    {
        minigameCountDown = gameManager.GetComponent<CountDown>();
    }

    void Update()
    {
        if (!minigameCountDown.IsPaused)
        {
            bool enemyPressed = UnityEngine.Random.Range(0, 50) == 0;
            if (enemyPressed)
            {
                if (!isAPressed)
                {
                    isAPressed = true;
                    SponsCuci.transform.position = new Vector3(-3f, -2f, 0);
                }
                else
                {
                    pressCount++;
                    isAPressed = false;
                    SponsCuci.transform.position = new Vector3(-2f, -1f, 0);
                }
            }
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