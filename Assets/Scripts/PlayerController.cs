using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력

    private int health = 3;

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = yInput * speed;

        float ySpeed = playerRigidbody.linearVelocity.y;

        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, zSpeed);
        playerRigidbody.linearVelocity = newVelocity;

        //if (Input.GetKey(KeyCode.UpArrow) == true)
        //{
        //    // 왼쪽 방향키 입력이 감지된 경우 z 방향 힘 주기
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    // 왼쪽 방향키 입력이 감지된 경우 -z 방향 힘 주기
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    // 왼쪽 방향키 입력이 감지된 경우 x 방향 힘 주기
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    // 왼쪽 방향키 입력이 감지된 경우 -x 방향 힘 주기
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}

        if (Input.GetKey(KeyCode.Space) == true)
        {
            // 스페이스 입력이 감지된 경우
            Die();
        }
    }

    public void Die()
    {
        health -= 1;

        if (health <= 0)
        {
            // 자신의 게임 오브젝트를 비활성화
            gameObject.SetActive(false);
        }
    }

    public void IncreaseHealth(int amt)
    {
        if (amt <= 0) return;

        health += amt;
    }

}
