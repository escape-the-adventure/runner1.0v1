using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	public enum State {Idle, Walk, Run, Jump};

	public State currentState = State.Idle;

    public bool smoothRotation = false;

	public Text inputXText;
	public Text inputYText;
	public Text speedText;

	public float posX;
	public float posY;

	public float directionX;
	public float directionY;

	public float currentSpeed;

	public Animator timAnim;

	public Transform tim;
    public Rigidbody rigid;

	public Transform visualizer;

	public Transform directionTr;

	public float walkSpeed = 10f;
	public float runSpeed = 20f;
	public float walkTurnSpeed = 10f;
	public float runTurnSpeed = 20f;
	public float runStart = 0.8f;
    public float jumpForce = 100f;
    public float gravity = -40f;

	Vector2 inputVec;

	public bool grouded = false;


	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, gravity, 0);
    }
	
	// Update is called once per frame
	void Update () {

        CheckGround();

		posX = Input.GetAxis ("Horizontal");
		posY = Input.GetAxis ("Vertical");

		if(inputXText){
			inputXText.text = "InputX: " + posX;
		}

		if(inputYText){
			inputYText.text = "InputY: " + posY;
		}


		inputVec = new Vector2 (posX, posY);

		if (inputVec.magnitude > 1f) {
			inputVec.Normalize ();
		}

		currentSpeed = inputVec.magnitude;
		currentSpeed = currentSpeed * 10f;
		currentSpeed = Mathf.Round(currentSpeed) / 10f;

		if(speedText){
			speedText.text = "Speed: " + currentSpeed;
		}

		if (visualizer) {
			visualizer.localPosition = new Vector3 (posX, posY, visualizer.localPosition.z);
		}

        UpdateDirection();

        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (currentState != State.Jump && grouded)
            {
                //SetTrigger("jump");
                ResetTriggers();
                currentState = State.Jump;
                rigid.AddForce(tim.up * jumpForce);
            }
        }

        if (currentSpeed > 0f){

			if (currentSpeed < runStart) {																		//	walk

                if (currentState != State.Walk && grouded)
                {
                    SetTrigger("walk");
                    currentState = State.Walk;
                }

                tim.position += tim.forward * walkSpeed * Time.deltaTime;

                if (directionX < 0f || (directionX == 0f && directionY < 0f)) {
                    if (smoothRotation)
                    {
                        tim.Rotate(-Vector3.up * walkTurnSpeed * Time.deltaTime);
                        UpdateDirection();

                        if (directionX > 0f)
                        {
                            tim.LookAt(directionTr);
                        }
                    }
                    else
                    {
                        tim.LookAt(directionTr);
                    }
                    
				}
				else if(directionX > 0f)
                {
                    if (smoothRotation)
                    {
                        tim.Rotate(Vector3.up * walkTurnSpeed * Time.deltaTime);
                        UpdateDirection();

                        if (directionX < 0f)
                        {
                            tim.LookAt(directionTr);
                        }

                    }
                    else
                    {
                        tim.LookAt(directionTr);
                    }
                    
                }
			}
			else {																								//	run

                if (currentState != State.Run && grouded)
                {
                    SetTrigger("run");
                    currentState = State.Run;
                }

                tim.position += tim.forward * runSpeed * Time.deltaTime;

                if (directionX < 0f || (directionX == 0f && directionY < 0f)) {
                    if (smoothRotation)
                    {
                       tim.Rotate(-Vector3.up * runTurnSpeed * Time.deltaTime);
                        UpdateDirection();

                        if (directionX > 0f)
                        {
                            tim.LookAt(directionTr);
                        }
                    }
                    else
                    {
                        tim.LookAt(directionTr);
                    }
                    
                }
				else if(directionX > 0f){
                    if (smoothRotation)
                    {
                       tim.Rotate(Vector3.up * runTurnSpeed * Time.deltaTime);
                        UpdateDirection();

                        if (directionX < 0f)
                        {
                            tim.LookAt(directionTr);
                        }
                    }
                    else
                    {
                        tim.LookAt(directionTr);
                    }
                    
                }
				
			}

		}
		else{																									//	idle
			if(currentState != State.Idle && grouded)
            {
				SetTrigger("idle");
				currentState = State.Idle;
			}
		}

	}

	public void SetTrigger(string triggerName){
		ResetTriggers();
		timAnim.SetTrigger(triggerName);
	}

	public void ResetTriggers(){
		timAnim.ResetTrigger("walk");
		timAnim.ResetTrigger("idle");
		timAnim.ResetTrigger("run");
	}

    public void UpdateDirection()
    {
        directionTr.position = tim.position;
        directionTr.position = new Vector3(directionTr.position.x + posX, directionTr.position.y, directionTr.position.z + posY);

        directionTr.parent = tim;

        directionX = directionTr.localPosition.x;
        directionY = directionTr.localPosition.z;
    }

    public void CheckGround()
    {
        if(Physics.Raycast(tim.position, -tim.up, 0.2f))
        {
            grouded = true;
        }
        else
        {
            grouded = false;
        }
    }

}
