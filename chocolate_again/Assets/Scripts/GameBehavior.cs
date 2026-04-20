using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public Button LossButton;
    public Button WinButton;
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    public int MaxItems = 4;

    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;

    public int Items
    {
        // 2
        get { return _itemsCollected; }
        // 3
        set
        {
            _itemsCollected = value;
            ItemText.text = "Chocolate: " + Items;
            if (_itemsCollected >= MaxItems)
            {
                WinButton.gameObject.SetActive(true);
                UpdateScene("You got diabetes!");
            }
            else
            {
                ProgressText.text = "Chocolate consumed, eat " +
                    (MaxItems - _itemsCollected) + " more!";
            }
            Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }
    // 4
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: " + HP;
            if (_playerHP <= 0)
            {
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                ProgressText.text = "Ouch... that's gotta hurt.";
            }

            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public void RestartScene()
    {
        // 3
        SceneManager.LoadScene(1);
        // 4
        Time.timeScale = 1f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}