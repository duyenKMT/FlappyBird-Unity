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

    private int score;
    public Text scoreText;

    private void Awake()
    {
        SoundController.instance.PlayThisSound("GameMusic", 0.2f);
        rigibody =this.gameObject.GetComponent <Rigidbody2D>();
        levelStart = false;
        rigibody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
    }
   
    // Update is called once per frame
    void Update()
    {
        //Kiểm tra Space có bấm không
        if (Input.GetKeyDown(KeyCode.Space))
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
    }
    //Hàm làm cho chim bay lên 1 khoảng
    private void BirdMoveUp()
    {
        rigibody.velocity = Vector2.up * jumpForce;
    }

// Xử lý va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("hit", 0.5f); ///Lôiix
        ReloadScene();
        score = 0;
        scoreText.text = score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collection)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {

        SceneManager.LoadScene("GamePlay");
    }
}
