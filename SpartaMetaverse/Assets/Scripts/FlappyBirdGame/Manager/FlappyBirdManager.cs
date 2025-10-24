using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ConstInfo;

public class FlappyBirdManager : MonoBehaviour
{
    [SerializeField] int currentScore;

    [SerializeField] int countDown;
    [SerializeField] GameObject startPopup;
    [SerializeField] TextMeshProUGUI startCountText;
    public bool isStart;

    [SerializeField] GameObject gameOverPopup;

    [SerializeField] Plane plane;

    [SerializeField] UiManager uiManager;

    private void Start()
    {
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        startPopup.SetActive(true);
        while (countDown >= 0)
        {
            startCountText.text = countDown.ToString();
            yield return new WaitForSeconds(1f);
            countDown--;
        }
        startPopup.SetActive(false);
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
        SceneManager.LoadScene(flappyBirdGame);
    }

    public void GameOver()
    {
        gameOverPopup.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(mainScene);
    }
}
