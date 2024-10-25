using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int targetScore = 20;
    public GameObject scorePanel;
    public TextMeshProUGUI scoreText; 
    public Sprite newBackground;
    public GameObject backgroundObject; 
    public TrashEngine trashEngine;

    private bool isPaused = false;

    void Update()
    {
        int currentScore = trashEngine.GetScore();
        Debug.Log("Pontua��o atual: " + currentScore);

        if (currentScore > targetScore && !isPaused)
        {
            Debug.Log("A pontua��o ultrapassou o valor alvo de " + targetScore);
            ShowScorePanel();
            ChangeBackground(); 
            PauseGame(); 
        }
    }

    void ShowScorePanel()
    {
        Debug.Log("Ativando o painel de pontua��o");  
        scorePanel.SetActive(true);  
        scoreText.text = "Pontua��o: " + trashEngine.GetScore(); 
    }

    void PauseGame()
    {
        Debug.Log("Jogo pausado");  
        Time.timeScale = 0;
        isPaused = true; 
    }

    void ChangeBackground()
    {
        SpriteRenderer backgroundRenderer = backgroundObject.GetComponent<SpriteRenderer>();
        if (backgroundRenderer != null)
        {
            backgroundRenderer.sprite = newBackground; 
        }
        else
        {
            Debug.LogError("SpriteRenderer n�o encontrado no background.");
        }
    }

    public void ContinueGame()
    {
        Debug.Log("Jogo retomado"); 
        Time.timeScale = 1;  
        isPaused = false; 
        scorePanel.SetActive(false);  
    }
}
