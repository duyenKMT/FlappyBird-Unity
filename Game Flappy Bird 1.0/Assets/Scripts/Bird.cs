using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigibody;
    public float jumpForce;
    private bool levelStart; //trạng thái chơi
    public GameObject gameController;

    public GameObject message;

    private int mang;
    private int score;
    public Text scoreText;
    public Text mangText;

    public GameObject gameOverObj;

    private Animator anim;

    private void Awake()
    {
        
        rigibody =this.gameObject.GetComponent <Rigidbody2D>();
        levelStart = false;
        rigibody.gravityScale = 0;
        score = 0;
        scoreText.text = scoreText.text+score.ToString();
        mang = 3;
        mangText.text = mangText.text+mang.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
    }
    private void Start()
    {
        SoundController.instance.PlayThisSound("GameMusic", 0.2f);
        Time.timeScale = 1;
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetFloat("flyPower",0);
        anim.SetBool("isDead",false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Kiểm tra Space có bấm không
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            SoundController.instance.PlayThisSound("wing", 0.5f);
            if (levelStart == false)
            {
                levelStart = true;
                rigibody.gravityScale = 6;
                gameController.GetComponent<_pipeGenerator>().enabelGeneratePipe = true;
                message.GetComponent<SpriteRenderer>().enabled = false;
                         
            }
            BirdMoveUp();
        }
        anim.SetFloat("flyPower", rigibody.velocity.y);
    }
    //Hàm làm cho chim bay lên 1 khoảng
    private void BirdMoveUp()
    {
        rigibody.velocity = Vector2.up * jumpForce;
    }

// Xử lý va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("hit", 0.5f);
        mang -= 1;
        mangText.text = "x" + mang.ToString();
        if (mang == 0)
        {
            GameOver();
            gameOverObj.SetActive(true);
        }
        /*score = 0;
        scoreText.text = score.ToString();*/

    }

    private void OnTriggerEnter2D(Collider2D collection)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        score += 10;
        scoreText.text = "Core: "+ score.ToString();
    }
    
    public void GameOver()
    {
        anim.SetBool("isDead",true);
        Time.timeScale = 0;

    }

    public void resetGame()
    {
        SceneManager.LoadScene(1);
    }
}
