using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace dexterAPI.Services
{
    public class DexterAction : IDexterAction
    {
        public JsonResult GenerateZip()
        {

            string parentPath = @"C:\Users\asaxen51\Desktop\Github\origGithub\HelloDexter";

            string frontEndPath = @"C:\Users\asaxen51\Desktop\Github\origGithub\dexter\dummyapp";
            string backEndPath = @"C:\Users\asaxen51\Desktop\Github\origGithub\dexter\dummyservice";
            string frontEndAppName = @"\FrontEnd";
            string backEndAppName = @"\BackEnd";
            string resultZipLocation = @"C:\Users\asaxen51\Desktop\Github\origGithub\HelloDexter.zip";

            CreateDirectory(parentPath);
            CopyDirectory(frontEndPath, parentPath + frontEndAppName, true);
            CopyDirectory(backEndPath, parentPath + backEndAppName, true);
            ZipDirectory(parentPath, resultZipLocation);

            return new JsonResult("Zip Generated at Location "+ resultZipLocation);
        }

        private void CreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);


        }
        private void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    // Don't copy Libraries!!
                    if (subdir.Name != "node_modules")
                    {
                        string tempPath = Path.Combine(destDirName, subdir.Name);
                        CopyDirectory(subdir.FullName, tempPath, copySubDirs);
                    }
                }
            }
        }

        private void ZipDirectory(string parentDirectory, string zippedFile)
        {
            ZipFile.CreateFromDirectory(parentDirectory, zippedFile);
        }
    }
}
