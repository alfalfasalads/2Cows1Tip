using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text m_TimerText;

    float m_Timer = 0;
    float m_RoundLength = 120.0f;

    bool m_Paused = false;

    // Use this for initialization
    void Start()
    {
        m_Timer = m_RoundLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Timer <= 0)
        {
            return;
        }

        if (!m_Paused)
        {
            m_Timer -= Time.deltaTime;
        }
    }

    public void OnGUI()
    {
        int minutes = Mathf.FloorToInt(m_Timer / 60f);
        int seconds = Mathf.FloorToInt(m_Timer % 60);
        m_TimerText.text = minutes.ToString("0") + ":" + seconds.ToString("00");
    }
}
