using UnityEngine;

public class Placeable : MonoBehaviour
{
    public TypeOfCrop type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlantSeed(Transform parent)
    {
        GameObject gO = Instantiation.Instance.InstantiatePrefab(type);
        gO.transform.parent = parent;
        gO.transform.localPosition = Vector2.zero;
        if (gO.TryGetComponent(out CropStateManager CropStateManager))
        {
            CropStateManager.type = type;
        }
    }
}
