using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float bottomLimit = -5f;
    //public AudioClip collectionSound;
    public TrashEngine trashEngine; 

    void Start()
    {
        trashEngine = FindObjectOfType<TrashEngine>();
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
        //PlayCollectionSound();
        trashEngine.IncreaseScore(); 
        Destroy(gameObject); 
    }

    //private void PlayCollectionSound()
    //{
    //    GameObject soundObject = new GameObject("CollectionSound");
    //    AudioSource audioSource = soundObject.AddComponent<AudioSource>();
    //    audioSource.clip = collectionSound;
    //    audioSource.playOnAwake = false;
    //    audioSource.Play();
    //    Destroy(soundObject, collectionSound.length);
    //}
}
