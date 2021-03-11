using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidBody;
    [SerializeField] float thrust = 3f;
    [SerializeField] float rotationThrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThrustThisFrame)
    {
        rigidBody.freezeRotation = true;// freezing the rotation so we can change rotation manually
        transform.Rotate(Vector3.forward * rotationThrustThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;// unfreezing the rotation so physics system can takeover
    }

    public void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }
}
