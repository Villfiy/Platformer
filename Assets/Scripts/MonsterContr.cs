using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float chaseRadius = 5f;
    public float returnRadius = 7f;
    private Vector3 initialPosition;
    private bool isChasing = false;
    private bool isReturning = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRadius)
        {
            isChasing = true;
            isReturning = false;
            FlipIfNeeded(player.position.x - transform.position.x);
            ChasePlayer();
        }
        else if (distanceToPlayer > returnRadius)
        {
            isChasing = false;
            isReturning = true;
            FlipIfNeeded(initialPosition.x - transform.position.x);
            ReturnToInitialPosition();
        }

        // ���������� ���������� ��� �������� ����
        animator.SetBool("isRunning", isChasing || isReturning); // �������� �������� ���� ��� ����������� ��� �������������
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * 2f); // �������� �����������
    }

    void ReturnToInitialPosition()
    {
        Vector3 direction = (initialPosition - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * 2f); // �������� �����������

        // ��������, ����� �� ������ ���� ��������� �������
        if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
        {
            transform.position = initialPosition;
            isReturning = false; // ��������� ��������� �����������
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ����������� � �������, ��������� �������� ����
        if (collision.gameObject.CompareTag("Player"))
        {
            isChasing = false;
            isReturning = false;
            animator.SetBool("isRunning", false);
        }
    }
    void FlipIfNeeded(float horizontalMovement)
    {
        if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = true; // �������, ���� ��������� ������
        }
        else if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = false; // �� �������, ���� ��������� �����
        }
    }
}
