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

    [SerializeField] private Slider slTimer;
    [SerializeField] Text clearText;
    [SerializeField] Text pressText;
    [SerializeField] GameObject panel;

    public float limitTime = 80;
    public float bonusTime = 30;

    private void Awake()
    {
        if (gm == null) gm = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        slTimer.value = limitTime;
        clearText.text = "MAZE RUNNER";
        pressText.text = "PRESS 'S' TO START";
        clearText.gameObject.SetActive(true);
        pressText.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart && Input.GetKeyDown(KeyCode.S)) StartTheGame();
        if((gameClear || gameOver) && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
            Time.timeScale = 1;
        }
        if (gameOver) GameOver();
        if (gameClear) GameClear();
        if (gameStart)
        {
            SliderTimer();
        }
    }

    static public GameManager getIns { get { return gm; } }

    private void StartTheGame()
    {
        gameStart = true;
        Time.timeScale = 1;
        clearText.gameObject.SetActive(false);
        pressText.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
    }
    private void Restart()
    {
        SceneManager.LoadScene(0);
        gameClear = false;
        gameOver = false;
        gameStart = true;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        clearText.text = "GAME OVER";
        pressText.text = "PRESS 'R' TO RESTART";
        clearText.gameObject.SetActive(true);
        pressText.gameObject.SetActive(true);
    }

        private void GameClear()
    {
        Time.timeScale = 0;
        clearText.text = "GAME CLEAR";
        pressText.text = "PRESS 'R' TO RESTART";
        clearText.gameObject.SetActive(true);
        pressText.gameObject.SetActive(true);
    }

    private void SliderTimer()
    {
        if (slTimer.value > 0.0f)
        {
            slTimer.value -= Time.deltaTime;
        }
        else
        {
            gameOver = true;
        }
    }

    public void GetItem()
    {
        slTimer.value += bonusTime;
        if (slTimer.value > limitTime) slTimer.value = limitTime;
    }
}
