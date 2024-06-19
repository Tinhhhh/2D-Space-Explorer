using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private float DelayTime;
    private UIManager uiManager;
    private CameraMove cameraMove;
    private PlayerMovement playerMovement;
    void Start()
    {
        cameraMove = Camera.main.GetComponent<CameraMove>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        uiManager = UIManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiManager.WinTitle.SetActive(true);
            playerMovement.canMove = false;
            StartCoroutine(ActivateAfterDelay(DelayTime));
            pauseButton.SetActive(false);
            StartCoroutine(DisablePlayer(5f));
        }

    }

    private IEnumerator ActivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        cameraMove.isMoving = false;
        uiManager.Restart.SetActive(true);
        uiManager.Exit.SetActive(true);
        uiManager.MainMenu.SetActive(true);
    }

    private IEnumerator DisablePlayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        uiManager.Player.SetActive(false);
    }

}
