using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher1 : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Menu 3D");
    }

}