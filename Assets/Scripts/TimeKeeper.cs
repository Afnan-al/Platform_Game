using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    Text timerText;
    [SerializeField] float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        //Debug.Log(time);
        if (time <= 0)
        {
            timerText.text = "Game Over";
            DestroyPlayer();

        }
        else
        {
            time -= Time.deltaTime;
            int timerVal = (int)time;
            timerText.text = "Time Remaining: " + timerVal;
        }
        
       
    }
    private void DestroyPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            Destroy(player.gameObject);
        }
    }
}
