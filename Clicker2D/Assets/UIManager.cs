﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    // public DataController datacontroller;


    public Text goldPerSecDisplayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        goldDisplayer.text = "Gold:" + DataController.Instance.gold;
        goldPerClickDisplayer.text = "Gold Per Click:" + DataController.Instance.goldPerClick;
        goldPerSecDisplayer.text = "Gold Per Sec:" + DataController.Instance.GetGoldPerSec();

    }
}
