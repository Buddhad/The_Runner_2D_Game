using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2  jumpSpeed;
    [SerializeField]
    private float movementx;
    Animator animator;
    Transform selfTransform;
    public Transform spawnPoint;

    public bool isOnGround;
    public float maxRunSpeed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        selfTransform = transform;
        SpawnPlayerOnPoint();
    }

    void SpawnPlayerOnPoint()
    {
        selfTransform.position = spawnPoint.position;
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal > 0)
        {
            //facing right
           selfTransform.rotation = new Quaternion(0, 0, 0, 0);

        }
        else if (moveHorizontal < 0)
        {
            //facing left
            selfTransform.rotation = new Quaternion(0, -180, 0, 0);
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if(rb.velocity.magnitude < maxRunSpeed)
        {
              rb.AddForce(movement * movementx);
        }
      
        //Debug.Log(rb.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(jumpSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //animation
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("state", 1);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            
            animator.SetInteger("state", 0);
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            animator.SetInteger("state", 2);
           Invoke("Resetjump", 0.1f);
        } 
      
     
       

    }
    void Resetjump()
    {
        animator.SetInteger("state", 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagTracker.killTriggertag)
        {
            SpawnPlayerOnPoint();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagTracker.groundtag)
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagTracker.groundtag)
        {
            isOnGround = false;
        }
    }


}