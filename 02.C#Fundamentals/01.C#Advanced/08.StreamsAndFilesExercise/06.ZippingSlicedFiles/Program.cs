﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

internal class ZippingSlicedFiles
{
    private static List<string> files = new List<string>();
    private static MatchCollection matches;
    private static void Main()
    {
        string inputFile = @"../../sliceMe.mp4";
        string folderPath = @"../../";
        int NumberOfParts = 5;

        Slice(inputFile, folderPath, NumberOfParts);

        Assemble(files, folderPath);
    }

    private static void Assemble(List<string> files, string destinationDirectory)
    {
        string fileOutputPath = destinationDirectory + "assembled" + "." + matches[0].Groups[2];
        var fsSource = new FileStream(fileOutputPath, FileMode.Create);

        fsSource.Close();
        using (fsSource = new FileStream(fileOutputPath, FileMode.Append))
        {
            foreach (var filePart in files)
            {
                using (var partSource = new FileStream(filePart, FileMode.Open))
                {
                    using (var compressionStream = new GZipStream(partSource, CompressionMode.Decompress, false))
                    {
                        Byte[] bytePart = new byte[4096];
                        while (true)
                        {
                            int readBytes = compressionStream.Read(bytePart, 0, bytePart.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            fsSource.Write(bytePart, 0, readBytes);
                        }
                    }
                }
            }
        }
    }

    private static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        using (var source = new FileStream(sourceFile, FileMode.Open))
        {
            long partSize = (long)Math.Ceiling((double)source.Length / parts);

            // The offset at which to start reading from the source file
            long fileOffset = 0;
            ;
            string currPartPath;
            FileStream fsPart;
            long sizeRemaining = source.Length;

            // extracting name and extension of the input file
            string pattern = @"(\w+)(?=\.)\.(?<=\.)(\w+)";
            Regex pairs = new Regex(pattern);
            matches = pairs.Matches(sourceFile);
            for (int i = 0; i < parts; i++)
            {
                currPartPath = destinationDirectory + matches[0].Groups[1] + String.Format(@"-{0}", i) + "." + "gz";
                files.Add(currPartPath);

                // reading one part size
                using (fsPart = new FileStream(currPartPath, FileMode.Create))
                {
                    using (var compressionStream = new GZipStream(fsPart, CompressionMode.Compress, false))
                    {
                        long currentPieceSize = 0;
                        byte[] buffer = new byte[4096];
                        while (currentPieceSize < partSize)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            // creating one part size file
                            compressionStream.Write(buffer, 0, readBytes);
                            currentPieceSize += readBytes;
                        }
                    }
                }

                // calculating the remaining file size which iis still too be read
                sizeRemaining = (int)source.Length - (i * partSize);
                if (sizeRemaining < partSize)
                {
                    partSize = sizeRemaining;
                }
                fileOffset += partSize;
            }
        }
    }
}