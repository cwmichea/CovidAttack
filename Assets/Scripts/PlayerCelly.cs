using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCelly : MonoBehaviour
{
    public CharacterController controller;
    //for move
    public float speed = 9f;    // factor of the movement
    private Vector3 direction;  // movement vector 
    public float turnSmoothTime = 0.9f;//smooth rotation
    float turnSmoothVelocity;
    //for jumping
    private bool onEarth = true;
    [SerializeField] private float jumpForce = 100.0f;
    [SerializeField] private float gravity = 18.0f;
    //activate InputSystem
    private float inputH, inputV = 0f;
    private bool  inputJ = false;
    //Game Manager
    private GameManager manager;
    Rigidbody rigid;//rigidbody
    //Freeze the character on pause
    public bool onPause = false;
    //RaycastHit 
    //private float contactRange = 1f;
    void Start()
    {
        controller = GetComponent<CharacterController>();//character controller
        manager = GameManager.instance;
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!onPause)
        {

        
         onEarth = controller.isGrounded;
         //Celly movement on earth
         if (onEarth)
         {
            direction = new Vector3(inputH, 0f, inputV) ;
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            }
            direction *= speed;
            if (inputJ)
            {
                inputJ = false; //Prevent to jump when it is in the air, but unnecessary cause it is already not on the ground
                direction.y = jumpForce;
            }
         }
         direction.y -= gravity     * Time.deltaTime ;
         controller.Move(direction * Time.deltaTime);
            //RaycastHit hit;//   get the objects with a raycast //  X TRY 1  IT DIDNT WORK THE RAYCAST HIT
            //if (Physics.Raycast(transform.position, transform.forward, out hit, contactRange))
            //{
            //    //Debug.Log("Get Vaccine");
            //    if (hit.collider.tag == "Vaccine")
            //    {
            //        manager.Victory();
            //    }
            //}
            //if (Physics.Raycast(transform.position, transform.forward, out hit, contactRange))
            //{
            //    //Debug.Log("Get Capsule");
            //    if (hit.collider.tag == "Capsule")
            //    {
            //        Debug.Log("capsule");
            //        manager.AddScore();
            //    }
            //}
        }
    }
    //INPUT SYSTEM ACTIONS
    public void OnMove(InputAction.CallbackContext context)
    {//Converting 2Dvector input given for the player into a variable that is used in the code
        Debug.Log("Moving!");
        Vector2 moveOn = context.ReadValue<Vector2>();
        inputH = moveOn.x;
        inputV = moveOn.y;
    }
    public void OnJump(InputAction.CallbackContext context)
    {//Converting a boolean input given for the player into a variable that is used in the code
        inputJ = context.performed;
    }
    public void OnPause(InputAction.CallbackContext context)
    {//Converting a boolean input given for the player into a variable that is used in the code
        Debug.Log("Paused pressed");
        bool ON = context.performed;
        if (onPause)
        {
            onPause = false;
        }
        else
        {
            onPause = true;
        }
    }
    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Covy")
    //    {
    //        Debug.Log("Damage");
    //        manager.Damage();
    //    }
    //}
    //ON COLLISION 
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("hit");
    //Vector3 collisionPosition = collision.transform.position;//save the place of the collsion // X TRY 2 IT DIDNT WORK WITH COLLISION FROM HERE
    //if (collision.transform.tag == "Capsule") //  for some reason it is not working. 
    //{
    //    Debug.Log("Get Capsule");
    //    manager.AddScore();
    //}
    //else if (collision.transform.tag == "Vaccine") //  for some reason it is not working 
    //{
    //    Debug.Log("Get Vaccine");
    //    manager.Victory();
    //}
    //}
}
//CODE THAT DIDNT WORK TO MOVE AND JUMP THE CHARACTER
//identification 
//    private GameObject thisGameObject; 
//    private Rigidbody thisRigidBody;
//    //jumping
//    [SerializeField] private float jumpForce = 6;
//    //moving
//    private float h = 0;
//    private float v = 0;
//    [SerializeField] private float speed = 3.0f;
//    //camera
//    private Transform camRef;
//    private Vector3 camForward;
//    private Vector3 movRef;

//    // Start is called before the first frame update
//    void Start()
//    {   //retrieving/getting this game object
//        thisGameObject = GetComponent<GameObject>();
//        thisRigidBody = GetComponent<Rigidbody>();//is it necessary?
//        //getting the cam
//        if (Camera.main!=null)
//        {
//            camRef = Camera.main.transform;
//        }
//        else
//        {
//            Debug.LogWarning(" No main Camera found. Camera tagged MainCamera ");
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Time.timeScale==0)
//        {
//            return;
//        }
//        //Vector3 transf = new Vector3();
//    }
//    void FixedUpdate()
//    {
//        //movement
//        thisRigidBody.AddForce(Vector3.right * (speed*h));
//        thisRigidBody.AddForce(Vector3.forward * (speed * v));
//        //activate the cam movement
//        if (camRef != null)
//        {
//            camForward = Vector3.Scale(camForward, new Vector3(1,0,1)).normalized;//I dont understand this
//            movRef = v * camForward + h * camRef.right;//I just dont get it
//        }
//        else
//        {
//            movRef = v * Vector3.forward + h * Vector3.right;//I just dont get it
//        }
//    }

//    public void OnJump()
//    {
//        Debug.Log("Jumping!");
//        thisRigidBody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
//    }
//    public void OnMove(InputAction.CallbackContext value)
//    {
//        Debug.Log("Moving!");
//        Vector2 val = value.ReadValue<Vector2>();
//        h = val.x;
//        v = val.y;
//    }
//public class PlayerCelly : MonoBehaviour
//{
//    public CharacterController controller;
//    public float speed = 6f;
//    public float turnSmoothTime = 0.1f;//smooth rotation
//    float turnSmoothVelocity;
//    //[SerializeField] private float gravity = 20.0f;
//    void Update()
//    {
//        //Celly movement with the old system
//        float horizontal = Input.GetAxisRaw("Horizontal");
//        float vertical = Input.GetAxisRaw("Vertical");
//        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
//        if (direction.magnitude >= 0.1f)
//        {
//            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
//            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

//            controller.Move(direction * speed * Time.deltaTime);
//        }
//    }