using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f; // ���� �̵� �ӵ�
    public float changeDirectionTime = 2.0f; // ������ �ٲٴ� �ð� ����
    public float chaseRange = 5.0f; // �÷��̾ �����ϱ� �����ϴ� ���� (5 Ÿ��)
    public float moveDuration = 2.0f; // �����̴� �ð�
    public float stopDuration = 2.0f; // ���ߴ� �ð�

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

        ChangeDirection(); // �ʱ� ���� ����
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceToPlayer <= chaseRange)
            {
                // �÷��̾ ����
                Vector3 direction = (player.position - transform.position).normalized;
                movement = GetAxisAlignedDirection(direction);
                animator.SetBool("isMoving", true);
            }
            else
            {
                // ������ �������� �̵�
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
            // �÷��̾ ���� ��� ������ �������� �̵�
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
        // ������ ���� �Ǵ� ���� �������� ����
        int direction = Random.Range(0, 4); // 0: ��, 1: �Ʒ�, 2: ����, 3: ������

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
        // ���� �Ǵ� ���� �������� ���ĵ� ���� ��ȯ
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
        // ��� ó���� �߰��մϴ�.
    }
}
