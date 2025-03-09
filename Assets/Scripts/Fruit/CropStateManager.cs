using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropStateManager : MonoBehaviour
{
    public TypeOfCrop type;
    //GROWING STATE
    [Header("-=-GROWING STATE-=-")]
    [Header("-Progress Change Sprite-")]
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite progress1;
    [SerializeField] public Sprite progress2;
    [SerializeField] public Sprite progress3;
    [SerializeField] public Sprite progress4;
    [SerializeField] public Sprite progress5;
    [SerializeField] public Sprite progress6;
    [SerializeField] public int timeToBeWhole;
    ///
    //WHOLE STATE
    [Header("-=-WHOLE STATE-=-")]

    //ROTTEN STATE
    [Header("-=-ROTTEN STATE-=-")]
    [SerializeField] public Image rottenBar;
    [SerializeField] public int timeToBeRotten;
    //
    [SerializeField] private int harvestMoney;
 //   [HideInInspector] public bool canHarvest;
    [SerializeField] public TextMeshProUGUI cropText;
    [SerializeField] public int maxLifeTime;
    [SerializeField] public float intervalToProduce; //by second, example: 1 min = 60 second
  //  public int numOfCrop;

    public CropBaseState currentState;
    public CropGrowingState growingState = new CropGrowingState();
    public CropWholeState wholeState = new CropWholeState();
    public CropRottenState rottenState = new CropRottenState();
    private void Awake()
    {
        rottenBar.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        SwitchState(growingState);
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        currentState.UpdateState(this);
       // Debug.Log(wholeState.maxRemainCrop);
    }
    private void OnMouseDown()
    {
        Harvest();
    }
    public void Harvest()
    {
        if (wholeState.canHarvest)
        {
            PlayerDataManager.Instance.money += (harvestMoney + (harvestMoney * PlayerDataManager.Instance.upgrade / 100)) * wholeState.numOfCrop;
            wholeState.maxRemainCrop = wholeState.maxRemainCrop - wholeState.numOfCrop;
            wholeState.numOfCrop = 0;
            if (wholeState.numOfCrop >= wholeState.maxRemainCrop)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SwitchState(CropBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void BeRotten()
    {
        Destroy(gameObject);
    }
   
}
