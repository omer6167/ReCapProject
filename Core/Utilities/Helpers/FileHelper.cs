﻿using System;
using System.IO;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string Path = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images\CarImages");
        
        
        /// <summary>
        /// return new path from added file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Add(IFormFile file)
        {
            var sourcePath = System.IO.Path.GetTempFileName();

            if (file.Length > 0)
            {
                using var stream = new FileStream(sourcePath, FileMode.Create);
                file.CopyTo(stream);
            }

            var result = NewPath(file);
        

        File.Move(sourcePath, result);

            return result;
        }


        /// <summary>
        /// sourcePath will be deleted,return new path from added file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="sourcePath"></param>
        /// <returns></returns>
        public static string Update(IFormFile file, string sourcePath)
        {
            var result = NewPath(file);

            if (sourcePath.Length > 0)
            {
                using var stream = new FileStream(result, FileMode.Create);
                file.CopyTo(stream);
            }
            File.Delete(sourcePath);

            return result;
        }

        public static IResult Delete(string sourcePath)
        {
            

            if (sourcePath.Length == 0)
            {
                return new ErrorResult();
            }

            File.Delete(sourcePath);


            return new SuccessResult();
        }

        public static string NewPath(IFormFile file)
        {
            //string CurrentPath = @"C:\Users\SKUCUK\source\repos\ReCapProject\Images\CarImages";

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var uniqueFileName = $"{DateTime.Now.Day}_" +
                                 $"{DateTime.Now.Month}_" +
                                 $"{DateTime.Now.Year}_" +
                                 $"_{Guid.NewGuid():B}" +
                                 $"{fileExtension}";

            string result = $@"{Path}\{uniqueFileName}";

            return result;
        }

        //if (!File.Exists(result))
        //{
        //    using (FileStream fs = File.Create(result)) { }

        //}
    }
}