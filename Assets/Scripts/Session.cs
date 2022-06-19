using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Session : MonoBehaviour
{

    int score = 0;
    [SerializeField] int scoreSpeed = 100;

    [SerializeField] int score_check = 0;

    [SerializeField] int killpoint = 0;

    // [SerializeField] GameObject character;

    // [SerializeField] GameObject backGround;
    // [SerializeField] GameObject tree;

    [SerializeField] GameObject enemyController;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject enemySpawner_floor;

    [SerializeField] GameObject countDown;

    [SerializeField] bool stop = true;

    [SerializeField] AudioClip count1;

    [SerializeField] AudioClip count2;

    [SerializeField] [Range(0, 1)] float soundVolume = 0.3f;



    private void Awake()
    {
        SetUpSingleton();

    }


    private void SetUpSingleton()
    {

        if ((FindObjectsOfType(GetType()).Length > 1))
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }



    }

    private IEnumerator Start()
    {
        enemySpawner.GetComponent<EnemySpawner>().Stop();
        enemySpawner_floor.GetComponent<EnemySpawner_Floor>().Stop();
        // character.GetComponent<Player>().Stop();
        AudioSource.PlayClipAtPoint(count1, Camera.main.transform.position, soundVolume);

        yield return new WaitForSeconds(1);

        countDown.GetComponent<Text>().text = "2";
        AudioSource.PlayClipAtPoint(count1, Camera.main.transform.position, soundVolume);

        yield return new WaitForSeconds(1);

        countDown.GetComponent<Text>().text = "1";
        AudioSource.PlayClipAtPoint(count1, Camera.main.transform.position, soundVolume);

        yield return new WaitForSeconds(1);

        enemySpawner.GetComponent<EnemySpawner>().ReStart();
        enemySpawner_floor.GetComponent<EnemySpawner_Floor>().ReStart();
        // character.GetComponent<Player>().ReStart();
        ReStart();
        AudioSource.PlayClipAtPoint(count2, Camera.main.transform.position, soundVolume * 3);
        countDown.GetComponent<Text>().text = "GO";

        yield return new WaitForSeconds(0.5f);

        countDown.GetComponent<Text>().text = "";


    }

    void FixedUpdate()
    {

        if (stop == true)
        {
            return;
        }
        // score++;
        // score += (int)(Time.deltaTime * scoreSpeed);
        score_check += (int)(Time.deltaTime * scoreSpeed);
        if (score_check >= 500)
        {
            score_check -= 500;
            SpeedUp();
        }

    }

    void SpeedUp()
    {
        scoreSpeed++;
        // backGround.GetComponent<BackGroundScroller>().SpeedUp();
        // tree.GetComponent<BackGroundScroller>().SpeedUp();
        enemyController.GetComponent<EnemyController>().SpeedUp();
        enemySpawner.GetComponent<EnemySpawner>().SpeedUp();
        enemySpawner_floor.GetComponent<EnemySpawner_Floor>().SpeedUp();
    }


    public int GetScore()
    {

        return score;
    }

    public int getKillPoint()
    {
        return killpoint;
    }


    public void AddScore(int value)
    {

        score += value;
        score_check += value;
        killpoint++;
    }

    public void Reset()
    {

        Destroy(gameObject);
    }

    public void Stop()
    {
        stop = true;
    }

    public void ReStart()
    {
        stop = false;
    }

    public bool ReturnStop()
    {
        return stop;
    }


}
