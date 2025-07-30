using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI bossText;
    public GameObject health1, health2, health3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHeart(int health)
    {
        switch (health)
        {
            case 1:
                health1.SetActive(false);
                break;
            case 2:
                health2.SetActive(false);
                break;
            case 3:
                health3.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void WinHealth(int health)
    {
        switch (health)
        {
            case 1:
                health1.SetActive(true);
                break;
            case 2:
                health2.SetActive(true);
                break;
            case 3:
                health3.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void ChangeBossText(string text)
    {
        bossText.text = text;
    }
}
