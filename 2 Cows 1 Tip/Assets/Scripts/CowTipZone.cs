using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CowTipZone : MonoBehaviour
{
    List<Collider> m_CowsInTheZone;

    // Use this for initialization
    void Start()
    {
        m_CowsInTheZone = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cow" && !m_CowsInTheZone.Contains(other))
        {
            m_CowsInTheZone.Add(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cow" && m_CowsInTheZone.Contains(other))
        {
            m_CowsInTheZone.Remove(other);
        }
    }

    public void TipCow()
    {
        if (m_CowsInTheZone.Count > 0)
        {
            // Tip first cow
            m_CowsInTheZone[0].GetComponent<Rigidbody>().AddForce(0, 5, 2, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("No Cows to tip!");
        }
    }
}
