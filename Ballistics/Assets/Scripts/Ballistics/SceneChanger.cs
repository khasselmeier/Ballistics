using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SwitchToDevScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void SwitchToProdScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 2;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void SwitchToMenuSceneFromLose()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 3;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void SwitchToMenuSceneFromWin()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 4;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
