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
    private float feverTime = 6.0f;

    [SerializeField] private GameObject itemManager;
    [SerializeField] private GameObject uiManager;

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
    }

    // Update is called once per frame
    void Update()
    {
        chkClear();
        if ((gameClear || gameOver))
        {
            Time.timeScale = 0;
        }
        if ((gameClear || gameOver) && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
            Time.timeScale = 1;
        }
        if (isFever) StartCoroutine(IsFeverTime());
    }
    static public GameManager getIns
    {
        get { return gm; }
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(0);
        gameStart = false;
        gameOver = false;
        gameClear = false;
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

    IEnumerator IsFeverTime()
    {
        yield return new WaitForSeconds(feverTime);
        isFever = false;
    }
}
