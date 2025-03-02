using UnityEngine;

public class BolaJugador : MonoBehaviour
{
    // almacena el rigidbody
    private Rigidbody rb;
    // si ya se ha saltado
    public bool isGrounded = true;
    public Vector3 respawnPoint;
    // variables relacionadas con las fuerzas y el moviento del jugador 
    [SerializeField] private float jumpForce, movementForce, maxSpeed;

    
    
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        respawnPoint=transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

   

    private void FixedUpdate(){
        Vector3 direccion = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W)) direccion += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) direccion += Vector3.back;
        if (Input.GetKey(KeyCode.A)) direccion += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direccion += Vector3.right;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // isGrounded = false; // Evita saltos infinitos
        }
        
        
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(direccion.normalized*movementForce, ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo") ||collision.gameObject.layer == LayerMask.NameToLayer("TrampaDeslizante"))
        {
            transform.position = respawnPoint;
            rb.linearVelocity = Vector3.zero;
        }
    }
}
