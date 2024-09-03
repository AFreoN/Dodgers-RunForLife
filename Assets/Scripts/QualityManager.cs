using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityManager : MonoBehaviour
{

	void Start ()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 3),true);
	}
	
}
