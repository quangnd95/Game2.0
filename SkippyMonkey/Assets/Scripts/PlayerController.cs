using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour {
    private static float SCREEN_HALF_WIDTH = 320f;

    public float playerRunSpeed;
    public float playerJumpSpeed;

    private Animator anim;

    private Controller2D controller2D;
    private Vector2 velocity;
    private PlayerStatus playerStatus;

    public static Text score;

    private void Start()
    {
        BananaController.count = 0;
        velocity = new Vector2(playerRunSpeed, 0);
        controller2D = GetComponent<Controller2D>();
        LeanTouch.OnFingerTap += Jump;
    }

    private void OnDestroy()
    {
        LeanTouch.OnFingerTap -= Jump;
    }

    private void Update()
    {
        //CheckCollider();
    }

    private void FixedUpdate()
    {
        if (transform.position.x > SCREEN_HALF_WIDTH)
        {
            transform.position = transform.position.WithX(
                transform.position.x - 2 * SCREEN_HALF_WIDTH
            );
        }
        velocity = new Vector2(
            playerRunSpeed,
            velocity.y + Physics2D.gravity.y * Time.fixedDeltaTime
        );

        playerStatus = controller2D.Move(velocity * Time.fixedDeltaTime);
        transform.position += (Vector3)playerStatus.velocity;

        CheckCollider();
    }

    private void Jump(LeanFinger finger)
    {
        velocity = velocity.WithY(playerJumpSpeed);
        //anim.SetBool("IsGrounded", false);
    }

    private void CheckCollider()
    {
        if (playerStatus.isCollidingBottom == true)
        {
         //   Debug.Log("Cham dat");
            playerStatus.isCollidingBottom = false;
        }
        if(playerStatus.isCollidingTop == true)
        {
            Debug.Log("Cham dau");
            PlayerPrefs.SetInt("diem", BananaController.count);
            
            TKSceneManager.ChangeScene("DIE");
        }
        if(playerStatus.isCollidingRight == true)
        {
            Debug.Log("Cham ben phai");
            PlayerPrefs.SetInt("diem", BananaController.count);
            TKSceneManager.ChangeScene("DIE");
        }
        if (playerStatus.isCollidingLeft == true)
        {
            Debug.Log("Cham ben trai");
            PlayerPrefs.SetInt("diem", BananaController.count);
            TKSceneManager.ChangeScene("DIE");
        }
    }
}
