using UnityEngine;

public class StashManager : MonoBehaviour
{
    public static StashManager instance;
    [SerializeField] private CropButton tomatoCropBtn;
    [SerializeField] private CropButton blueberryCropBtn;
    [SerializeField] private CropButton strawberryCropBtn;
    [SerializeField] private CropButton cowCropBtn;
    public int tomatoCount;
    public int blueberryCount;
    public int strawberryCount;
    public int cowCount;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tomatoCount = PlayerDataManager.Instance.tomatoOwn;
        blueberryCount = PlayerDataManager.Instance.blueberryOwn;
        strawberryCount = PlayerDataManager.Instance.strawberryOwn;
        cowCount = PlayerDataManager.Instance.cowOwn;
    }

    // Update is called once per frame
    void Update()
    {
        if (tomatoCropBtn)
            tomatoCropBtn.count = tomatoCount;
        if (blueberryCropBtn)
            blueberryCropBtn.count = blueberryCount;
        if (strawberryCropBtn)
            strawberryCropBtn.count = strawberryCount;
        if (cowCropBtn)
            cowCropBtn.count = cowCount;
    }
}
