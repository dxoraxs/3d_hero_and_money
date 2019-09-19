using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneWithName(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
