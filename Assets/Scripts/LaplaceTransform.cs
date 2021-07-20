using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

public class LaplaceTransform : MonoBehaviour
{
    [SerializeField] GameManager GameManager;

    public delegate double FunctionDelegate(double t);
    static double[] V;       //  Stehfest coefficients
    static double ln2;       //  log of 2
    const int DefaultStehfestN = 14;
    double function;

    static LaplaceTransform()
    {
        InitStehfest(DefaultStehfestN);
    }

    public List<double> GeneratePositionArray(List<double> TimeArray)
    {
        // pass t array into inverse laplace
        List<double> Position = new List<double>();
        for (int i = 0; i < TimeArray.Count; i++)
        {
            Position.Add(InverseTransform(f, TimeArray[i]));
        }
        return Position;
    }

    public List<double> GenerateTimeArray(float t_startf, float t_stepf, float t_endf)
    {      
        // original t values
        /*double t_start = 0.01f;
        double t_end = 2f;
        double t_step = .05f;*/

        double t_start = double.Parse(t_startf.ToString());
        double t_step = double.Parse(t_stepf.ToString());
        double t_end = double.Parse(t_endf.ToString());


        if (t_start <= 0)
        {
            Debug.Log("t_start should not be 0. Reset to .01");
            t_start = .01f;
        }

        double temp = t_start;
        List<double> time = new List<double>();
        while(temp < t_end)
        {
            time.Add(temp);
            temp += t_step;
        }

        return time;
    }

    double f(double s)
    {
        return 0;
        //return GameManager.GetTransferFunction(s);
    }

    // f is an instance of FunctionDelegate
    public double InverseTransform(FunctionDelegate f, double t)
    {
        double ln2t = ln2 / t;
        double x = 0;
        double y = 0;
        for (int i = 0; i < V.Length; i++)
        {
            x += ln2t;
            y += V[i] * f(x);
        }
        return ln2t * y;
    }

    public static double Factorial(int N)
    {
        double x = 1;
        if (N > 1)
        {
            for (int i = 2; i <= N; i++)
                x = i * x;
        }
        return x;
    }

    public static void InitStehfest()
    {
        InitStehfest(DefaultStehfestN);
    }

    // Initial conditions for numerical approximation
    public static void InitStehfest(int N)
    {
        ln2 = Math.Log(2.0);
        int N2 = N / 2;
        int NV = 2 * N2;
        V = new double[NV];
        int sign = 1;
        if ((N2 % 2) != 0)
            sign = -1;
        for (int i = 0; i < NV; i++)
        {
            int kmin = (i + 2) / 2;
            int kmax = i + 1;
            if (kmax > N2)
                kmax = N2;
            V[i] = 0;
            sign = -sign;
            for (int k = kmin; k <= kmax; k++)
            {
                V[i] = V[i] + (Math.Pow(k, N2) / Factorial(k)) * (Factorial(2 * k)
                    / Factorial(2 * k - i - 1)) / Factorial(N2 - k) / Factorial(k - 1)
                    / Factorial(i + 1 - k);
            }
            V[i] = sign * V[i];
        }
    }
}
