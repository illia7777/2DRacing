using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float rotationAngle = 15;
    [SerializeField] float rotationSpeed = 5;
    private float HorizontalInput;
    public float InitialRotationZ;
    private WheelRotate wheelRotate;
    private SmokeWheels smokeWheels;
    GameUI gameUI;
    private bool inputControl = true;
    private IReactPlayer reaction = new ReplusionReact();
    void Start()
    {

        InitialRotationZ = transform.rotation.eulerAngles.z;
        wheelRotate = GetComponent<WheelRotate>();
        smokeWheels = GetComponent<SmokeWheels>();
        gameUI = FindObjectOfType<GameUI>();
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        float newX = transform.position.x+HorizontalInput*speed*Time.deltaTime;
        transform.position = new Vector2(newX, transform.position.y);
        RotateCar();
        wheelRotate.TurnWheels(HorizontalInput);
        smokeWheels.HandleSmokeEffect(HorizontalInput);
    }

    public void setInputControl(bool value)
    {
       inputControl = value;

    }
    void RotateCar()
    {
        float TargetAngle = InitialRotationZ - HorizontalInput*rotationAngle;
        TargetAngle = Mathf.Clamp(TargetAngle, InitialRotationZ - rotationAngle, InitialRotationZ+rotationAngle);
        float SmonthAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, TargetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, SmonthAngle);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyCar"))
        {
            Vector2 direction = other.transform.position - transform.position;
            StartCoroutine(reaction.React(this, direction));
        }
        if (other.CompareTag("Coin"))
        {
            gameUI.setCoin(1);
            Destroy(other.gameObject);
        }

    }
}
