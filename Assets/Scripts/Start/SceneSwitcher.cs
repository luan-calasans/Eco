using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;

    public TMP_Text buttonText;

    public void SwitchScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("O nome da cena não foi definido!");
        }
    }
}

