using Unity.Mathematics;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    [SerializeField] Transform frontLeftWheel;
    [SerializeField] Transform frontRightWheel;
    [SerializeField] float wheelTurnAngle = 30f;
    private Quaternion initialLeftRotation;
    private Quaternion initialRightRotation;

    void Start()
    {
        initialLeftRotation = frontLeftWheel.localRotation;
        initialRightRotation = frontRightWheel.localRotation;
    }

    public void TurnWheels(float input)
    {
        float wheelRotation = wheelTurnAngle * input;
        frontLeftWheel.localRotation = initialLeftRotation * Quaternion.Euler(0, 0, -wheelRotation);
        frontRightWheel.localRotation = initialRightRotation * Quaternion.Euler(0, 0, -wheelRotation);
    }
  
}
