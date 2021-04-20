using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int score = 10;
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 10f;

    private bool isDamaged = false;
    private GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            if (isDamaged) return;
            isDamaged = true;
            StartCoroutine(Damaged());
            if(hp <= 0)
            {
                gameManager.AddScore(score);
                Destroy(gameObject);
            }
        }        
    }

    private IEnumerator Damaged()
    {
        hp--;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
    }
}
