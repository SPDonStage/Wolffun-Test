using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform plot;
    [SerializeField] private GameObject crop;
    private bool canWork;
    [SerializeField] private int workremainCD;
    private int remainremainCD;
    private void Awake()
    {
        agent ??= GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        remainremainCD = 0;
        canWork = true;
        plot ??= GetComponent<Transform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canWork) 
        {

            if (crop == null)
            {
                RandomCrop();
            }
            if (remainremainCD == 0)
            {
                if (plot == null || plot.GetComponent<Plot>().isUsed || !plot.GetComponent<Plot>().isOwned)
                {
                    GetPlot();
                }
              //  Debug.Log(plot.name + ":" + Vector2.Distance(transform.position, plot.transform.position));

                if (plot != null)
                {
                    agent.SetDestination((Vector2)plot.position);
                    if (Vector2.Distance(transform.position, plot.transform.position) <= 0.5f)
                    {
                        //   Debug.Log(name);
                        if (!plot.GetComponent<Plot>().isUsed && plot.GetComponent<Plot>().isOwned)
                        {
                            if (crop != null)
                            {
                                crop.GetComponent<Placeable>().PlantSeed(plot.GetComponent<Plot>().holder.transform);
                                plot = null;
                                canWork = false;
                                crop = null;
                                StartCoroutine(WorkCD());
                            }
                        }
                    }
                }
               
               
            }
         
        }
    }
    private void GetPlot()
    {      
        for (int i = 0; i < PlotManager.instance.transform.childCount; i++)
        {
            Plot childPlot = PlotManager.instance.transform.GetChild(i).GetComponent<Plot>();
            if (!childPlot.isUsed && childPlot.isOwned)
            {
                plot = childPlot.transform;
                break;
            }
        }
    }
    IEnumerator WorkCD()
    {
        int remainCD = 0;
        while (remainCD < workremainCD)
        {
            yield return new WaitForSeconds(1);
            remainCD++;
        }
        if (remainCD >= workremainCD)
        {
            remainCD = 0;
            canWork = true;
        }
    }
    void RandomCrop()
    {
        if (crop == null) {
            int random = Random.Range(0, 4); //Debug.Log(random);
            StashManager stash = StashManager.instance;
            Instantiation instance = Instantiation.Instance;
            if (random == 0 && stash.tomatoCount > 0)
            {
                stash.tomatoCount--;
                crop = instance.tomatoPlant;
               
            }
            if (random == 1 && stash.blueberryCount > 0)
            {
                stash.blueberryCount--;
                crop = instance.blueberryPlant;
                
            }
            if (random == 2 && stash.strawberryCount > 0)
            {
                stash.strawberryCount--;
                crop = instance.strawberryPlant;
                
            }
            if (random == 3 && stash.cowCount > 0)
            {
                  stash.cowCount--;
                crop = instance.cowPlant;
              
            }
        } 
    }
}
