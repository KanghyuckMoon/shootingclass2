using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void OnClickRetry()
    {
        SceneManager.LoadScene("Main");
    }
}
