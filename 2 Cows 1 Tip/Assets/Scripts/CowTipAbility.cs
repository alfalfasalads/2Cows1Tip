using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CowTipAbility : MonoBehaviour
{
    private const float m_TipBarMax = 1.0f;
    private const float m_TipBarIncRate = 0.2f;
    private const float m_TipBarNaturalDecRate = 0.35f;
    private float m_TipBarCharge = 0;

    public Image m_BarBackground;
    public Image m_BarFill;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Temporary Code to make bar fill
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Charge the Bar
            m_TipBarCharge += m_TipBarIncRate;
        }

        // If Bar isn't full, make charge decrease over time
        if (!BarIsFull())
        {
            m_TipBarCharge -= m_TipBarNaturalDecRate * Time.deltaTime;

            if (m_TipBarCharge < 0)
            {
                m_TipBarCharge = 0;
            }
        }
        // If bar is full, tip the cow
        else
        {
            print("COW HAS BEEN TIPPED");

            // Reset the Charge
            m_TipBarCharge = 0;
        }
    }

    public void OnGUI()
    {
        // Draw the Fill of the Punch Charge Bar
        m_BarFill.rectTransform.sizeDelta = new Vector2(m_BarBackground.rectTransform.sizeDelta.x * m_TipBarCharge, m_BarBackground.rectTransform.sizeDelta.y);
    }

    private bool BarIsFull()
    {
        return (m_TipBarCharge >= m_TipBarMax);
    }
}
