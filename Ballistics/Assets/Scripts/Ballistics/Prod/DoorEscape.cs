using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEscape : MonoBehaviour
{
    public Transform player;
    public string WinSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(WinSceneName);
        }
    }
}