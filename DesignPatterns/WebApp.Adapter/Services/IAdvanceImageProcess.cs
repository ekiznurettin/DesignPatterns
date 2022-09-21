using System.Drawing;
using System.IO;

namespace WebApp.Adapter.Services
{
    public interface IAdvanceImageProcess
    {
        //  void AddWaterMark(string text, string fileName, Stream imageStream);
        void AddWaterMarkImage(Stream stream,string text, string filePath, Color color, Color outlineColor);
    }
}
