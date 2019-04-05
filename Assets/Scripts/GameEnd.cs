using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour {
    public bool gameEnd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "MaleZombie" || col.gameObject.tag == "FemaleZombie")
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 0;
            gameEnd = true;
        }
    }
}
