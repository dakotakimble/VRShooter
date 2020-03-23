using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int _score;
    public TextMeshPro _tmp;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        _tmp.text = ("Score:" + _score);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

   public void AddScore(int _points)
    {
        _score += _points;        
    }
}
