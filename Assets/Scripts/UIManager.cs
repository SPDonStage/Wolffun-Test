using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI toolUpgradeText;
    [SerializeField] private Button saveBtn;
    private void Awake()
    {
        saveBtn.onClick.AddListener(() =>
        {
            PlayerDataManager.Instance.Save();
        });
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerDataManager.Instance.money.ToString() + "/" + GameManager.instance.moneyToWin;
        toolUpgradeText.text = "+" + PlayerDataManager.Instance.upgrade.ToString() + "%";
    }
}
