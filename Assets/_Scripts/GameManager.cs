using TMPro;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    //[SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;

    private bool isSettingsMenuActive;
    //creates public getter for the bool
    //this way the variable is read only
    //without make it public
    public bool IsSettingsMenuActive => isSettingsMenuActive;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        DisableSettingMenu();
    }

    public void IncreaseScore()
    {
        score++;
        //scoreText.text = $"Score: {score}";
        coinCounter.UpdateScore(score);
    }

    private void ToggleSettingsMenu()
    {
        if (isSettingsMenuActive)
        {
            DisableSettingMenu();
        }
        else
        {
            EnableSettingMenu();
         }
    }
    private void EnableSettingMenu()
    {
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isSettingsMenuActive = true;
    }
    public void DisableSettingMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isSettingsMenuActive = false;
    }
    public void QuitGame()
    {
# if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//EditorApplication.isPlaying would has a complie error
# else
        Application.Quit();
# endif
    }
}
