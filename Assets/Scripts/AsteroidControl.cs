using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float moveSpeed = 2f; // Tốc độ di chuyển của asteroid
    [SerializeField] private float moveDuration = 10f; // Thời gian di chuyển sau khi phát hiện player

    private Transform player; // Transform của player
    private bool isFollowingPlayer = false; // Biến để kiểm tra xem asteroid có đang di chuyển theo player không
    private bool playerDetected = false; // Biến để kiểm tra xem player đã được phát hiện hay chưa
    private Vector2 initialDirection; // Hướng ban đầu mà asteroid phát hiện player
    private float moveTimer = 0f; // Thời gian đã di chuyển theo player

    // Update is called once per frame
    void Update()
    {
        // Nếu asteroid đang di chuyển theo player
        if (isFollowingPlayer)
        {
            // Di chuyển asteroid về phía player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Tăng moveTimer
            moveTimer += Time.deltaTime;

            // Nếu moveTimer vượt quá moveDuration, huỷ bỏ di chuyển theo player
            if (moveTimer >= moveDuration)
            {
                isFollowingPlayer = false;
            }
        }
    }

    // Khi player đi vào phạm vi của asteroid
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !playerDetected)
        {
            player = other.gameObject.transform;
            // Tính toán hướng để di chuyển asteroid theo player
            initialDirection = (player.position - transform.position).normalized;

            // Bắt đầu di chuyển theo player
            isFollowingPlayer = true;

            // Đặt biến playerDetected thành true để chỉ phát hiện player lần đầu tiên
            playerDetected = true;
        }
    }
}
