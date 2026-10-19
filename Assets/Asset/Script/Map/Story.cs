using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using TMPro;

public class Story : MonoBehaviour
{
    [SerializeField] bool playDialog;
    [SerializeField] GameObject mCamera;
    [SerializeField] GameObject Map;
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject StoryCanvas;
    [SerializeField] GameObject Kampus;
    [SerializeField] GameObject Kos;
    [SerializeField] GameObject Cafe;
    GameManager gameManager;
    PostProcessVolume ppVolume;
    Button KampusBtn;
    Button KosBtn;
    Button CafeBtn;

    [SerializeField] TextMeshProUGUI DialogBoxTxt;
    [SerializeField] float textSpeed;
    int index;
    string[] DialogLines = new string[]
    {
        "Sudah beberapa minggu aku berkuliah di sini.",
        "Ternyata seperti ini rasanya menjadi mahasiswa!",
        "Banyak hal baru yang bisa dieksplorasi, dan teman pun bertambah banyak.",
        "Tapi… karena keasyikan nongkrong, aku tidak sadar uangku tinggal segini.",
        "Aduh, bagaimana ini ya?",
        "Kalau minta lagi ke orang tua, rasanya tidak enak.",
        "Sepertinya aku harus mencari part time di kampus. ",
        "Dengan begitu, aku tetap bisa menambah relasi baru.",
        "Mulai sekarang, aku juga harus bisa menjaga pengeluaran dan pemasukan dengan baik.",
        "Agar semuanya tetap seimbang sampai akhir bulan.",
    };

    void Start()
    {
        ppVolume = mCamera.GetComponent<PostProcessVolume>();
        KampusBtn = Kampus.GetComponent<Button>();
        KosBtn = Kos.GetComponent<Button>();
        CafeBtn = Cafe.GetComponent<Button>();

        try
        {
            gameManager = GameManager.instance;
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("Error: gameManager belum di-inisialisasi!");
        }

        DialogBoxTxt.text = "";
        if (gameManager._player.PlayDialog)
        {
            StartStory();
        }
        else
        {
            StoryCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (DialogBoxTxt.text == DialogLines[index])
            {
                NextLines();
            }
            else
            {
                StopAllCoroutines();
                DialogBoxTxt.text = DialogLines[index];
            }
        }
    }

    void StartStory()
    {
        KampusBtn.enabled = false;
        KosBtn.enabled = false;
        CafeBtn.enabled = false;
        ppVolume.enabled = true;
        StoryCanvas.SetActive(true);

        index = 0;
        StartCoroutine(TypeDialog());
    }

    IEnumerator TypeDialog()
    {
        foreach (char c in DialogLines[index].ToCharArray())
        {
            DialogBoxTxt.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLines()
    {
        if (index < DialogLines.Length -1)
        {
            index++;
            DialogBoxTxt.text = "";
            StartCoroutine(TypeDialog());
        }
        else
        {
            KampusBtn.enabled = true;
            KosBtn.enabled = true;
            CafeBtn.enabled = true;
            ppVolume.enabled = false;
            StoryCanvas.SetActive(false);

            gameManager._player.ChangePlayDialog(false);
        }
    }
}
