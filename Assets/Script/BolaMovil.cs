using UnityEngine;

public class BolaMovil : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private float timer=0;
    [SerializeField] private float timeToReturn;
    private Rigidbody rb;
    private Vector3 currentDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        Collider objeto1 = GetComponent<Collider>();
        Collider objeto2 = GameObject.Find("Carretera").GetComponent<Collider>();
        Physics.IgnoreCollision(objeto1, objeto2, true);
        rb.linearVelocity= Vector3.up* velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer> timeToReturn){
            currentDirection= currentDirection== Vector3.up? Vector3.down: Vector3.up;
            rb.linearVelocity=currentDirection* velocidad; //refresco el vector velocity del rb
            timer=0;
        }
    }
}
