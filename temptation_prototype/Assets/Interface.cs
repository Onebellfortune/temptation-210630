using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public int love;
    public int currentLove;
    public GameObject loveBarBackground;
    public Image loveBarFilled;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentLove = love;
        loveBarFilled.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
