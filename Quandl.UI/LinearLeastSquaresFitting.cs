using System.Linq;

namespace Quandl.UI {
  public class LinearLeastSquaresFitting {
    public static void Calculate(double[] dataPoints, out double a1, out double a0) {
      int n = dataPoints.Length;
      double sx = ((n - 1) * n) / 2.0;
      double sy = 0.0;
      double sxy = 0.0;
      double sxx = 0.0;

      for (int i = 0; i < n; i++) {
        sxy += i * dataPoints[i];
        sxx += i * i;
        sy += dataPoints[i];
      }

      double avgy = sy / n;
      double avgx = sx / n;
      a1 = (sxy - (n * avgx * avgy)) / (sxx - (n * avgx * avgx));
      a0 = avgy - a1 * avgx;
    }
  }
}
