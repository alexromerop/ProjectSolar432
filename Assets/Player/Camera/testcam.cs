using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcam : MonoBehaviour
{
    private bool oncam;

    [SerializeField]
    private GameObject player;


    [SerializeField]
    public float mouseSensitivityX;
    [SerializeField]
    public float mouseSensitivityY;


    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private GameObject _target;                                  //camera pivot and follow
    [SerializeField]
    public Transform lookme;                                  //camera pivot and follow

    [SerializeField]
    private float _distanceFromTarget;




    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.1f;


    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    public Transform cameraTransform;                           //transform actual camera
    public float cameraCollisionRadius= 0.4f;


    public LayerMask collisionLayer;

    RaycastHit hit;


    //public BoxCollider Cheker;


    private Vector3 nextRotation;
    public Vector2 mouse;
    public float mouseX;
    public float mouseY;
    Vector3 heading;
    float distance;
    Vector3 direction;


    private void Awake()
    {

        

    }

    private void LateUpdate()
    {
        Camera();

    }

    private void Update()
    {

  


    }
    void Camera()
    {
        Vector2 a = InputManager_SCR.instance.look;
        mouseX = a.x * mouseSensitivityX/100;
        mouseY = a.y * -mouseSensitivityY/100;



        _rotationY += mouseX;
        _rotationX += mouseY;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;


        heading = this.gameObject.transform.position - _target.transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
        direction.Normalize();
        
       





        if (oncam == false)
        {
            //cameraCollisionRadius = _distanceFromTarget * 0.23f;


           

            



            if (Physics.SphereCast(new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z), cameraCollisionRadius/2, direction, out hit, _distanceFromTarget, collisionLayer, QueryTriggerInteraction.UseGlobal))
            {
                
                    _distanceFromTarget = hit.distance;
                if (_distanceFromTarget < 0)
                {
                    _distanceFromTarget = 0;
                }

                Debug.Log(hit.collider.gameObject.name);

            }
           
        }
            transform.position = _target.transform.position - transform.forward * (_distanceFromTarget);
      
        
    }
   
   


}