using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public enum TypeOfShop
    {
        Tomato,
        Blueberry,
        Strawberry,
        Cow,
        Plot,
        Tool,
        Worker,
    }
    [SerializeField] private TypeOfShop type;
    [SerializeField] private int price;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private int quantity;
    [SerializeField] private CropButton cropButton;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ButtonClick();

        });
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        priceText.text = price.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ButtonClick()
    {
        if (PlayerDataManager.Instance.money >= price) 
        {
            if (type == TypeOfShop.Tomato)
            {
                StashManager.instance.tomatoCount += quantity;
            }
            if (type == TypeOfShop.Blueberry)
            {
                StashManager.instance.blueberryCount += quantity;
            }
            if (type == TypeOfShop.Strawberry)
            {
                StashManager.instance.strawberryCount += quantity;
            }
            if (type == TypeOfShop.Cow)
            {
                StashManager.instance.cowCount += quantity;
            }
            if (type == TypeOfShop.Plot)
            {
                PlayerDataManager.Instance.numOfOwnedPlot += quantity;
                PlotManager.instance.OpenMorePlot();
            }
            if (type == TypeOfShop.Tool)
            {
                PlayerDataManager.Instance.upgrade += quantity;
            }
            if (type == TypeOfShop.Worker)
            {
                Instantiation.Instance.InstantiateWorker(type);
                PlayerDataManager.Instance.workerOwn++;
            }
            PlayerDataManager.Instance.money -= price;
        }
    }
}
