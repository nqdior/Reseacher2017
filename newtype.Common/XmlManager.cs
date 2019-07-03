using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace newtype.Common
{
    public class XmlManager
    {
        private readonly FileStream _filestream;

        private readonly XDocument _xml;

        private const string parentNode = "newtype";

        public XmlManager(bool isDispose = true, string FileName = "Reseacher.config")
        {
            string FilePath = Application.StartupPath + @"\" + FileName;
            var windowFile = Path.Combine(FilePath);

            try
            {
                var attrs = File.GetAttributes(windowFile);
                File.SetAttributes(windowFile, attrs & ~FileAttributes.ReadOnly);
            }
            catch { /* ignore */ }

            try
            {
                _filestream = new FileStream(windowFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                _xml = XDocument.Load(_filestream);

                if (isDispose) Dispose();
            }
            catch (Exception ex) when (ex is XmlException || ex is InvalidOperationException)
            {
                if (_filestream.CanWrite || _filestream.CanRead)
                {
                    _filestream.Dispose();
                    Console.Write(ex.Message);
                }
            }
            catch (Exception ex)
            {
                if (_filestream.CanWrite || _filestream.CanRead)
                {
                    _filestream.Dispose();
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public string this[List<string> Keys, string defValue = ""]
        {
            get
            {
                try
                {
                    var node = _xml.Elements("newtype").FirstOrDefault();

                    foreach (var key in Keys)
                    {
                        node = node.Elements(key).FirstOrDefault();
                        if (node == null) throw new Exception();
                    }
                    return node.Value;
                }
                catch { return defValue; }
            }

            set
            {
                try
                {
                    var node = _xml.Elements("newtype").FirstOrDefault();

                    foreach (var key in Keys)
                    {
                        node = node.Elements(key).FirstOrDefault();
                    }
                    node.Value = value;
                }
                catch { /* ignore */ }
            }
        }


        public void Save()
        {
            _filestream.SetLength(0);

            using (var sr = new StreamWriter(_filestream))
            {
                sr.Write(_xml);
            }
        }


        public void Dispose()
        {
            _filestream.Dispose();
        }
    }
}
