using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadLVL : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Reload);

    }
	void Update () {
    }
    private void Reload()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.name);
    }
    
}
