using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour
{   
    
    private Transform meshPlayer;
    private CharacterController _charController; // component
    // move
    float inputX;    
    float inputZ;
    private Vector3 v_movement; 
    private Animator _animator;
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float gravity;
    private int i;
    [Header("JoyStick")]
    public FixedJoystick _joystick;

    // [Header("Step climb")]
    // [SerializeField] GameObject stepRayUpper;
    // [SerializeField] GameObject stepRayLower;
    // [SerializeField] float stepHeight = 0.3f;
    // [SerializeField] float stepSmooth = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        moveSpeed = 0.5f;
        gravity = 0.5f;
        GameObject pittuPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = pittuPlayer.transform.GetChild(0);
        _charController = pittuPlayer.GetComponent<CharacterController>();
        _animator = meshPlayer.GetComponent<Animator>();
        // stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }

    // private void Awake()
    // {
    //     stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    // }

    // Update is called once per frame
    void Update()
    {
        // inputX = Input.GetAxis("Horizontal");
        // inputZ = Input.GetAxis("Vertical");
        inputX = _joystick.Horizontal;
        inputZ = _joystick.Vertical;
        if(inputX == 0 && inputZ == 0)
        {
            _animator.SetBool("isRun", false);
        }
        else
        {
            _animator.SetBool("isRun", true);
        }
    }

    private void FixedUpdate()
    {
        // gravity, fall
        if(_charController.isGrounded)
        {
            i = 0;
            Debug.Log("Grounded" + i);
            v_movement.y = 0f;
        }
        else
        {
            i+=1;
            Debug.Log("NoGrounded" + i);
            if(i > 20)
            {
                if(meshPlayer.position.y < 4)
                {
                    GetComponent<Animator>().Play("player_Landing2");
                    // _animator.SetTrigger("isFell");
                }
            }
            // Debug.Log("y = " + meshPlayer.position.y);
            v_movement.y -= gravity*Time.deltaTime;
        }


        // movement
        v_movement = new Vector3(inputX * moveSpeed, v_movement.y, inputZ * moveSpeed);
        // v_movement = new Vector3(_joystick.Horizontal * moveSpeed, v_movement.y, _joystick.Vertical * moveSpeed);
        _charController.Move(v_movement);

        // mesh rotate
        if(inputX !=0 || inputZ !=0)
        {
            Vector3 lookDir = new Vector3(v_movement.x, 0, v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
        
        // Climb
        // StepClimb();
        

    }

    // void StepClimb()
    // {
    //     RaycastHit hitLower;
    //     if(Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
    //     {
    //         RaycastHit hitUpper;
    //         if(!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
    //         {
    //             meshPlayer.position -= new Vector3(0f, -stepSmooth, 0f);
    //         }
    //     }
    // }
}
