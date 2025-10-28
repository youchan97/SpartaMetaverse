using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ConstInfo;

public class PopupManager : MonoBehaviour
{
    [SerializeField] GameObject miniGamePopup;
    [SerializeField] GameObject leaderBoardPopup;

    [SerializeField] TextMeshProUGUI flappyScore;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        InitLeaderBoardScore();
    }

    public void IsMiniGamePopupOpen(bool isOpen) => miniGamePopup.SetActive(isOpen);
    public void IsLeaderBoardPopupOpen(bool isOpen) => leaderBoardPopup.SetActive(isOpen);

    public void IntoMiniGameScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void InitLeaderBoardScore()
    {
        if(gameManager.MiniGameScore.ContainsKey(flappyBirdScore))
            flappyScore.text = "최고 점수 :\t" + gameManager.MiniGameScore[flappyBirdScore];
    }
}
