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

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.5f;
        GameObject pittuPlayer = GameObject.FindGameObjectWithTag("Player");
        _charController = pittuPlayer.GetComponent<CharacterController>();
        _animator = pittuPlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        Debug.Log(inputX + inputZ);
    }

    private void FixedUpdate()
    {
        v_movement = new Vector3(inputX * moveSpeed, 0, inputZ * moveSpeed);
        _charController.Move(v_movement);
    }
}
