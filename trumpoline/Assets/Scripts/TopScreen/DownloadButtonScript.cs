﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadButtonScript : MonoBehaviour {

    public GameObject InputFieldObj;
    public string URL { get; private set; }

    InputField inputField;
    WWW www;
    
	// Use this for initialization
	void Start () {
        this.inputField = InputFieldObj.GetComponent<InputField>();
        
        // これは失敗する気がする
        if (www != null && www.isDone)
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        this.URL = this.inputField.text;

        www = new WWW(this.URL);
    }
}
