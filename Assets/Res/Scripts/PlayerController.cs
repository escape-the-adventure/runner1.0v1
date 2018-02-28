using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public enum State { None, Idle, Walk, Run, Jump };

    public State currentState = State.Idle;

    public bool smoothRotation = false;

    public Text speedText;

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

    public CheckGround checkGround;

    Vector3 startPos;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        startPos = tim.position;
    }

    private void Update()
    {

        if (!checkGround.IsGrounded() && currentState == State.Jump)
        {
            currentState = State.None;
        }

        currentSpeed = InputController.instance.inputVec.magnitude;
        currentSpeed = currentSpeed * 10f;
        currentSpeed = Mathf.Round(currentSpeed) / 10f;

        if (speedText)
        {
            speedText.text = "Speed: " + currentSpeed;
        }

        if (visualizer)
        {
            visualizer.localPosition = new Vector3(InputController.instance.posX, InputController.instance.posY, visualizer.localPosition.z);
        }

        UpdateDirection();

        if (InputController.instance.jumpKey)
        {
            if (currentState != State.Jump && checkGround.IsGrounded())
            {
                SetTrigger("jump");
                currentState = State.Jump;
                rigid.AddForce(tim.up * jumpForce);
            }
        }

        if (currentSpeed > 0f)
        {

            if (currentSpeed < runStart)
            {																		//	walk

                if (currentState != State.Walk && checkGround.IsGrounded() && !IsJumping())
                {
                    SetTrigger("walk");
                    currentState = State.Walk;
                }

                tim.position += tim.forward * walkSpeed * Time.deltaTime;

                if (directionX < 0f || (directionX == 0f && directionY < 0f))
                {
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
                else if (directionX > 0f)
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
            else
            {																								//	run

                if (currentState != State.Run && checkGround.IsGrounded() && !IsJumping())
                {
                    SetTrigger("run");
                    currentState = State.Run;
                }

                tim.position += tim.forward * runSpeed * Time.deltaTime;

                if (directionX < 0f || (directionX == 0f && directionY < 0f))
                {
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
                else if (directionX > 0f)
                {
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
        else
        {                                                                                                   //	idle
            if (currentState != State.Idle && checkGround.IsGrounded() && !IsJumping())
            {
                SetTrigger("idle");
                currentState = State.Idle;
            }
        }
    }

    public void UpdateDirection()
    {
        directionTr.position = tim.position;
        directionTr.position = new Vector3(directionTr.position.x + InputController.instance.posX, directionTr.position.y, directionTr.position.z + InputController.instance.posY);

        directionTr.parent = tim;

        directionX = directionTr.localPosition.x;
        directionY = directionTr.localPosition.z;
    }

    public void SetTrigger(string triggerName)
    {
        ResetTriggers();
        timAnim.SetTrigger(triggerName);
    }

    public bool IsJumping()
    {
        return (currentState == State.Jump);
    }

    public void ResetTriggers()
    {
        timAnim.ResetTrigger("walk");
        timAnim.ResetTrigger("idle");
        timAnim.ResetTrigger("run");
    }

    public void ResetPos()
    {
        tim.position = startPos;
    }

}
