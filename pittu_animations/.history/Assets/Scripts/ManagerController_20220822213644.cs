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
    private float moveSpeed;
    private Animator _animator;
    private float gravity;


    // [SerializeField] GameObject stepRayUpper;
    // [SerializeField] GameObject stepRayLower;
    // [SerializeField] float stepHeight = 0.3f;
    // [SerializeField] float stepSmooth = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.5f;
        gravity = 0.5f;
        GameObject pittuPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = pittuPlayer.transform.GetChild(0);
        _charController = pittuPlayer.GetComponent<CharacterController>();
        _animator = meshPlayer.GetComponent<Animator>();
    }

    // private void Awake()
    // {
    //     stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    // }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        Debug.Log(inputX + inputZ);
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
        // gravity
        if(_charController.isGrounded)
        {
            v_movement.y = 0f;
        }
        else
        {
            v_movement.y -= gravity*Time.deltaTime;
        }


        // movement
        v_movement = new Vector3(inputX * moveSpeed, v_movement.y, inputZ * moveSpeed);
        _charController.Move(v_movement);

        // mesh rotate
        if(inputX !=0 || inputZ !=0)
        {
            Vector3 lookDir = new Vector3(v_movement.x, v_movement.y, v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
        

    }
}
