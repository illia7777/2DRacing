using UnityEngine;

public class SmokeWheels : MonoBehaviour
{
    [SerializeField] ParticleSystem RearLeftSmoke;
    [SerializeField] ParticleSystem RearRightSmoke;
    [SerializeField] float driftThereshold = 0.5f;
    
    void Start()
    {
        
    }
    public void HandleSmokeEffect(float input)
    {
        bool isDrifting = Mathf.Abs(input) > driftThereshold;
        if (RearLeftSmoke != null)
        {
            if (isDrifting && !RearLeftSmoke.isPlaying)
            {
                RearLeftSmoke.Play();
            }
            else if (!isDrifting && RearLeftSmoke.isPlaying)
            {
                RearLeftSmoke.Stop();
            }
        }

        if (RearRightSmoke != null)
        {
            if (isDrifting && !RearRightSmoke.isPlaying)
            {
                RearRightSmoke.Play();
            }
            else if (!isDrifting && RearRightSmoke.isPlaying)
            {
                RearRightSmoke.Stop();
            }
        }
    }

    
}
