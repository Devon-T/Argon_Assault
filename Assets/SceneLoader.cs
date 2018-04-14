using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("playFirstLevel", 2.5f);
    }

    public void playFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
