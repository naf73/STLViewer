using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace STLViewerTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class FormMainTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OpenModelTest()
        {
            // arrange
            List <string> pathFile = new List<string>();
            int count_face;
            pathFile.Add(Path.Combine(Environment.SpecialFolder.MyDocuments.ToString(), "ModelBase", "Test_parts", "test_cube.stl"));
            STLViewer.FormMain fm = new STLViewer.FormMain(pathFile.ToArray());
            // act
            fm.OpenModel(pathFile[0]);
            count_face = fm.model.Count;
            // assert
            Assert.AreEqual(0,count_face);
        }
    }
}
