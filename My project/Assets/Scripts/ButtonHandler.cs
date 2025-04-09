using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public int duration = 5;
    public GameObject buttonPrefab;
    public int createdelay = 3;
    public int maxButtons = 5;
    public bool isbuttonpressed = false;
    public int score = 0;
    public int scoreToWin = 10;
    // 스코어 UI를 위한 변수
    public TMP_Text scoreText; // 스코어 UI 텍스트
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.startPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 시작 버튼 클릭시 게임 시작
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.gameState == GameManager.GameState.Start)
        {
            OnButtonClick();
        }
        
       
        UpdateScoreUI(); // 스코어 UI 업데이트
    }

    public void OnButtonClick()
{
    if (GameManager.Instance.gameState == GameManager.GameState.Start && !isbuttonpressed)
    {
        GameManager.Instance.gameState = GameManager.GameState.playing;
        Debug.Log("게임 시작!");
        isbuttonpressed = true;
        StartCoroutine(SpawnButtons());
    }
}


    public void SpawnButton()
    {
        GameObject button = Instantiate(buttonPrefab, new Vector3(Random.Range(-5, 10), Random.Range(-5, 10), 0), Quaternion.identity);
        button.GetComponent<Button>().onClick.AddListener(OnButtonPressed);
        ButtonDestory(button);
    }

    // 버튼 생성  코루틴
    public IEnumerator SpawnButtons()
    {
        for (int i = 0; i < maxButtons; i++)
        {
            SpawnButton();
            yield return new WaitForSeconds(createdelay);
        }
    }

    // 버튼 클릭시 점수 증가
    public void OnButtonPressed()
    {
        score++;
        if (score >= scoreToWin)
        {
            GameManager.Instance.gameState = GameManager.GameState.Win;
            // 버튼 클릭 후 파괴);
            Debug.Log("You Win!");
            GameManager.Instance.Wingame();
            Time.timeScale = 0;
        }
        {
            Debug.Log("버튼 클릭" + score);
        }
    }

    // 버튼 파괴
    public void ButtonDestory(GameObject buttonPrefab)
    {
        Destroy(buttonPrefab, duration);
    }
    // 스코어 UI 업데이트
    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }


}
