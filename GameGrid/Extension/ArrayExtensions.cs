using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Extension
{
    public static class ArrayExtensions
    {

        public static void FillWithDefault<T>(this T[,] array, T defaultValeu)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = defaultValeu;
                }
            }
        }

        public static void FillWithDefault<T>(this T[,] array, Func<int, int, T> function)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = function(x,y);
                }
            }
        }

        

        public static void FillWithDefault<T>(this T[] array, T defaultVale)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = defaultVale;
            }
        }


        public static void FillWithDefault<T>(this T[] array, Func<int, T> function)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = function(i);
            }
        }

        public static void FillWithDefault<T>(this T[,] array) where T : class, new()
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = new T();
                }
            }
        }
    }


    public static class NodeExtensions
    {
        public static void FillWithDefault<T>(this T[,] array, CCNode container) where T : CCNode, new()
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    T newNode = new T();
                    array[x, y] = newNode;
                    container.AddChild(newNode);
                }
            }
        }


        public static void SetPosition<T>(this T[,] array) where T : CCNode
        {
            bool isStarted = false;
            float X = 0;
            float Y = 0;
            float width = 0;
            float height = 0;
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    T node = array[x, y];
                    if (!isStarted)
                    {
                        X = node.PositionX;
                        Y = node.PositionY;
                        width = node.ContentSize.Width;
                        height = node.ContentSize.Width;
                        isStarted = true;
                    }
                    else
                    {
                        node.PositionX += x * width;
                        node.PositionY += y * height;
                    }
                }
            }
        }

        public static void RepositionPosition<T>(this T[,] array, float displacementX, float displacementY) where T : CCNode
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y].PositionX -= displacementX;
                    array[x, y].PositionY -= displacementY;
                }
            }
        }

        public static void RepositionPositionX<T>(this T[,] array, float displacementX) where T : CCNode
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y].PositionX += displacementX;
                }
            }
        }

        public static void RepositionPositionY<T>(this T[,] array, float displacementY) where T : CCNode
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y].PositionY += displacementY;
                }
            }
        }


    }
}
