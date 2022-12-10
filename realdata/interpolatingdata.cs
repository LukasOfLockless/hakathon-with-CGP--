using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CamBiometrics
{

  public class interpolatetomakemore
  {
    public static void DataClean()
    {


      string[] alllines = File.ReadAllLines("realdata\\realdata2.txt");
      //int width = alllines.Length;
      Console.WriteLine("sample count" +alllines.Length);
      //analysis min max for image height without any squash
      //int height=100;//default value for image height
      int[] bpmvalues = new int[alllines.Length];
      int[] timeValues = new int[alllines.Length];



      int indexwhereput =0;
      for(int i = 0 ; i < alllines.Length ; i ++)
      {
        //"12:57:00.176 -> 63"
        //alllines[i];


        string[] splat = alllines[i].Split(',');
        if (splat.Length != 2)
        {
          continue;
        }
        //bpmvalues[i] = int.TryParse(splat[splat.Length-1]);

        int timestampas=0;
        int bpm = 0;
        if (! int.TryParse(splat[0], out timestampas) || ! int.TryParse(splat[1], out bpm))
        {

          Console.WriteLine("failed parsing at index " + alllines[i]);
          continue;
        }
        if(bpm == 0 )continue;

        bpmvalues[indexwhereput] = bpm;
        timeValues[indexwhereput] = timestampas;
        indexwhereput++;

        //Console.WriteLine("parsegood");
      }

      Console.WriteLine("gavau toki arr" + bpmvalues.Length);
      /*
      for (int i =0 ; i<indexwhereput; i++)
      {
        Console.WriteLine(  timeValues[i] + "  tada "  + bpmvalues[i] );
      }
      */

        //trunkate
        Array.Resize(ref bpmvalues, indexwhereput);


        int[] bpmvalues = DataRoll(bpmvalues);
        int[] bpmvalues = DataRoll(bpmvalues);
        int[] bpmvalues = DataRoll(bpmvalues);
        int[] bpmvalues = DataRoll(bpmvalues);


      }
    public void DataRoll(int[] arr)
    {
      //rolling avg of 4 nearest points
      int[] arrarr  = new int[arr.Length];

    }

  }
}
