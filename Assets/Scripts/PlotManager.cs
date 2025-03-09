using UnityEngine;

public class PlotManager : MonoBehaviour
{
    private int numOfOwnedPlot;
    private int currentIndex;
    public static PlotManager instance;
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
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform plot = transform.GetChild(i);
            if (plot.CompareTag("Plot"))
            {
               plot.GetComponent<Plot>().plotID = i;
            }
            
        }

        numOfOwnedPlot = PlayerDataManager.Instance.numOfOwnedPlot;
        for (currentIndex = 0; currentIndex < numOfOwnedPlot; currentIndex++)
        {
            Transform plot = transform.GetChild(currentIndex);//Debug.Log(transform.GetChild(currentIndex)); 
            if (plot.CompareTag("Plot"))
            {
                plot.gameObject.GetComponent<Plot>().isOwned = true;
            }
        }
       // Debug.Log(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OpenMorePlot()
    {
        numOfOwnedPlot++;
        transform.GetChild(currentIndex).gameObject.GetComponent<Plot>().BuyPlot();
        if (currentIndex < numOfOwnedPlot)
        {
            currentIndex++;
        }
    }
}
