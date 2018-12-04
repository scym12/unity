using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBtn : MonoBehaviour {
    //public int gold = 0;
    //public int goldPerClick = 1;

    //public DataController dataController;

    public void OnClick()
    {
        // gold += goldPerClick;
        int goldPerClick = DataController.GetInstance().getGoldPerClick();
        DataController.GetInstance().addGold(goldPerClick);
    }
}
