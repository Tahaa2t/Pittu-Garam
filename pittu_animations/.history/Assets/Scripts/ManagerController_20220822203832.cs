using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour
{   
    private CharacterController _charController; // component
    // move
    float inputX;    
    float inputZ;
    private Vector3 v_movement; 
    private float moveSpeed;
    private Animator _animator;
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.5f;
        GameObject pittuPlayer = GameObject.FindGameObjectWithTag("Player");
        _charController = pittuPlayer.GetComponent<CharacterController>();
        _animator = pittuPlayer.GetComponent<Animator>();
    }

    private void Awake()
    {
        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z)
    }

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
        v_movement = new Vector3(inputX * moveSpeed, 0, inputZ * moveSpeed);
        _charController.Move(v_movement);
    }
}
