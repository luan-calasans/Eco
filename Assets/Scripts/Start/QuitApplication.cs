using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitApplication : MonoBehaviour
{
    public void QuitGame()
    {
    #if UNITY_EDITOR
            EditorApplication.isPlaying = false; 
            Debug.Log("Fechando o modo de execução no Editor.");

    #elif UNITY_WEBGL
            Application.ExternalCall("alert", "Feche esta aba para sair");
    #else
            Application.Quit();
    #endif
    }
}
