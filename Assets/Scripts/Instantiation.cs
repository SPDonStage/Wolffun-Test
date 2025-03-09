using UnityEngine;

public class Instantiation : Singleton<Instantiation>
{
    [SerializeField] public GameObject tomato;
    [SerializeField] public GameObject blueberry;
    [SerializeField] public GameObject strawberry;
    [SerializeField] public GameObject cow;
    [SerializeField] public GameObject worker;

    [SerializeField] public GameObject tomatoPlant;
    [SerializeField] public GameObject blueberryPlant;
    [SerializeField] public GameObject strawberryPlant;
    [SerializeField] public GameObject cowPlant;
    public GameObject InstantiatePrefab(TypeOfCrop type)
    {
        if (type == TypeOfCrop.Tomato)
        {
            return Instantiate(tomato);
        } 
        if (type == TypeOfCrop.Blueberry)
        {
            return Instantiate(blueberry);
        }
        if (type == TypeOfCrop.Strawberry)
        {
            return Instantiate(strawberry);
        }    
        if (type == TypeOfCrop.Cow)
        {
            return Instantiate(cow);
        }
        return null;
    }
    public GameObject InstantiateWorker(ShopButton.TypeOfShop type)
    {
        return Instantiate(worker, new Vector2(5,-5), Quaternion.identity);
    }
}
