using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gm = null;
    public GameObject getReady;
    public GameObject gameOver;
    public Text pressText;
    public Text countText;
    public PlayerControl pc;
    float countTime = 0;
    public bool isGameOver = false;

    public void Awake()
    {
        if (gm == null)
        {
            gm = this;
            //DontDestroyOnLoad(gm.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Ready();
        getReady.SetActive(true);
        countText.text = pc.score.ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("TIME SCALE : " + Time.timeScale);
        gameStart();
        onGameRestart();
        countTime += Time.deltaTime;
        countText.text = pc.score.ToString("D4");
        if (countTime > 3.0f)
        {
            pc.score += 5;
            countTime -= 3.0f;
        }
    }

    static public GameManager getIns
    {
        get
        {
            return gm;
        }
    }

    public void Ready()
    {
        pressText.text = "PRESS  S  TO START";
        isGameOver = false;
        getReady.SetActive(true);
        gameOver.SetActive(false);
        Time.timeScale = 0;
    }

    public void gameStart()
    {
        if (!isGameOver && Input.GetKey(KeyCode.S))
        {
            pressText.text = "";
            getReady.SetActive(false);
            Time.timeScale = 2;
        }
    }
    public void onGameOver()
    {
        isGameOver = true;
        gameOver.SetActive(true);
        Time.timeScale = 0;
        pressText.text = "PRESS  R  TO RESTART";
    }

    public void onGameRestart()
    {
        if (isGameOver && Input.GetKey(KeyCode.R))
        {
            isGameOver = false;
            SceneManager.LoadScene(0);
        }
    }
}
