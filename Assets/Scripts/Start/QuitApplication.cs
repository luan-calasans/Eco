using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();

    #if UNITY_EDITOR
        Debug.Log("Jogo encerrado! (Somente dispon�vel no build)");
    #endif
    }
}
