using UnityEngine;
using TMPro;

public class TrashEngine : MonoBehaviour
{
    public TMP_Text scoreText;  
    public GameObject gameOverPanel; 
    private int score = 0;  
    private int lostTrashCount = 0; 
    private const int maxLostTrash = 10;  
    public float speed = 10f;

    void OnEnable()
    {
        UpdateUI();
        gameOverPanel.SetActive(false); 
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetButton("Horizontal"))
        {
            MoveHorizontally(Input.GetAxis("Horizontal"));
        }
    }

    public void MoveHorizontally(float x)
    {
        var horizontal = Time.deltaTime * x * speed;
        transform.Translate(new Vector3(horizontal, 0));
    }

    public void IncreaseScore()
    {
        score++; 
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Pontuação: " + score; 
    }

    public void TrashMissed()
    {
        lostTrashCount++; 
        if (lostTrashCount >= maxLostTrash)
        {
            GameOver(); 
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0; 
        gameOverPanel.SetActive(true); 
        SetTrashSortingOrder(0); 
    }

    private void SetTrashSortingOrder(int sortingOrder)
    {
        TrashMovement[] allTrash = FindObjectsOfType<TrashMovement>();
        foreach (TrashMovement trash in allTrash)
        {
            SpriteRenderer renderer = trash.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.sortingOrder = sortingOrder; 
            }
        }
    }
}
