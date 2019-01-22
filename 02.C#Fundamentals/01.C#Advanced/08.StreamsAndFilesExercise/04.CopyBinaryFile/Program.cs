using System;
using System.IO;

class CopyBinaryFile
{
    const string imgPath = "../../copyMe.png";
    const string resultPath = "../../result.txt";

    static void Main()
    {
        using (var source = new FileStream(imgPath, FileMode.Open))
        {
            using (var destination = new FileStream(resultPath, FileMode.Create))
            {
                byte[] buffer = new byte[source.Length];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }

                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}