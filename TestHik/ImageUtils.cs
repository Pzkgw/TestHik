﻿


using System.Drawing;
using System.IO;

class ImageUtils
{
    public static Image byteArrayToImage(byte[] byteArrayIn)
    {
        Image returnImage = null;
        try
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            returnImage = Image.FromStream(ms, true);
        }
        catch { }
        return returnImage;
    }

    public static unsafe void YUV2RGBManaged(byte* pYUVs, ref byte[] RGBData, int width, int height)
    {
        //returned pixel format is 2yuv - i.e. luminance, y, is represented for every pixel and the u and v are alternated
        //like this (where Cb = u , Cr = y)
        //Y0 Cb Y1 Cr Y2 Cb Y3 

        /*
         C = 298 * (Y - 16) + 128
         D = U - 128
         E = V - 128
         R = clip(( C           + 409 * E) >> 8)
         G = clip(( C - 100 * D - 208 * E) >> 8)
         B = clip(( C + 516 * D          ) >> 8)

         * here are a whole bunch more formats for doing this...
        
         */


        fixed (byte* pRGBs = RGBData)//, pYUVs = YUVData)
        {
            for (int r = 0; r < height; r++)
            {
                byte* pRGB = pRGBs + r * width * 3;
                byte* pYUV = pYUVs + r * width * 2;

                //process two pixels at a time
                for (int c = 0; c < width; c += 2)
                {
                    int C1 = 298 * (pYUV[1] - 16) + 128;
                    int C2 = 298 * (pYUV[3] - 16) + 128;
                    int D = pYUV[2] - 128;
                    int E = pYUV[0] - 128;

                    int R1 = (C1 + 409 * E) >> 8;
                    int G1 = (C1 - 100 * D - 208 * E) >> 8;
                    int B1 = (C1 + 516 * D) >> 8;

                    int R2 = (C2 + 409 * E) >> 8;
                    int G2 = (C2 - 100 * D - 208 * E) >> 8;
                    int B2 = (298 * C2 + 516 * D) >> 8;

                    //check for overflow
                    //unsurprisingly this takes the bulk of the time.
                    pRGB[0] = (byte)(R1 < 0 ? 0 : R1 > 255 ? 255 : R1);
                    pRGB[1] = (byte)(G1 < 0 ? 0 : G1 > 255 ? 255 : G1);
                    pRGB[2] = (byte)(B1 < 0 ? 0 : B1 > 255 ? 255 : B1);

                    pRGB[3] = (byte)(R2 < 0 ? 0 : R2 > 255 ? 255 : R2);
                    pRGB[4] = (byte)(G2 < 0 ? 0 : G2 > 255 ? 255 : G2);
                    pRGB[5] = (byte)(B2 < 0 ? 0 : B2 > 255 ? 255 : B2);

                    pRGB += 6;
                    pYUV += 4;
                }
            }
        }
    }
}