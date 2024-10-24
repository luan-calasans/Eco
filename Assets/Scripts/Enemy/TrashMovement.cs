using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float bottomLimit = -5f;
    public TrashEngine trashEngine;  
    public EscapedTrashCounter escapedTrashCounter;  

    void Start()
    {
        trashEngine = FindObjectOfType<TrashEngine>();
        escapedTrashCounter = FindObjectOfType<EscapedTrashCounter>(); 
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < bottomLimit)
        {
            trashEngine.TrashMissed(); 
            escapedTrashCounter.IncrementEscapedTrash(); 
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            CollectTrash(); 
        }
    }

    private void CollectTrash()
    {
        trashEngine.IncreaseScore();
        Destroy(gameObject); 
    }
}
