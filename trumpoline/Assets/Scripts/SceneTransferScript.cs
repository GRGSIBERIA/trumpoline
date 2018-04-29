using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class SceneTransferScript : MonoBehaviour {
    [SerializeField]
    UnityEngine.Events.UnityEvent onAwake;

    void Awake()
    {
        this.onAwake.Invoke();
    }

}
