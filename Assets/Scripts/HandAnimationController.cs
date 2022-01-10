using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimationController : MonoBehaviour
{
    public InputDeviceCharacteristics controllerType;
    public InputDevice thisController;
	private bool isControllerConnected = false;
    private Animator animatorController;
	// Start is called before the first frame update
	void Start()
    {
        Initialize();
        animatorController = GetComponent<Animator>();
    }

    void Initialize () {

        List<InputDevice> controllerDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerType, controllerDevices);

        if(controllerDevices.Count.Equals(0)) {
            Debug.Log("No controller found");
        } else {
            thisController = controllerDevices[0];
            isControllerConnected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isControllerConnected) {
            Initialize();
        } else {
            if (thisController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f) {
                Debug.Log("trigger press" + triggerValue);
                animatorController.SetFloat("Trigger", triggerValue);
            }

            if (thisController.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f) {
                Debug.Log("grip press" + gripValue);
                animatorController.SetFloat("Grip", gripValue);
            }
        }
    }
}
