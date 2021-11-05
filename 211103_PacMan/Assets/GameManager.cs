using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gm = null;
    public bool gameStart = false;
    public bool gameOver = false;
    public bool gameClear = false;
    public bool isFever = false;
    [SerializeField] private float feverTime = 5.0f;

    [SerializeField] private GameObject itemManager;
    [SerializeField] private GameObject uiManager;
    [SerializeField] private Text t_press;

    private itemControl[] items;
    private int itemMaxLength;
    [SerializeField] private int itemLength;
    // Start is called before the first frame update
    private void Awake()
    {
        if (gm == null) gm = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        items = itemManager.GetComponentsInChildren<itemControl>();
        itemMaxLength = items.Length;
        uiManager.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        chkClear();
        if (!gameStart && Input.GetKeyDown(KeyCode.S)) GameStart();
        if ((gameClear || gameOver) && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
            Time.timeScale = 1;
        }
        if (gameOver) GameOver();
        if (gameClear) GameClear();
        //if (isFever) StartCoroutine(IsFeverTime());
    }
    static public GameManager getIns
    {
        get { return gm; }
    }
    private void GameOver()
    {
        uiManager.SetActive(true);
        Time.timeScale = 0;
        t_press.text = "GAME OVER" + "\n" + "PRESS 'R' TO RESTART";
    }
    private void GameStart()
    {
        gameStart = true;
        Time.timeScale = 1;
        uiManager.SetActive(false);
    }
    private void Restart()
    {
        SceneManager.LoadScene(0);
        gameStart = false;
        gameOver = false;
        gameClear = false;
    }

    private void GameClear()
    {
        uiManager.SetActive(true);
        Time.timeScale = 0;
        t_press.text = "GAME CLEAR" + "\n" + "PRESS 'R' TO RESTART";
    }
    private void chkClear()
    {
        items = itemManager.GetComponentsInChildren<itemControl>();
        itemLength = items.Length;
        if (itemLength <= 0)
        {
            gameClear = true;
        }
    }

    public IEnumerator IsFeverTime()
    {
        isFever = true;
        yield return new WaitForSeconds(feverTime);
        isFever = false;
    }
}
