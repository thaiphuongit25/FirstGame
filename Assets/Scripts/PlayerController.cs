using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
  public float speed = 5f;
  public float jumpSpeed = 8f;
  private float movement = 0f;
  private Rigidbody2D rigidBody;
  
  public Transform groundCheckPoint;
  public float groundCheckRadius;
  public LayerMask groundLayer;

  // public LayerMask ballLayer;
  private bool isTouchingGround;
  private int score = 0;

  // private bool isTouchingBall;

  // private int score = 0;
  public Text coinText;
  public Text endGame;
  public Text ready;
  public Button back;


  public Vector3 respawnPoint;



  public LevelManager gameLevelManager;
  // private Animator playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
       rigidBody = GetComponent<Rigidbody2D> ();
       coinText.text = "Coins: " + score;

       respawnPoint = transform.position;

       gameLevelManager = FindObjectOfType<LevelManager> ();
       ready.text = "Running";
       Button btn = back.GetComponent<Button>();
		   btn.onClick.AddListener(TaskOnClick);
       //btn.SetActive(false);
       back.interactable = false;
    }

    void TaskOnClick(){
		    gameLevelManager.Respawn();
	  }

    // Update is called once per frame
    void Update()
    {
        // isTouchingGround = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, groundLayer);
        isTouchingGround = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis ("Horizontal");

        // isTouchingBall =  Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, ballLayer);
        // if (isTouchingBall) {
        //    score += 5;
        //    Debug.Log(score);
        // }
  
        rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
        // if (movement > 0f) {
        //   rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
        // }
        // else if (movement < 0f) {
        //   rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
        // } 
        // else {
        //   rigidBody.velocity = new Vector2 (0,rigidBody.velocity.y);
        // }
       

        if (Input.GetButtonDown ("Jump") && isTouchingGround) {
          rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
        }

        // if (Input.GetButtonDown ("Fire1")) {
        //   rigidBody.velocity = new Vector2(rigidBody.velocity.x, -jumpSpeed / 2);
        // }
        if (Input.GetKeyDown("down")) {
          rigidBody.velocity = new Vector2(rigidBody.velocity.x, -jumpSpeed / 2);
        }
        // keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        // playerAnimation.SetFloat ("Speed", Mathf.Abs (rigidBody.velocity.x));
        // playerAnimation.SetBool ("OnGround", isTouchingGround);
    }

     void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "FallDetector") {
          Debug.Log("roi xuong roi");
          endGame.text = "Game over";

         // transform.position = respawnPoint;

          gameLevelManager.Respawn();
        }
        if (other.tag == "CoinScore") {
          Debug.Log("Eat coin");
          score += 5;
          Destroy(other.gameObject);
          coinText.text = "Score: " + score;
          Debug.Log(score);
        }

        if (other.tag == "bomb") {
          Destroy(other.gameObject);
          endGame.text = "Game over";
          ready.text = "Press enter or space to back game";
          // back.SetActive(true);
          back.interactable = true;
          gameLevelManager.StopHere();
        }

        // if (other.tag == "Coin") {
        //   Debug.Log("va cham coin");
        //   Destroy(other.gameObject);
        //   score += 5;
        //   Debug.Log(score);
        //   coinText.text = "Score: " + score;
        // }
    }
}


// btvn: khi player va cham vao bom thi -> bien mat bom va hien thi gameover -> dừng game