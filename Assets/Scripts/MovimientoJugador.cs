using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public static PlayerMove instance;

    public float moveSpeed, gravityForce, jumpForce, sprintSpeed;
    public CharacterController characterController;

    public Vector3 moveInput;

    public Transform cameraTransform;

    public float mouseSensitivity;

    public Animator animator;

    public GameObject bullet;
    public Transform firePoint;

    public GameObject destello;

    public float fireRate = 0.2f; // Tiempo entre disparos
    private float nextFireTime = 0f; // Controla cuándo se puede disparar de nuevo



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!UI.instance.pausa.activeInHierarchy)
        {

            
            float yVelocity = moveInput.y;
            
            Vector3 verticalMove = transform.forward * Input.GetAxis("Vertical");
            Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal");

            moveInput = horizontalMove + verticalMove;
            moveInput.Normalize();

            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveInput = moveInput * sprintSpeed;
            }
            else
            {
                moveInput = moveInput * moveSpeed;
            }


            moveInput.y = yVelocity;

            moveInput.y += Physics.gravity.y * gravityForce * Time.deltaTime;

            if (characterController.isGrounded)
            {
                moveInput.y = Physics.gravity.y * gravityForce * Time.deltaTime;
            }

            //Saltar
            if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            {
                moveInput.y = jumpForce;
            }

            characterController.Move(moveInput * Time.deltaTime);

            // Camera rotation
            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

            cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

            //Disparos
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Dispara mientras el botón esté presionado
            {
                nextFireTime = Time.time + fireRate; // Controla la velocidad de disparo

                RaycastHit hit;
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 200f))
                {
                    if (Vector3.Distance(cameraTransform.position, hit.point) > 1f)
                    {
                        firePoint.LookAt(hit.point);
                    }
                    else
                    {
                        firePoint.LookAt(cameraTransform.position + (cameraTransform.forward * 40f));
                    }
                }

                Instantiate(bullet, firePoint.position, firePoint.rotation);

                // Activa el destello mientras dispare
                destello.SetActive(true);
            }

            // Cuando el jugador suelte el botón de disparo, apaga el destello
            if (Input.GetMouseButtonUp(0))
            {
                destello.SetActive(false);
            }

            animator.SetFloat("moveSpeed", moveInput.magnitude);
        }
    }

    IEnumerator Destello()
    {
        destello.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        destello.SetActive(false);
    }
}
