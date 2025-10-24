using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject startPopup;

    [SerializeField] GameObject gameOverPopup;
    [SerializeField] TextMeshProUGUI scoreText;


    public void StartGameUi(bool isTrue) => startPopup.SetActive(isTrue);
    public void GameOverUi(bool isTrue) => gameOverPopup.SetActive(isTrue);

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
