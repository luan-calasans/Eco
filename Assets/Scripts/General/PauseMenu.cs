using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private List<TrashMovement> allTrash;

    void Start()
    {
        FindAllTrash();
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        FindAllTrash();
        SetTrashSortingOrder(0);
    }


    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        SetTrashSortingOrder(2);
    }

    private void FindAllTrash()
    {
        allTrash = new List<TrashMovement>(FindObjectsOfType<TrashMovement>());
    }

    private void SetTrashSortingOrder(int sortingOrder)
    {
        foreach (var trash in allTrash)
        {
            SpriteRenderer renderer = trash.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.sortingOrder = sortingOrder;
            }
        }
    }
}
