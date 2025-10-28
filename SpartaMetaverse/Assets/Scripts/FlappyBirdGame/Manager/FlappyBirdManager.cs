using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ConstInfo;

public class FlappyBirdManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] int currentScore;

    [SerializeField] int countDown;
    [SerializeField] TextMeshProUGUI startCountText;
    public bool isStart;

    [SerializeField] Plane plane;

    [SerializeField] UiManager uiManager;

    public bool isPause;

    public int CurrentScore { get { return currentScore; } }

    private void Start()
    {
        gameManager = GameManager.Instance;
        isPause = false;
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        uiManager.OpenStartGameUi(true);
        while (countDown >= 0)
        {
            startCountText.text = countDown.ToString();
            yield return new WaitForSeconds(1f);
            countDown--;
        }
        uiManager.OpenStartGameUi(false);
        isStart = true;
        plane.InitPlane();
        yield return null;
    }

    private void Initialize()
    {
        Rigidbody2D rb = plane.GetComponent<Rigidbody2D>();
    }

    public void GetScore()
    {
        currentScore++;
        uiManager.UpdateScore(currentScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(flappyBirdGameScene);
    }

    public void GameOver()
    {
        uiManager.ResultScore();
        gameManager.UpdateMiniGameHighScore(flappyBirdScore, currentScore);
        uiManager.OpenGameOverUi(true);
        gameManager.SaveScore();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(mainScene);
    }
}
