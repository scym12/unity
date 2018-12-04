using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public DataController datacontroller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        goldDisplayer.text = "Gold:" + datacontroller.getGold();
        goldPerClickDisplayer.text = "Gold Per Click:" + datacontroller.getGoldPerClick();
	}
}
