using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeKeeper : MonoBehaviour
{
    Text liveText;
    [SerializeField] int lives = 3;
    [SerializeField] Vector3 respawnPosition;
    [SerializeField] GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        liveText = GetComponent<Text>();
        liveText.text = lives.ToString();
    }

    // Update is called once per frame
    public void DecreaseLive()
    {
        lives--;
        liveText.text = lives.ToString();

        if(lives > 0)
        {
            var newPlayer = Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
        }
    }
}
