using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Video");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Menu 3D");
    }

}