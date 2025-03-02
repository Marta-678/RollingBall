using Unity.VisualScripting;
using UnityEngine;

public class BolaJugadoraTunel : MonoBehaviour
{
     private Rigidbody rb;
     private float horizontalInput, vecesMuerte;
    // variables que almacena la entrada del usuario
    // si ya se ha saltado
    public Vector3 respawnPoint;
    // variables relacionadas con las fuerzas y el moviento del jugador 
    [SerializeField] private float jumpForce, movementForce, y_limite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        respawnPoint=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vecesMuerte=0;
        horizontalInput = Input.GetAxis("Horizontal");
        if(transform.position.y<y_limite){
            transform.position = respawnPoint;
            rb.linearVelocity = Vector3.zero;
            vecesMuerte++;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * movementForce, ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rb.AddForce(Vector3.right * horizontalInput * movementForce, ForceMode.Force);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Espejo"))
        {
            transform.position = respawnPoint;
            rb.linearVelocity = Vector3.zero;
            vecesMuerte++;
        }
        if (collision.gameObject.CompareTag("Trampilla")){
            Rigidbody rbTrampilla= collision.gameObject.GetComponent<Rigidbody>();

            if(rbTrampilla!= null){
                rbTrampilla.useGravity= true;
                rbTrampilla.isKinematic = false; 
                vecesMuerte++;
            }
        }
    }

    private void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("TrampaDeslizante") )
        {
            transform.position = respawnPoint;
            rb.linearVelocity = Vector3.zero;
            vecesMuerte++;
        }
       
    }
    
}
