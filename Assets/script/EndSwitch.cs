using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSwitch : MonoBehaviour
{
    public Timer timer;
    public PointManager pm;
    public GameObject overlay;
    public GameObject end;
    public Text TimerInitial;
    public Text PointerInitial;
    public Text TimerNow;
    public Text PointerNow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.getPoints() >= 60)
        {
            timer.StopTimer();
            TimerNow.text = timer.getTimer().ToString();
            PointerNow.text = pm.getPoints().ToString();
            overlay.SetActive(false);
            end.SetActive(true);
            SceneManager.LoadScene("Menu");
        }
        else if(timer.getTimer() <= 0)
        {
           timer.StopTimer();
            TimerNow.text = "0";
            PointerNow.text = pm.getPoints().ToString();
            overlay.SetActive(false);
            end.SetActive(true);
            SceneManager.LoadScene("Menu");
        }
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
