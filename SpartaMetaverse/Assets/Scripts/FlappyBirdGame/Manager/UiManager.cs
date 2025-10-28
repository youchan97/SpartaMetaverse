using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ConstInfo;

public class UiManager : MonoBehaviour
{
    [SerializeField] FlappyBirdManager flappyBirdManager;

    [SerializeField] GameObject startPopup;

    [SerializeField] GameObject gameOverPopup;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] GameObject bestScore;

    [SerializeField] GameObject pausePopup;


    public void OpenStartGameUi(bool isTrue) => startPopup.SetActive(isTrue);
    public void OpenGameOverUi(bool isTrue) => gameOverPopup.SetActive(isTrue);

    public void OpenPauseUi(bool isTrue) => pausePopup.SetActive(isTrue);

    public void UpdateScore(int score)
    {
        scoreText.text = "점수 : " + score.ToString();
    }

    public void ResultScore()
    {
        int high = 0;
        if (GameManager.Instance.MiniGameScore.ContainsKey(flappyBirdScore))
            high = GameManager.Instance.MiniGameScore[flappyBirdScore];
        int cur = flappyBirdManager.CurrentScore;
        highScore.text = "최고 점수 : " + high;
        currentScore.text = "현재 점수 : " + cur.ToString();
        if(high < cur)
        {
            bestScore.SetActive(true);
        }
    }
}
