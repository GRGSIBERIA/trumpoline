using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadButtonScript : MonoBehaviour {

    public GameObject InputFieldObj;
    public string URL { get; private set; }

    InputField inputField;
    
	// Use this for initialization
	void Start () {
        this.inputField = InputFieldObj.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        this.URL = this.inputField.text;
    }
}
