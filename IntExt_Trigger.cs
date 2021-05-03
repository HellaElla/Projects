using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorExteriorTrig : MonoBehaviour
{
    private AudioSource AC_inside, Blizzard_from_INT, Blizzard_from_INT_2, rain;
    private AudioSource AirlockSealOpen_HV, AirlockSealClose_HV;
    private AudioReverbZone Int_Reverb_Zone, Ext_Reverb_Zone;
    private AudioSource ext_wind;
    private void Awake()
    {

        AC_inside = GameObject.Find("AC_inside").GetComponent<AudioSource>();
        Blizzard_from_INT = GameObject.Find("Blizzard_from_INT").GetComponent<AudioSource>();
        Blizzard_from_INT_2 = GameObject.Find("Blizzard_from_INT_2").GetComponent<AudioSource>();

        AirlockSealOpen_HV = GameObject.Find("AirlockSealOpen_HV").GetComponent<AudioSource>();
        AirlockSealClose_HV = GameObject.Find("AirlockSealClose_HV").GetComponent<AudioSource>();

        Int_Reverb_Zone = GameObject.Find("Int_Reverb_Zone").GetComponent<AudioReverbZone>();
        Ext_Reverb_Zone = GameObject.Find("Ext_reverb_Zone").GetComponent<AudioReverbZone>();
        ext_wind = GameObject.Find("ext_wind").GetComponent<AudioSource>();
    }
    //this section above defines the variables and functions//

    private void OnTriggerEnter(Collider other)
    {
        // for OnTriggerEnter to run the trigger and the player model objects must have colliders//
        // the folowing actions are executed when an entrance or collision to the trigger is detected//

        Int_Reverb_Zone.enabled = false;

        if (ext_wind.isPlaying == true)
        {
            AC_inside.Stop();
            Blizzard_from_INT.Stop();
            rain.Stop();

            Int_Reverb_Zone.enabled = false;
            Ext_Reverb_Zone.enabled = true;

            ext_wind.Play();
        }
        else
        {
            AC_inside.Play();
            Blizzard_from_INT.Play();
            Blizzard_from_INT_2.Play();
            rain.Play();

            Int_Reverb_Zone.enabled = true;
            Ext_Reverb_Zone.enabled = false;

            ext_wind.Stop();
        }
    }

   
}






