using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMODUL6_1302210135
{
    internal class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Contract.Requires(title != null, "Judul video tidak boleh null");
            Contract.Requires(title.Length <= 100, "Judul video memiliki panjang maksimal 100 karakter");

            this.id = new Random().Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            Contract.Requires(count >= 0 && count <= 10000000, "Input penambahan play count maksimal 10.000.000 per panggilan method");

            try
            {
                checked
                {
                    playCount += count;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Play count: " + playCount);
        }

        static void Main(string[] args)
        {
            try
            {
                SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract — [NAMA_PRAKTIKAN]");

                video.IncreasePlayCount(-1); 
                video.IncreasePlayCount(10000001); 

                for (int i = 0; i < 1000000000; i++)
                {
                    video.IncreasePlayCount(1); 
                }

                video.PrintVideoDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

