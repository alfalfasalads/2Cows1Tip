using UnityEngine;
using System.Collections;

public class CowSpawner : MonoBehaviour
{
    public static CowSpawner instance;

    // Serialize Field to make it visible in the Unity Hierarchy
    [SerializeField]
    BoxCollider[] m_CowZones;

    public GameObject m_CowPrefab;

    public float COW_SPAWN_TIMER;
    private float m_CowSpawnTimer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start ()
    {
        m_CowSpawnTimer = COW_SPAWN_TIMER;
	}
	

	void FixedUpdate ()
    {
	    if (m_CowSpawnTimer > 0)
        {
            m_CowSpawnTimer -= Time.fixedDeltaTime;

            if (m_CowSpawnTimer <= 0)
            {
                int randomZoneIndex = Random.Range(0, m_CowZones.Length);
                BoxCollider selectedZone = m_CowZones[randomZoneIndex];
                float xSize = selectedZone.size.x / 2;
                float zSize = selectedZone.size.z / 2;

                float xVariance = Random.Range(-xSize, xSize);
                float zVariance = Random.Range(-zSize, zSize);

                float newXPosition = selectedZone.transform.position.x + xVariance;
                float newZPosition = selectedZone.transform.position.z + zVariance;

                Instantiate(m_CowPrefab,
                    new Vector3(newXPosition, selectedZone.transform.position.y, newZPosition),
                    Quaternion.identity);

                print("Spawning cow at " + newXPosition + " , " + selectedZone.transform.position.y + " , " + newZPosition);

                m_CowSpawnTimer = COW_SPAWN_TIMER;
            }
        }
	}
}
