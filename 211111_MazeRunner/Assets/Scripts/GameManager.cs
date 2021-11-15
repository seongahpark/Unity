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
    [SerializeField] GameObject minimap;
    [SerializeField] Text scoreTimeText;

    //팝업창
    [SerializeField] GameObject panel_popup;
    [SerializeField] Toggle minimap_on;
    [SerializeField] GameObject btn_gotostart;
    [SerializeField] GameObject btn_exit;

    //점수
    private int score = 0;
    private int savedScore = 0;
    private string inputName;
    private string savedName = "Test";
    private string T_HighScore = "HighScore";
    private string T_HighScoreName = "HighScoreName";

    [SerializeField] InputField inputFieldName;

    public Text highScoreName;
    public Text highScore;
    public Text playerScore;
    [SerializeField] Canvas ScoreBoardPopup;
    [SerializeField] Canvas InputZone;

    private bool ScoreBoardisOpen = false;

    public float limitTime = 80;
    public float bonusTime = 30;

    private void Awake()
    {
        if (gm == null) gm = this;
        else Destroy(gameObject);

        savedScore = PlayerPrefs.GetInt(T_HighScore, savedScore);
        savedName = PlayerPrefs.GetString(T_HighScoreName, savedName);
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

        ClosePopUp();
        CloseScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart) Time.timeScale = 0;
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
        if (gameStart && Input.GetKeyDown(KeyCode.Escape)) OpenPopUp();

        scoreTimeText.text = "TIME : " + (int)slTimer.value + "\n" + "SCORE : " + (int)slTimer.value*15;
    }

    static public GameManager getIns { get { return gm; } }
   
    private void StartTheGame()
    {
        gameStart = true;
        Time.timeScale = 1;
        clearText.gameObject.SetActive(false);
        pressText.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        score = 0;
        ScoreBoardisOpen = false;
    }
    private void Restart()
    {
        SceneManager.LoadScene(0);
        gameClear = false;
        gameOver = false;
        gameStart = true;
        ScoreBoardisOpen = false;
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
        if(!ScoreBoardisOpen)
            OpenScoreBoard();

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

    private void OpenPopUp()
    {
        panel_popup.SetActive(true);
        minimap_on.gameObject.SetActive(true);
        btn_gotostart.SetActive(true);
        btn_exit.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePopUp()
    {
        Time.timeScale = 1;
        panel_popup.SetActive(false);
        minimap_on.gameObject.SetActive(false);
        btn_gotostart.SetActive(false);
        btn_exit.SetActive(false);
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene(0);
        gameClear = false;
        gameOver = false;
        gameStart = false;
    }

    public void MiniMapToggle(bool isOn)
    {
        if (isOn) minimap.gameObject.SetActive(true);
        else minimap.gameObject.SetActive(false);
    }

    public void ScoreBoard()
    {
        highScoreName.text = savedName.ToString();
        highScore.text = savedScore.ToString();
    }

    public void InputScoreName()
    {
        CloseInputZone();

        inputName = inputFieldName.text;
        if (score > savedScore)
        {
            PlayerPrefs.SetInt(T_HighScore, score);
            PlayerPrefs.SetString(T_HighScoreName, inputName);
        }
        savedScore = PlayerPrefs.GetInt(T_HighScore, savedScore);
        savedName = PlayerPrefs.GetString(T_HighScoreName, savedName);
        ScoreBoard();
    }

    public void CloseInputZone()
    {
        InputZone.enabled = false;
        InputZone.gameObject.SetActive(false);
    }
    public void CloseScoreBoard()
    {
        ScoreBoardPopup.enabled = false;
        ScoreBoardPopup.gameObject.SetActive(false);
    }
    public void OpenScoreBoard()
    {
        //점수 환산
        score = (int)slTimer.value * 15;

        ScoreBoardisOpen = true;
        ScoreBoardPopup.enabled = true;
        InputZone.enabled = true;
        InputZone.gameObject.SetActive(true);
        ScoreBoardPopup.gameObject.SetActive(true);
        playerScore.text = score.ToString();


        ScoreBoard(); //먼저 보여주고 이름 입력하면 한 번 더 갱신
    }
}
