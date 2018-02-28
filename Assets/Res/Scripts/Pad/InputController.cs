using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    public static InputController instance;

	public Text inputXText;
	public Text inputYText;

	public float posX;
	public float posY;

	public Vector2 inputVec;

    public bool jumpKey = false;

    public bool logButtons = false;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update() {

        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        if (inputXText) {
            inputXText.text = "InputX: " + posX;
        }

        if (inputYText) {
            inputYText.text = "InputY: " + posY;
        }


        inputVec = new Vector2(posX, posY);

        if (inputVec.magnitude > 1f) {
            inputVec.Normalize();
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;
        }
        else
        {
            jumpKey = false;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            PlayerController.instance.ResetPos();
        }

        if (logButtons) {

            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Debug.Log("Btn  0");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Debug.Log("Btn  1");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                Debug.Log("Btn  2");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                Debug.Log("Btn  3");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                Debug.Log("Btn  4");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                Debug.Log("Btn  5");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                Debug.Log("Btn  6");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                Debug.Log("Btn  7");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button8))
            {
                Debug.Log("Btn  8");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                Debug.Log("Btn  9");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button10))
            {
                Debug.Log("Btn  10");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button11))
            {
                Debug.Log("Btn  11");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button12))
            {
                Debug.Log("Btn  12");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button13))
            {
                Debug.Log("Btn  13");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button14))
            {
                Debug.Log("Btn  14");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button15))
            {
                Debug.Log("Btn  15");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button16))
            {
                Debug.Log("Btn  16");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button17))
            {
                Debug.Log("Btn  17");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button18))
            {
                Debug.Log("Btn  18");
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button19))
            {
                Debug.Log("Btn  19");
            }

        }

	}

}
