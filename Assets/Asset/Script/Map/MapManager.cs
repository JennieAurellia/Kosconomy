using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyTxt;
    [SerializeField] TextMeshProUGUI EnergyTxt;
    [SerializeField] TextMeshProUGUI RelationTxt;

    void FixedUpdate()
    {
        UpdatePlayerStats();
    }

    void UpdatePlayerStats()
    {
        GameManager gameManager = GameManager.instance;
        if (MoneyTxt.text != gameManager._player.CurrentMoney.ToString())
        {
            MoneyTxt.text = gameManager._player.CurrentMoney.ToString();
        }
        if (EnergyTxt.text != gameManager._player.CurrentEnergy.ToString())
        {
            EnergyTxt.text = gameManager._player.CurrentEnergy.ToString();
        }
        if (RelationTxt.text != gameManager._player.CurrentRelation.ToString())
        {
            RelationTxt.text = gameManager._player.CurrentRelation.ToString();
        }
    }

    public void GoToKampus()
    {
        // GameManager gameManager = GameManager.instance;
        // if (gameManager._player.CurrentEnergy >= 5)
        // {
        //     gameManager._player.AddEnergy(-5);
        //     LoadScene.LoadSceneByName("Cuci Piring");
        // }

        LoadScene.LoadSceneByName("Cuci Piring");
    }
}
