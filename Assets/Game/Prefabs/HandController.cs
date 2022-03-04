using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum HandType
{
    Left,
    Right
}
public class HandController : MonoBehaviour
{
    public HandType handType;

    private Animator animator;
    private InputDevice inputDevice;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inputDevice = GetInputDevice();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand
    }

    InputDevice GetInputDevice()
    {
        InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.HeldInHand 
        | InputDeviceCharacteristics.Controller;

        if (handType == HandType.Left)
        {
            controllerCharacteristics = controllerCharacteristics | InputDeviceCharacteristics.Left;
        }
        else
        {
            controllerCharacteristics = controllerCharacteristics | InputDeviceCharacteristics.Right;
        }

        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);

        return inputDevices[0];       
    }
    void AnimateHand()
    {
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out indexValue);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out threeFingersValue);

        animator.SetFloat("index", indexValue);
        animator.SetFloat("ThreeFingers", threeFingerValue);
    }
}
