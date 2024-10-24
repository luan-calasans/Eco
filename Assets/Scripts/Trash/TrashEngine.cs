using UnityEngine;
using TMPro;

public class TrashEngine : MonoBehaviour
{
    public TMP_Text scoreText; 
    private int score = 0;
    public float speed = 10f;  

    public void OnEnable()
    {
        UpdateUI();
    }

    public void Update()
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

    private void UpdateUI()
    {
        scoreText.text = "Pontuação: " + score;  
    }

    public void IncreaseScore()
    {
        score++; 
        UpdateUI();
    }
}
