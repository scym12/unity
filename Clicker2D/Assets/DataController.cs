using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

    private static DataController instance; 

    public static DataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();
            if(instance == null)
            {
                GameObject container = new GameObject("DataController");
                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }

    private ItemBtn[] itemButtons; 

    private int m_gold = 0;
    private int m_goldPerClick = 0;

    private void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold");
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick",1);

        itemButtons = FindObjectsOfType<ItemBtn>();
    }

    private void setGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void addGold(int newGold)
    {
        m_gold += newGold;
        setGold(m_gold);
    }

    public void subGold(int newGold)
    {
        m_gold -= newGold;
        setGold(m_gold);
    }

    public int getGold()
    {
        return m_gold;
    }

    public int getGoldPerClick()
    {
        return m_goldPerClick;
    }

    private void setGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void addGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        setGoldPerClick(m_goldPerClick);
    }


    public void LoadUpgradeButton(UpgradeButton upgradebutton)
    {
        string key = upgradebutton.upgradeName;
        upgradebutton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradebutton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade",
            upgradebutton.startGoldByUpgrade);
        upgradebutton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradebutton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradebutton)
    {
        string key = upgradebutton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradebutton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradebutton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradebutton.currentCost);

    }

    public void LoadItemButton(ItemBtn itemButton)
    {
        string key = itemButton.itemName;
        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");

        if(PlayerPrefs.GetInt(key +"_isPurchased") == 1)
        {
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
    }

    public void SaveItemButton(ItemBtn itemButton)
    {
        string key = itemButton.itemName;
        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if (itemButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for(int i=0;i<itemButtons.Length;i++)
        {
            goldPerSec += itemButtons[i].goldPerSec;
        }

        return goldPerSec;
    }
}
