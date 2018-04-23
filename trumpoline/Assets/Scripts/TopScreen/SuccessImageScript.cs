using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessImageScript : MonoBehaviour {

    public GameObject DLButton;

    DownloadButtonScript dlButton;
    Image image;
    
    Color SetColor(float a)
    {
        var inic = this.image.color;
        inic.a = a;
        return inic;
    }

	// Use this for initialization
	void Start () {
        this.dlButton = this.DLButton.GetComponent<DownloadButtonScript>();
        this.image = this.GetComponent<Image>();

        this.image.color = SetColor(0);
    }
	
	// Update is called once per frame
	void Update () {
		if (dlButton.downloadEnded)
        {
            this.image.color = SetColor(1);
        }
	}
}
