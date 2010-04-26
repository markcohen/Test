﻿using GitTest.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitTests
{
    [TestClass()]
    public class ByteExtensionsTest
    {
        public TestContext TestContext { get; set; }

        private static readonly byte[] bData = new byte[256];

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            for (int i = 0; i < bData.Length; i++)
            {
                bData[i] = (byte)i;
            }
        }

        [TestMethod]
        public void GetBase64StringTest()
        {
            const string expected =
                "AAECAwQFBgcICQoLDA0ODxAREhMUFRYXGBkaGxwdHh8gISIjJCUmJygpKissLS4v" +
                "MDEyMzQ1Njc4OTo7PD0+P0BBQkNERUZHSElKS0xNTk9QUVJTVFVWV1hZWltcXV5f" +
                "YGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6e3x9fn+AgYKDhIWGh4iJiouMjY6P" +
                "kJGSk5SVlpeYmZqbnJ2en6ChoqOkpaanqKmqq6ytrq+wsbKztLW2t7i5uru8vb6/" +
                "wMHCw8TFxsfIycrLzM3Oz9DR0tPU1dbX2Nna29zd3t/g4eLj5OXm5+jp6uvs7e7v" +
                "8PHy8/T19vf4+fr7/P3+/w==";
            string actual = bData.GetBase64String();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHexStringTest()
        {
            const string expected =
                "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f" +
                "202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f" +
                "404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f" +
                "606162636465666768696a6b6c6d6e6f707172737475767778797a7b7c7d7e7f" +
                "808182838485868788898a8b8c8d8e8f909192939495969798999a9b9c9d9e9f" +
                "a0a1a2a3a4a5a6a7a8a9aaabacadaeafb0b1b2b3b4b5b6b7b8b9babbbcbdbebf" +
                "c0c1c2c3c4c5c6c7c8c9cacbcccdcecfd0d1d2d3d4d5d6d7d8d9dadbdcdddedf" +
                "e0e1e2e3e4e5e6e7e8e9eaebecedeeeff0f1f2f3f4f5f6f7f8f9fafbfcfdfeff";
            string actual = bData.GetHexString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetStringTest()
        {
            const string expected =
                "\0\a\b\t\n\v\f\r !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMN" +
                "OPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~�������������" +
                "��������������������������������������������������������" +
                "��������������������������������������������������������" +
                "���";
            string actual = bData.GetString();
            Assert.AreEqual(expected, actual);
        }
    }
}
