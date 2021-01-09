using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TELEGRAM_INVITER.Services
{
    public class ImportDataService
    {
        public async Task<List<String>> ImportData(Boolean IsLiteral = false)
        {
            try
            {
                OpenFileDialog sfd = new OpenFileDialog();

                sfd.RestoreDirectory = true;
                sfd.Filter = "Текстовый файл(*.txt)|*.txt";
                sfd.FilterIndex = 0;
                sfd.SupportMultiDottedExtensions = false;

                List<String> list = new List<string>();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(File.Open(sfd.FileName, FileMode.Open)))
                    {
                        string line;

                        while ((line = await sr.ReadLineAsync()) != null)
                        {
                            if (!String.IsNullOrWhiteSpace(line))
                            {
                                if (IsLiteral)
                                {
                                    if(line[0] != '@')
                                    {
                                        line = "@" + line;
                                    }
                                }

                                list.Add(line);
                            }   
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                LogViewer.WriteLog("Ошибка при импорте данных. Дополнительные сведения смотреть в Logs");
                throw new Exception(ex.Message);
            }
        }
    }
}
