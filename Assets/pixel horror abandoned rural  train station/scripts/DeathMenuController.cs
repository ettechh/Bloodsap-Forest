using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("MAIN_SCENE");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif  
        Application.Quit();
    }
}
