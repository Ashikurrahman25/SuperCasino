using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{


    
//    //public Button[] Buttons;


//    //public float[] waitTimes;
//    //public float[] EffectiveTimes;
//    //public bool[] isReadytoUse;
//    //public PlateSpawner[] plateSpawners;
//    //public Text[] CountdownText;  
//    //void Start()
//    //{

//    //    EffectiveTimes = new float[Buttons.Length];
//    //    isReadytoUse = new bool[Buttons.Length];
       
//    //}

   
//    //void Update()
//    //{


       

//    //    if (waitTimes[0] <= 0)
//    //    {
//    //        Buttons[0].interactable = true;
//    //        CountdownText[0].enabled = false;
//    //        isReadytoUse[0] = true;              
//    //    }
//    //    else
//    //    {

//    //        Buttons[0].interactable = false;
//    //        CountdownText[0].text = waitTimes[0].ToString("0");           
//    //        waitTimes[0] -= Time.deltaTime;
//    //    }






//        //if (waitTimes[1] <= 0)
//        //{
//        //    Buttons[1].interactable = true;
//        //    CountdownText[1].enabled = false;
//        //    isReadytoUse[1] = true;              
//        //}
//        //else
//        //{
//        //    Buttons[1].interactable = false;
//        //    CountdownText[1].text = waitTimes[1].ToString("0");         
//        //    waitTimes[1] -= Time.deltaTime;
//        //}





//        //Effective Timer

//    //    if (EffectiveTimes[0]>0)
//    //    {
//    //        EffectiveTimes[0] -= Time.deltaTime;          
            
//    //    }
//    //    else
//    //    {

//    //        plateSpawners[0].Direction = 1f;
//    //        plateSpawners[1].Direction = -1f;
//    //        plateSpawners[0].waitTime = plateSpawners[1].waitTime = 2f;

//    //        for (int i = 0; i < plateSpawners[0].SpawnedPlate.Count; i++)
//    //        {
//    //            if (plateSpawners[0].SpawnedPlate[i] != null)
//    //            {

//    //                plateSpawners[0].SpawnedPlate[i].GetComponent<PointPlate>().Dir = 1f;
//    //            }

//    //        }
//    //        for (int i = 0; i < plateSpawners[1].SpawnedPlate.Count; i++)
//    //        {
//    //            if (plateSpawners[1].SpawnedPlate[i] != null)
//    //            {

//    //                plateSpawners[1].SpawnedPlate[i].GetComponent<PointPlate>().Dir = -1f;
//    //            }


//    //        }


//    //    }
               


//    //}




//    public void IcyPower()
//    {
//        if (isReadytoUse[0])
//        {
           
//            EffectiveTimes[0] = 6;
          

//           //main slowDown

//            plateSpawners[0].Direction = 0.4f;
//            plateSpawners[1].Direction = -0.4f;
//            plateSpawners[0].waitTime = plateSpawners[1].waitTime = 5f;

//            for (int i = 0; i < plateSpawners[0].SpawnedPlate.Count; i++)
//            {
//                if (plateSpawners[0].SpawnedPlate[i] !=null)
//                {
                 
//                    plateSpawners[0].SpawnedPlate[i].GetComponent<PointPlate>().Dir = 0.4f;
//                }
              
               
//            }
//         for (int i = 0; i < plateSpawners[1].SpawnedPlate.Count; i++)
//            {
//                if (plateSpawners[1].SpawnedPlate[i] !=null)
//                {
                 
//                    plateSpawners[1].SpawnedPlate[i].GetComponent<PointPlate>().Dir = -0.4f;
//                }
              
               
//            }
       
//            waitTimes[0] = 5;
//            isReadytoUse[0] = false;
//        }
      
//    }
//    public void X2Power()
//    {
//        if (isReadytoUse[1])
//        {
           
//            EffectiveTimes[1] = 10;
       
//            waitTimes[1] = 8;
//            isReadytoUse[1] = false;
//        }
      
//    } 


  
}
