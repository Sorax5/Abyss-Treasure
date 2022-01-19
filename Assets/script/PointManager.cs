using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public int points = 0;
    public Text currentPointsText;

    public int getPoints() {
        return this.points;
    }

    public void addPoints(string tag) {
        switch (tag)
        {
            case "DiamondChest":
                this.addPoints(10);
                break;

            /*case "green chest":
                this.addPoints(20);
                break;

            case "yellow chest":
                this.addPoints(30);
                break;

            case "white chest":
                this.addPoints(40);
                break;
        
            case "blue gem":
                this.addPoints(1);
                break;

            case "green gem":
                this.addPoints(2);
                break;

            case "yellow gem":
                this.addPoints(3);
                break;

            case "white gem":
                this.addPoints(4);
                break;*/

            default:
                //idk
                break;
        }
    }

    public void addPoints(int amount) {
        this.points += amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPointsText.text = getPoints().ToString(); 
    }
}
