using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CamBiometrics
{

  public class testCurves1
  {
    public static void CrackheadForData2()
    {
      Color cca = Color.FromName("DarkGreen");
      Color ccb = Color.FromName("WhiteSmoke");

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
        Array.Resize(ref timeValues, indexwhereput);




        int bpmminvalue = 100;
        int bpmmaxvalue = 10;

        int width = bpmvalues.Length;
        for(int i = 0 ; i < bpmvalues.Length; i++)
        {
          if (bpmvalues[i]>bpmmaxvalue)
          {
            bpmmaxvalue = bpmvalues[i];
          }
          if (bpmvalues[i]<bpmminvalue)
          {
            bpmminvalue = bpmvalues[i];
          }
        }
        int height = bpmmaxvalue - bpmminvalue;


        int susitarimas = 1920;// nes toks gerai ziurisi
        double step = 1920.0 / width;
        var bmp  = new Bitmap(susitarimas, height);
        {
          //background
          for (var y = 0; y < bmp.Height; y++)
          for (var x = 0; x < bmp.Width; x++)
          {
              bmp.SetPixel(x, y , cca);
          }
        }
        //put points
        for(int i = 1 ; i<bpmvalues.Length ; i++)
        {

        }




      }
  }
}
