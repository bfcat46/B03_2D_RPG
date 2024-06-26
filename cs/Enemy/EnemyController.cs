using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f; // 적의 이동 속도
    public float changeDirectionTime = 2.0f; // 방향을 바꾸는 시간 간격
    public float chaseRange = 5.0f; // 플레이어를 추적하기 시작하는 범위 (5 타일)
    public float moveDuration = 2.0f; // 움직이는 시간
    public float stopDuration = 2.0f; // 멈추는 시간

    private Rigidbody2D rb;
    private Vector2 movement;
    private float timeSinceLastChange = 0f;
    private float moveTimer = 0f;
    private float stopTimer = 0f;
    private bool isMoving = true;
    private Transform player;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player object not found. Ensure the player has the 'Player' tag.");
        }

        ChangeDirection(); // 초기 방향 설정
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceToPlayer <= chaseRange)
            {
                // 플레이어를 추적
                Vector3 direction = (player.position - transform.position).normalized;
                movement = GetAxisAlignedDirection(direction);
                animator.SetBool("isMoving", true);
            }
            else
            {
                // 임의의 방향으로 이동
                timeSinceLastChange += Time.deltaTime;

                if (isMoving)
                {
                    moveTimer += Time.deltaTime;
                    if (moveTimer >= moveDuration)
                    {
                        isMoving = false;
                        moveTimer = 0f;
                        animator.SetBool("isMoving", false);
                    }
                }
                else
                {
                    stopTimer += Time.deltaTime;
                    if (stopTimer >= stopDuration)
                    {
                        isMoving = true;
                        stopTimer = 0f;
                        ChangeDirection();
                        timeSinceLastChange = 0f;
                        animator.SetBool("isMoving", true);
                    }
                }

                if (isMoving && timeSinceLastChange >= changeDirectionTime)
                {
                    ChangeDirection();
                    timeSinceLastChange = 0f;
                }
            }
        }
        else
        {
            // 플레이어가 없을 경우 임의의 방향으로 이동
            timeSinceLastChange += Time.deltaTime;

            if (isMoving)
            {
                moveTimer += Time.deltaTime;
                if (moveTimer >= moveDuration)
                {
                    isMoving = false;
                    moveTimer = 0f;
                    animator.SetBool("isMoving", false);
                }
            }
            else
            {
                stopTimer += Time.deltaTime;
                if (stopTimer >= stopDuration)
                {
                    isMoving = true;
                    stopTimer = 0f;
                    ChangeDirection();
                    timeSinceLastChange = 0f;
                    animator.SetBool("isMoving", true);
                }
            }

            if (isMoving && timeSinceLastChange >= changeDirectionTime)
            {
                ChangeDirection();
                timeSinceLastChange = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            MoveCharacter(movement);
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void ChangeDirection()
    {
        // 임의의 가로 또는 세로 방향으로 변경
        int direction = Random.Range(0, 4); // 0: 위, 1: 아래, 2: 왼쪽, 3: 오른쪽

        switch (direction)
        {
            case 0:
                movement = Vector2.up;
                break;
            case 1:
                movement = Vector2.down;
                break;
            case 2:
                movement = Vector2.left;
                break;
            case 3:
                movement = Vector2.right;
                break;
        }
    }

    Vector2 GetAxisAlignedDirection(Vector3 direction)
    {
        // 가로 또는 세로 방향으로 정렬된 벡터 반환
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return new Vector2(Mathf.Sign(direction.x), 0);
        }
        else
        {
            return new Vector2(0, Mathf.Sign(direction.y));
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        // 사망 처리를 추가합니다.
    }
}
