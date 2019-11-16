using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

}