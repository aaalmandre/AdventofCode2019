using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication3
{
    public static class segmentIntersection
    {
       public static Point GetIntersection(Point segment1p, Point segment1q, Point segment2r, Point segment2s)
        {
            int segment1LeftX;
            int segment1RightX;
            int segment1UpY;
            int segment1DownY;

            int segment2LeftX;
            int segment2RightX;
            int segment2UpY;
            int segment2DownY;

            //segment1 x coordinates
            if (segment1p.x < segment1q.x)
            {
                segment1LeftX = segment1p.x;
                segment1RightX = segment1q.x;
            }
            else
            {
                segment1LeftX = segment1q.x;
                segment1RightX = segment1p.x;
            }
            //segment1 y coordinates
            if (segment1p.y < segment1q.y)
            {
                segment1DownY = segment1p.y;
                segment1UpY = segment1q.y;
            }
            else
            {
                segment1DownY = segment1q.y;
                segment1UpY = segment1p.y;
            }

            //segment2 x coordinates
            if (segment2r.x < segment2s.x)
            {
                segment2LeftX = segment2r.x;
                segment2RightX = segment2s.x;
            }
            else
            {
                segment2LeftX = segment2s.x;
                segment2RightX = segment2r.x;
            }
            //segment2 y coordinates
            if (segment2r.y < segment2s.y)
            {
                segment2DownY = segment2r.y;
                segment2UpY = segment2s.y;
            }
            else
            {
                segment2DownY = segment2s.y;
                segment2UpY = segment2r.y;
            }

            if ((segment1LeftX <= segment2RightX && segment1RightX >= segment2LeftX) && (segment1UpY >= segment2DownY && segment1DownY <= segment2UpY))
            {
                int x;
                int y;
                if (segment1LeftX == segment1RightX)
                {
                    x = segment1LeftX;
                }
                else 
                {
                    x = segment2LeftX;
                }
                if (segment1DownY == segment1UpY)
                {
                    y = segment1DownY;
                }
                else
                {
                    y = segment2DownY;
                }
                //intersection
                return new Point(x, y);
            }
            else 
            {
                return new Point();
            }
        }
    }
}
