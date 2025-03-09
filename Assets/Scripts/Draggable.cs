using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    [HideInInspector] public bool canDrag = false;
    [SerializeField] private BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrag)
        {
          //  PlayerInteract.Instance.isSelecting = true;
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void OnMouseDrag()
    {
        //transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
       DragToPlot();
      //  PlayerInteract.Instance.isSelecting = false;
    }
    public void DragToPlot()
    {
        boxCollider.enabled = false; //avoid box collider and overlappoint conflict
        Collider2D collider = Physics2D.OverlapPoint(transform.position);
        boxCollider.enabled = true;
        if (collider != null && collider.TryGetComponent(out Droppable drop))
        {
            drop.OnDrop(this.transform);
        }
        else
        {

        }
        Destroy(gameObject);
        canDrag = false;
    }
}
