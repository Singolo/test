using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnBomb : MonoBehaviour {

    public GameObject bomb;
    public GameObject plane;
    public Text bombCounterText;
    public Text scoresText;
    public int BombCount;
    
    void Start ()
    {
        SetBombCount();
    }
	void FixedUpdate ()
    {
        Spawn();
        if (BombCount == 0)
            Invoke("CountScores", 2.0f);
    } 
    private void Spawn()
    {
        if (Input.GetMouseButtonDown(0) && BombCount > 0)
        {
            var pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            Instantiate(bomb, pos.origin, Quaternion.identity);
            BombCount--;
            SetBombCount();
        }
    }
    private void SetBombCount()
    {
        bombCounterText.text = "Bombs remaning: " + BombCount.ToString();
    }
    private void CountScores()
    {
        Rigidbody2D rb = plane.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        Invoke("SetScores", 3.0f);

    }
    private void SetScores()
    {
        float scores = plane.transform.position.y * 350.0f;
        scoresText.text = "You earned : " + scores.ToString() + " scores.";
    }
}
