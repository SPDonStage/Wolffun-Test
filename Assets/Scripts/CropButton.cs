using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropButton : MonoBehaviour
{
    /* public enum TypeOfCrop
     {
         None,
         Tomato,
         Blueberry,
         Cow,

     }
     [SerializeField] private TypeOfCrop type;*/
    [SerializeField] private GameObject cropSample;
    [SerializeField] private TextMeshProUGUI countText;
    private GameObject crop;
    public int count;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ButtonClick();

        });
        crop ??= GetComponent<GameObject>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString();
        if (crop.gameObject != null)
        {
            if (crop.transform.parent != null)
            {
                count--;
            }
        }
    }
    private void ButtonClick()
    {
        if (count > 0)
        {
            crop = Instantiate(cropSample);
            crop.GetComponent<Draggable>().canDrag = true;
        }
    }
}
