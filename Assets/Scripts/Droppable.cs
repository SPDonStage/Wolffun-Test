using UnityEngine;

public class Droppable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(Transform gO)
    {
        Plot plot = GetComponent<Plot>();
        if (plot.isOwned)
        {
            if (!plot.isUsed)
            {
                gO.parent = transform;
                gO.transform.localPosition = Vector3.zero;
                if (gO.TryGetComponent(out Placeable place))
                {
                    place.PlantSeed(plot.holder);
                    plot.isUsed = true;
                }
            }
        }
        else
        {
            if (TryGetComponent(out Plot _plot))
            {
                _plot.NeedOwnAnim_On();
            }
        }

    }
}
