using UnityEngine;
using TMPro;

public class EscapedTrashCounter : MonoBehaviour
{
    public TMP_Text escapedText; 
    private int escapedTrash = 0; 

    void Start()
    {
        UpdateUI();
    }

    public void IncrementEscapedTrash()
    {
        escapedTrash++; 
        UpdateUI();  
    }

    private void UpdateUI()
    {
        escapedText.text = "Lixo Escapado: " + escapedTrash;
    }
}
