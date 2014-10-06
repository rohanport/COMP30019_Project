using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Toolkit;

namespace BallFall
{
    class ScrollingWall
    {
        private static int wallWidth = 10; //Wall width in blocks
        private static int wallHeight = 8; //Wall height in platforms
        private static int platformSpacing = 2; //Number of blocks between each platform

        private double gapMean; //The mean number of missing blocks per platform
        private double gapStdDev; //The standard deviation of the number of missing blocks per platform
        private double gapIndexMean; //The mean index of missing blocks per platform
        private double gapIndexStdDev; //The standard deviation of the index of missing blocks per platform

        private List<Block[]> blockRows;
        Random rand;
        StringBuilder debug;

        public ScrollingWall()
        {
            blockRows = new List<Block[]>();
            rand = new Random(); //reuse this if you are generating many random numbers
            debug = new StringBuilder();

            gapMean = 1.0;  
            gapStdDev = 0.7;
            gapIndexMean = wallWidth / 4;
            gapIndexStdDev = 0.8;

            //Add the first rows to the wall
            for (int i = 0; i < wallHeight; i++) blockRows.Add(newBlockRow());
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }

        private void AddNewRow()
        {
            blockRows.Remove(blockRows[0]);
            blockRows.Add(newBlockRow());
        }

        private Block[] newBlockRow()
        {
            Block[] row = new Block[wallWidth];
            
            //Get number of gaps
            int gaps = (int)(getRandomNormal(gapMean, gapStdDev) + 0.5);
            if(gaps > wallWidth) gaps = wallWidth;
            else if (gaps < 1) gaps = 1;

            //Get which indexes will be gaps
            for (int i = 0; i < gaps; i++)
            {
                int gapIndex = (int)(getRandomNormal(gapIndexMean, gapIndexStdDev) + 0.5);
                if (gapIndex >= wallWidth) gapIndex = wallWidth - 1;
                else if (gapIndex < 0) gapIndex = 0;
                row[gapIndex] = null;
            }

            //Fill the row with blocks
            for (int i = 0; i < wallWidth; i++)
            {
                if (row[i] != null) row[i] = new Block();
            }

            //Update means and std devs
            gapMean += 0.1;
            gapStdDev += 0.01;
            gapIndexMean *= -1;
            gapIndexStdDev += 0.01;
            
            return row;
        }

        //Courtesy of StackOverflow user "yoyoyoyosef": http://stackoverflow.com/users/25571/yoyoyoyosef
        private double getRandomNormal(double mean, double stdDev)
        {
            double v1;//these are uniform (0,1) random doubles
            double v2;

            v1 = rand.NextDouble();
            v2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(v1)) * Math.Sin(2.0 * Math.PI * v2); //random normal(0,1)

            double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
            
            return randNormal;
        }

        //Prints the scrolling wall to the console
        public void print(string filePath)
        {

            debug.AppendLine("gapMean = " + gapMean);
            debug.AppendLine("gapStdDev = " + gapStdDev);
            debug.AppendLine("gapIndexMean = " + gapIndexMean);
            debug.AppendLine("gapIndexStdDev = " + gapIndexStdDev);
            for (int i = 0; i < wallHeight; i++)
            {
                for (int j = 0; j < wallWidth; j++)
                {
                    if (blockRows[i][j] == null) debug.Append("  ");
                    else debug.Append("__");
                }
                debug.AppendLine();
                for (int k = 0; k < platformSpacing; k++)
                {
                    debug.AppendLine();
                }
            }

            debug.Append("The End\n");
            System.IO.File.WriteAllText(filePath, debug.ToString());
        }
    }
}
