using Newtonsoft.Json;
using Shared.Models;
using Shared.Services;
using SharedLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Tests
{
    public class FileServiceTests
    {
        [Fact]
        public void SaveTofile_ShouldSaveStringToJsonFile() // is there even a point to do all the json stuff i mean i could just save a string to a file and then load it back up
        {
            // Arrange
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "ProductDataTestSave.json");
            var _fileService = new FileService(filePath);

            string content = "This is a test string";

            // Act

            _fileService.SaveToFile(content);
            content = "";
            using StreamReader sr = new StreamReader(filePath);
            content = sr.ReadToEnd();
            sr.Close();

            // Assert
            Assert.Equal("This is a test string", content);
            
        }
        [Fact]
        public void LoadTofile_ShouldLoadStringFromJsonFile()
        {
            // Arrange
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "ProductDataTestLoad.json");
            var _fileService = new FileService(filePath);

            string content = "This is the test string";

            // Act
            using StreamWriter sw = new StreamWriter(filePath);
            sw.Write(content);
            sw.Close();
            content = "Wrong";

            content = _fileService.GetFromFile();

            // Assert
            Assert.Equal("This is the test string", content);
        }
    }

}
