using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using BytesRoad.Net.Ftp;

namespace HuntControl.WebUI.Models
{
    public class FtpFileModel
    {
        FtpClient client;
        int timeOutFtp; // Таймаут
        int ftpPort;
        string ftpUser;
        string ftpPass;

        private void FtpConnetion(string ftpServer, string ftpLogin, string ftpPassword)
        {
            //Сам клиент ФТП
            client = new FtpClient { PassiveMode = true };
            //Задаем параметры
            // Включаем пассивный режим
            timeOutFtp = 30000; // Таймаут
            ftpPort = 21;
            ftpUser = ftpLogin;
            ftpPass = CRPassword.Decrypt(ftpPassword);
            //Подключаемся к FTP серверу
            client.Connect(timeOutFtp, ftpServer, ftpPort);
            client.Login(timeOutFtp, ftpUser, ftpPass);
        }

        public bool FileSave(byte[] uploadImage, string ftpServer, string ftpLogin, string ftpPassword, string ftpFolder, string fileName, string subFolder)
        {
            try
            {
                FtpConnetion(ftpServer, ftpLogin, ftpPassword);
                var dirList = client.GetDirectoryList(timeOutFtp, ftpFolder);
                var folderNotExist = dirList.Count(d => d.Name == subFolder) == 0;
                //Загружаем файл на сервер
                if (folderNotExist)
                    client.CreateDirectory(timeOutFtp, ftpFolder + "/" + subFolder);
                client.PutFile(timeOutFtp, ftpFolder + "/" + subFolder + "/" + fileName, uploadImage);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //отключаемся от FTP сервера
                client.Disconnect(timeOutFtp);
            }
        }

        public byte[] OpenFile(string ftpServer, string ftpLogin, string ftpPassword, string ftpFolder, string fileName, string subFolder)
        {
            try
            {
                FtpConnetion(ftpServer, ftpLogin, ftpPassword);
                //Загружаем файл с сервера
                return client.GetFile(timeOutFtp, ftpFolder + "/" + subFolder + "/" + fileName);
            }
            catch
            {
                return null;
            }
            finally
            {
                //отключаемся от FTP сервера
                client.Disconnect(timeOutFtp);
            }
        }

        public FtpStatusCode RemoveFile(string ftpServer, string ftpLogin, string ftpPassword, string ftpFolder, string fileName, string subFolder)
        {
            try
            {
                FtpConnetion(ftpServer, ftpLogin, ftpPassword);

                //удаляем файл на сервере 
                if (client.GetDirectoryList(timeOutFtp, ftpFolder + "/" + subFolder).Any(d => d.Name == fileName))
                {
                    client.DeleteFile(timeOutFtp, ftpFolder + "/" + subFolder + "/" + fileName);
                    return FtpStatusCode.CommandOK;
                }
                else
                {
                    return FtpStatusCode.FileActionAborted;
                }
            }
            catch (FtpErrorException e)
            {
                return (FtpStatusCode)e.Code;
            }
            finally
            {
                //отключаемся от FTP сервера
                client.Disconnect(timeOutFtp);
            }
        }
    }
}