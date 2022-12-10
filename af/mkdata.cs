
using System;
using System.IO;
using System.Collections.Generic;

namespace CamBiometrics
{

  public class testsyntheticheartbeat
  {

    public static void writedatatonewCsv()
    {
      DateTime dt = DateTime.Now;

      string newestcvssvsvs=  dt.ToShortTimeString()+" 69/n";

      int maxcap = 5000;// when to stop int
      int someBpm = 69;
      for (int i= 0; i < maxcap ; i++)
      {
        if(Random.Next( -1,  1)>0)
          {
          someBpm +=  1;
          }
          else
          {
          someBpm +=  -1;
          }
        string addthis = dt.ToShortTimeString() + " " + someBpm.ToString() + "\n";
        newestcvssvsvs +=addthis;
      }
      //file write
      string filename = "synthBPM" +dt.ToShortTimeString()+".txt";
      File.WriteAllLines(filename, newestcvssvsvs);
        //ExampleAsync(filename, newestcvssvsvs);
        //todo
    }
/*
    public async ExampleAsync(string filename, string filecontent)
      {
        await File.WriteAllLinesAsync(filename, filecontent);
      }*/

 }
}
