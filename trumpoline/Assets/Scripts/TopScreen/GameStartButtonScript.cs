using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{
    public GameObject masterObj;
    GameMaster master;

    // Use this for initialization
    void Start()
    {
        this.master = masterObj.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        this.master.LoadMIDIManager();

        SceneManager.LoadScene("GameScreen");
    }
}
