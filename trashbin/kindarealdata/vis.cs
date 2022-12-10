using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CamBiometrics
{

  public class testCurves
  {
    public static Bitmap CrackheadForData1()
    {
      Color cca = Color.FromName("DarkGreen");
      Color ccb = Color.FromName("WhiteSmoke");

      string[] alllines = File.ReadAllLines("realdata\\data1.txt");
      //int width = alllines.Length;
      Console.WriteLine("sample count" + width);
      //analysis min max for image height without any squash
      //int height=100;//default value for image height
      int[] bpmvalues = new int[alllines.Length];
      int[] timeValues = new int[alllines.Length];



















      for(int i = 0 ; i < alllines.Length ; i ++)
      {
        //"12:57:00.176 -> 63"
        //alllines[i];

        int hour = alllines[i][0]*10+alllines[i][1];
        int minute = alllines[i][3]*10+alllines[i][4];
        int second = alllines[i][6]*10+alllines[i][7];
        int millis = alllines[i][9]*100+alllines[i][10]*10+alllines[i][11];
        int totalmillis = millis + second*1000  + minute*60*1000 + hour*60*60*1000;
        timeValues[i] = totalmillis;

        string[] splat = alllines[i].Split('>');

        //bpmvalues[i] = int.TryParse(splat[splat.Length-1]);
        bool success = int.TryParse(splat[splat.Length-1], out bpmvalues[i]);
        if (success == false)
        {
           Console.WriteLine("Converted "+splat[splat.Length-1]+" to "+ bpmvalues[i]);
        }
        else
        {
          bpmvalues[i] = 0;
          Console.WriteLine("Attempted conversion of " + splat[splat.Length-1] + "?? <null> failed.");
        }
        //pasted again
        /*
        foreach (var value in values)
        {
         int number;

         bool success = int.TryParse(value, out number);
         if (success)
         {
            Console.WriteLine($"Converted '{value}' to {number}.");
         }
         else
         {
            Console.WriteLine($"Attempted conversion of '{value ?? "<null>"}' failed.");
         }
       }
       */
        //pasted end


        if (i< 10) {
          string testword = "";

          for (int it = 0 ; it < alllines[i].Length ; it++ )
          {
            testword += alllines[i][it]+" ";
          }


        }
      }
      //cleaning data
      //find
      int[] badvaluesl= new int[0];
      for(int i = 0; i < bpmvalues.Length; i++)
      {
        if (bpmvalues[i]== 0 )
        {
          badvaluesl = extendint(badvaluesl,i);
        }
      }

      //remove
      int [] bpmvaluescleaned = new int[bpmvalues.Length - badvaluesl.Length];
      int [] timevaluescleaned = new int[bpmvalues.Length - badvaluesl.Length];

      int writeIndex = 0 ;

      for(int i = 0 ; i < bpmvalues.Length ;  i ++ )
      {
        Console.WriteLine("debugin contains is "+ ( badvaluesl.Contains(i)  )  );
        if(badvaluesl.Contains(i) == false )
        {
          //only add the good values to the cleaned version
          bpmvaluescleaned[writeIndex] = bpmvalues[i];
          timevaluescleaned[writeIndex] = timeValues[i];
          writeIndex++;
        }
      }
      Console.WriteLine("i has "+bpmvaluescleaned.Length+ " data points");
      if(bpmvaluescleaned.Length != timevaluescleaned.Length)
      {
        Console.WriteLine("Test data clean method Bad");
      }
      else
      {
        Console.WriteLine("data clean pass");
      }

      int bpmminvalue = 100;
      int bpmmaxvalue = 10;

      width = bpmvaluescleaned.Length;
      for(int i = 0 ; i < bpmvaluescleaned.Length ; i++)
      {
        if (bpmvaluescleaned[i]>bpmmaxvalue)
        {
          bpmmaxvalue = bpmvaluescleaned[i];
        }
        if (bpmvaluescleaned[i]<bpmminvalue)
        {
          bpmminvalue = bpmvaluescleaned[i];
        }
      }

      Console.WriteLine("Lowest BPM point " + bpmminvalue +"-\t- hightest :"+bpmmaxvalue);
      height = bpmmaxvalue - bpmminvalue;

      var bmp  = new Bitmap(width, height);
      {
        //background
        for (var y = 0; y < bmp.Height; y++)
        for (var x = 0; x < bmp.Width; x++)
        {
            bmp.SetPixel(x, y , cca);
        }

      }

      return bmp;
    }

    private static int[] extendint(int[] arr, int extraval)
    {
      int[] arrr = new int[arr.Length+1];

      for (int i =0; i<arr.Length; i++)
      {
        arrr[i] = arr[i] ;
      }
      arrr[arr.Length] = extraval;

      return arrr;
    }



  }
}
