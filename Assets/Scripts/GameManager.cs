using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리
using TMPro; // TextMeshPro 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버시 활성화 할 텍스트 게임 오브젝트
    public TMP_Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public TMP_Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    public TMP_Text hpText; // HP 표시할 텍스트 컴포넌트

    public PlayerController playerController;

    public GameObject itemPrefab; // 아이템 프리팹 할당 변수

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임 오버 상태

    void Start()
    {
        // 생존 시간과 게임 오버 상태를 초기화
        surviveTime = 0;
        isGameover = false;

        int spawnCount = Random.Range(1, 4);
        
        for (int i = 0; i < spawnCount; i++)
        {
            float randX = Random.Range(-8f, 8f);
            float randZ = Random.Range(-8f, 8f);
            Vector3 spawnPos = new Vector3(randX, 0.5f, randZ);

            Instantiate(itemPrefab, spawnPos, Quaternion.identity);
        }
    }

    void Update()
    {
        hpText.text = "HP: " + playerController.GetHealth();

        if (playerController.GetHealth() == 1)
        {
            hpText.text += " (!!!)";
            hpText.color = Color.red;
        }
        else
        {
            hpText.color = Color.white;
        }

        // 게임 오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 통해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // 게임 오버인 상태에서 키보드 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    // 현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame()
    {
        // 현재 상태를 게임 오버 상태로 전환
        isGameover = true;
        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된, 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            // 최고 기록의 값을 현재 생존 시간의 값으로 변경 
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 텍스트 컴포넌트를 통해 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }
}