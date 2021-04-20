using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text lifeText = null;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private GameObject enemyCroissant;

    public Vector2 minPosition { get; private set; }
    public Vector2 maxPosition { get; private set; }

    private int score = 0;

    void Start()
    {
        minPosition = new Vector2(-7f, -12f);
        maxPosition = new Vector2(7f, 12f);
        StartCoroutine(SpawnCroissant());
    }

    public void Dead()
    {
        life--;
        if(life <= 0)
        {
            // 게임오버 씬 불러오기
            SceneManager.LoadScene("GameOver");
        }
        lifeText.text = string.Format("LIFE\n{0}", life);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = string.Format("SCORE\n{0}", score);
    }

    private IEnumerator SpawnCroissant()
    {
        float randomX = 0f;
        float randomDelay = 0f;

        while (true) 
        {
            randomX = Random.Range(-7f, 7f);
            randomDelay = Random.Range(1f, 5f);
            for(int i = 0; i < 5; i++)
            {
                Instantiate(enemyCroissant, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(randomDelay);
        }        
    }
}
