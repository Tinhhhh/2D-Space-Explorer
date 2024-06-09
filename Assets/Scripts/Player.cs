using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnablePlayerAfterDelay(GameObject player, float delay)
    {
        StartCoroutine(EnableAfterDelay(player, delay));
    }

    private IEnumerator EnableAfterDelay(GameObject player, float delay)
    {
        yield return new WaitForSeconds(delay);
        player.SetActive(true);
    }
}
