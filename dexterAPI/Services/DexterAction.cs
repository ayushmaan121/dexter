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
            MakeUIFileChanges(parentPath+frontEndAppName);
            //MakeBackEndFileChanges();
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

        private void MakeUIFileChanges(string folderPath)
        {
            DirectoryInfo frontEndFolder = new DirectoryInfo(folderPath);
            DirectoryInfo[] childFrontEndFolders = frontEndFolder.GetDirectories();
            FileInfo[] files = frontEndFolder.GetFiles();
            foreach(FileInfo file in files)
            {
                if(file.Name == "app-service.service.ts")
                {
                    UpdateFile(file.FullName, "Organijation Name", "Optum");
                    UpdateFile(file.FullName, "Org Name - All Right Reserved", "Optum");
                }
                if (file.Name == "app.module.ts")
                {


                }
                if (file.Name == "app.component.html")
                {

                }
                UpdateFile(file.FullName, "dummyapp", "NewName");

            }
            foreach (DirectoryInfo subdir in childFrontEndFolders)
            {
                MakeUIFileChanges(subdir.FullName);
                
            }

        }
        private void MakeHeaderChanges(string filePath, string headerName)
        {
            string text = File.ReadAllText(filePath);
            text = text.Replace("Organijation Name", headerName);
            File.WriteAllText(filePath, text);

        }
        private void MakeFooterChanges(string filePath, string footerText)
        {
            string text = File.ReadAllText(filePath);
            text = text.Replace("Org Name - All Right Reserved", footerText);
            File.WriteAllText(filePath, text);
        }
        private void UpdateFile(string filePath, string placeholderText, string userInput)
        {
            string text = File.ReadAllText(filePath);
            text = text.Replace(placeholderText, userInput);
            File.WriteAllText(filePath, text);
        }
    }
}
