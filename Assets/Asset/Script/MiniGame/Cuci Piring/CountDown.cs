using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class CountDown : MonoBehaviour
{
    public bool IsPaused = false;
    [SerializeField] TextMeshProUGUI CountDownText;
    [SerializeField] public float CountDownTime;
    [SerializeField] private GameObject PlayerSponge;
    [SerializeField] private GameObject EnemySponge;
    PlayerCuciPiring PlayerCuciPiringScript;
    EnemyCuciPiring EnemyCuciPiringScript;

    [SerializeField] GameObject mCamera;
    PostProcessVolume ppVolume;
    [SerializeField] GameObject FinishCanvas;
    [SerializeField] TextMeshProUGUI ScoreTxt;
    [SerializeField] TextMeshProUGUI MoneyTxt;

    GameManager gameManager;

    void Start()
    {
        ppVolume = mCamera.GetComponent<PostProcessVolume>();
        PlayerCuciPiringScript = PlayerSponge.GetComponent<PlayerCuciPiring>();
        EnemyCuciPiringScript = EnemySponge.GetComponent<EnemyCuciPiring>();

        FinishCanvas.SetActive(false);

        try
        {
            gameManager = GameManager.instance;
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("Error: gameManager belum di-inisialisasi!");
        }
    }

    void FixedUpdate()
    {
        if (!IsPaused)
        {
            if (CountDownTime > 0)
            {
                CountDownTime -= Time.deltaTime;
            }
            else
            {
                IsPaused = true;
                CountDownTime = 0;
                CountDownText.color = Color.red;

                int Money;

                if (EnemyCuciPiringScript.scorePiring > PlayerCuciPiringScript.scorePiring)
                {
                    Money = (PlayerCuciPiringScript.scorePiring * 2) - EnemyCuciPiringScript.scorePiring;
                }
                else
                {
                    Money = (PlayerCuciPiringScript.scorePiring * 2);
                }
                
                gameManager._player.AddMoney(Money);
                ppVolume.enabled = true;

                ScoreTxt.text  = "Your Score: " + PlayerCuciPiringScript.scorePiring;
                
                if (Money < 0)
                {
                    MoneyTxt.text = "- " + (Money * -1);
                }
                else
                {
                    MoneyTxt.text = "+ " + Money;
                }

                FinishCanvas.SetActive(true);

                // Debug.Log("Banyak piring yang dicuci: " + CuciPiringScript.scorePiring);
            }

            int minutes = Mathf.FloorToInt(CountDownTime / 60);
            int seconds = Mathf.FloorToInt(CountDownTime % 60);
            CountDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
