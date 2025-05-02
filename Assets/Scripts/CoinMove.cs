using UnityEngine;

public class CoinMove : MonoBehaviour
{

    void Update()
    {
        transform.Translate(0, (-10) * Time.deltaTime, 0);
        Vector3 pose = transform.position;
        pose.z = -2f;
        transform.position = pose;
    }
}
