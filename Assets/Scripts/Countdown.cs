using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float remainingTime;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {

            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
