using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootManager : MonoBehaviour
{
    //********* Ui 버튼 *********//
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject[] canvas;
    [SerializeField] private Image panel;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text countdownText_2;
    [SerializeField] private TMP_Text sc;
    
    //********* 스폰포인트 및 스폰 오브젝트 *********//
    [SerializeField] private GameObject discus;
    [SerializeField] private Transform[] spawnPoints;
    
    //********* 변수 선언 *********//
    private const float gameTime = 30f;
    private const float countdownTime = 3f;
    private float currentTime;
    private float currentgameTime;
    private bool isOnUI = false;
    private bool isgameStart = false;
    private int Scnum;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = countdownTime;
        currentgameTime = gameTime;
        _buttons[0].onClick.AddListener(OnStart);
        _buttons[1].onClick.AddListener(OnExit);
        _buttons[2].onClick.AddListener(OnExitSc);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnUI)
        {
            CountDown();
        }

        if (isgameStart)
        {
            GameTimeCountDown();
        }
    }
    
    //********* 카운트 다운 후 게임 시작 *********//
    IEnumerator OnStartGame()
    {
        while (currentgameTime >= 0)
        {
            Instantiate(discus, spawnPoints[Random.Range(0, spawnPoints.Length)].position, spawnPoints[Random.Range(0, spawnPoints.Length)].rotation);
            yield return new WaitForSeconds(3f);
        }
    }
    
    //********* UI 갱신 함수 *********//
    public void SetSc(int num)
    {
        Scnum += num;
        sc.text = Scnum + "점";
    }
    
    //********* 카운트 다운 *********//
    void CountDown()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = $"{currentTime:N1}";
        }
        else
        {
            canvas[1].SetActive(false);
            canvas[2].SetActive(true);
            isOnUI = false;
            isgameStart = true;
            StartCoroutine(OnStartGame());
        }
    }

    void GameTimeCountDown()
    {
        if (currentgameTime > 0)
        {
            currentgameTime -= Time.deltaTime;
            countdownText_2.text = $"{currentgameTime:N1}";
        }
        else
        {
            isgameStart = false;
            panel.color = new Color(255, 0, 255, 0.5f);
        }
    }
    
    //********* 버튼 이벤트 *********//
    void OnStart()
    {
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
        isOnUI = true;
        currentTime = countdownTime;
        panel.color = new Color(0, 0, 0, 0.5f);
    }

    void OnExit()
    {
        canvas[0].SetActive(false);
    }

    void OnExitSc()
    {
        canvas[2].SetActive(false);
        Scnum = 0;
        currentgameTime = gameTime;
    }
}
