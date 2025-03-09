using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public int numOfOwnedPlot;
    [SerializeField] public int money;
    [SerializeField] public int upgrade;
    public int tomatoOwn;
    public int blueberryOwn;
    public int strawberryOwn;
    public int cowOwn;
    public int workerOwn;
    public List<CropStateManager> CropStateManagers = new List<CropStateManager>();
    public List<Plot> plantedPlots = new List<Plot>();
    private void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        Load();
    }
    private void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.S))
            Save();
        if (Input.GetKeyDown(KeyCode.D))
            Load();*/
    }
    public void Save()
    {
        CropStateManagers.Clear();
        plantedPlots.Clear();
        for (int i = 0; i < numOfOwnedPlot; i++)
        {
            Plot plot = PlotManager.instance.transform.GetChild(i).GetComponent<Plot>();
            if (plot.isUsed)
            {
                CropStateManagers.Add(plot.holder.GetChild(0).GetComponent<CropStateManager>());
                plantedPlots.Add(plot);
            }
        }
        SaveSystem.Save(this);
    }
    public void Load()
    {
        string[] data = SaveSystem.Load();
        if (data.Length > 0)
        {
            //Owned Plots
            if (int.TryParse(data[1].ToString(), out _))
            {
                numOfOwnedPlot = Convert.ToInt16(data[1]);
            }
            //Money
            money = Convert.ToInt16(data[3]);
            //Upgrade
            upgrade = Convert.ToInt16(data[5]);
            //Worker
            workerOwn = Convert.ToInt16(data[7]);
            for (int i = 0; i < workerOwn; i++)
            {
                Instantiation.Instance.InstantiateWorker(ShopButton.TypeOfShop.Worker);
            }
            //Stash
            tomatoOwn = Convert.ToInt16(data[12]);
            blueberryOwn = Convert.ToInt16(data[13]);
            strawberryOwn = Convert.ToInt16(data[14]);
            cowOwn = Convert.ToInt16(data[15]);
            //Crops
            Transform plotManager = PlotManager.instance.transform;
            for (int i = 21; i  < data.Length - 1; i += 5)
            {
                GameObject gO = Instantiation.Instance.InstantiatePrefab((TypeOfCrop)System.Enum.Parse(typeof(TypeOfCrop), data[i + 1])); //Debug.Log(data[i]);
                gO.transform.parent = plotManager.GetChild(Convert.ToInt16(data[i])).GetComponent<Plot>().holder;
                gO.transform.localPosition = Vector3.zero;
                if (gO.TryGetComponent(out CropStateManager CropStateManager))
                {
                    CropStateManager.type = (TypeOfCrop)System.Enum.Parse(typeof(TypeOfCrop), data[i + 1]);
                    CropStateManager.growingState.currentTime = Convert.ToInt16(data[i + 1 + 1]);
                    CropStateManager.wholeState.numOfCrop = Convert.ToInt16(data[i + 1 + 1 + 1]);
                    CropStateManager.rottenState.currentTime = Convert.ToInt16(data[i + 1 + 1 + 1 + 1]);
                }
            }

        }
       
    }
}
