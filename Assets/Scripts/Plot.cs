using UnityEngine;

public class Plot : MonoBehaviour
{
    public int plotID;
    [SerializeField] public Transform holder;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color ownedColor;
    [SerializeField] private Color notOwnedColor;
 public bool isUsed;
    public bool isOwned = false;
    private void Awake()
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();
        isOwned = false;
        isUsed = false;
        Invoke("SetPlotColor", .1f); //delay set color, use for load game
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (isOwned)
        {
            if (holder.transform.childCount > 0)
            {
                isUsed = true;
            }
            else
            {
                isUsed = false;
            }
        }
    }
    public void BuyPlot()
    {
        isOwned = true;
        spriteRenderer.color = ownedColor;
    }
    public void NeedOwnAnim_On()
    {
        animator.SetBool("needOwn", true);
    }
    public void NeedOwnAnim_Off() //use in anim event
    {
        animator.SetBool("needOwn", false);
    }
    public void SetPlotColor()
    {
        if (!isOwned)
        {
            spriteRenderer.color = notOwnedColor;
        }
        else
        {
            spriteRenderer.color = ownedColor;
        }
    }
}
