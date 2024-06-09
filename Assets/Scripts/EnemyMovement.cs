using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f; // Khoảng cách di chuyển qua lại
    [SerializeField] private float moveSpeed = 2f; // Tốc độ di chuyển

    private Vector2 startPosition; // Vị trí bắt đầu của enemy
    private bool movingRight = true; // Biến kiểm tra hướng di chuyển

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // Lưu vị trí ban đầu của enemy
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Di chuyển qua phải

            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false; // Đổi hướng di chuyển
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Di chuyển qua trái

            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Đổi hướng di chuyển
            }
        }
    }
}
