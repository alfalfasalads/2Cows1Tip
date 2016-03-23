using UnityEngine;
using System.Collections;

public class CowRandomBehaviour : MonoBehaviour
{
    [SerializeField]
    private const float SWITCH_TIMER = 10.0f;
    private float switchTimer;
    [SerializeField]
    private const float LERP_TIMER = 1.0f;
    private float lerpTimer;
    private Vector3 lerpDestination;
    private Vector3 lerpOrigin;

    [SerializeField]
    private const float MOO_TIMER = 20.0f;
    [SerializeField]
    private const float MOO_TIMER_VARIANCE = 5.0f;
    private float mooTimer;

    private bool isWalking;
    private bool isBeingTipped;

    public void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        switchTimer = SWITCH_TIMER;
        lerpTimer = LERP_TIMER;
        isWalking = false;
        isBeingTipped = false;
        mooTimer = MOO_TIMER;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // For Standing and Random Walking
        if (switchTimer > 0)
        {
            switchTimer -= Time.fixedDeltaTime;

            if (switchTimer <= 0)
            {
                SwitchBehaviour();
                switchTimer = SWITCH_TIMER;

                if (isWalking == true)
                {
                    CalculateDestination();
                }
            }            
        }

        if (isWalking)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, lerpDestination, lerpTimer * Time.deltaTime);
        }

    }

    private void CalculateDestination()
    {
        // Generate Random direction to walk
        float randomX = Random.Range(0f, 1.0f);
        float randomZ = Random.Range(0f, 1.0f);

        Vector3 lerpDirection = new Vector3(randomX, 0, randomZ);
        lerpDirection.Normalize();
        lerpDirection.Scale(new Vector3(3, 0, 3));

        lerpDestination = this.gameObject.transform.position + lerpDirection;
    }

    private void SwitchBehaviour()
    {
        isWalking = !isWalking;
    }

    public void StartTipping()
    {
        isBeingTipped = true;
    }
}
