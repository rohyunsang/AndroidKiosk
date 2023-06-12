using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    InputField IDInputField;
    InputField PWInputField;

    void UserID(){
        string ID = IDInputField.text;
    }

    void UserPW(){
        string PW = PWInputField.text;
    }
}
