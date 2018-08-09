using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc4_UpgradesMenu : MonoBehaviour{
    
    public float money;
    public Sc4_Item[] items;
    public int ammo = 3;
    public float slowDownMoveSpeed = 1f;

    private void Start()
    {
        for(int i = 0; i < items.Length; i++)
        {
            Sc4_Item item = items[i];
            item.button.GetComponentInChildren<Text>().text = item.name + " " + item.numFactorIncrease.ToString() + " - $" + item.cost;
        }
    }

    private void Update()
    {

    }

    public void OnButtonAmmo()
    {
        ammo = (int)Purchase(items[0]);
    }
    public void OnSlowDownTime()
    {
        slowDownMoveSpeed = Purchase(items[1]);
    }
    public void OnMoneyGained()
    {
    }
    public void OnButtonLaunchRotation()
    {
    }

    private float Purchase(Sc4_Item item)
    {
        if ((money - item.cost) >= 0)
        {
            money -= item.cost;
            item.num += item.numFactorIncrease;
            item.numFactorIncrease += item.numFactorFactorIncrease;
            item.cost += item.costFactorIncrease;
            item.button.GetComponentInChildren<Text>().text = item.name + " " + item.numFactorIncrease.ToString() + item.unit + " - $" + item.cost;  
        }
        return item.num;
    }
        

    [System.Serializable]
    public class Sc4_Item{
        public string name;
        public float num;
        public string unit;
        public float numFactorIncrease;
        public float numFactorFactorIncrease;
        public float cost;
        public float costFactorIncrease;
        public RectTransform button;
    }

    

}
