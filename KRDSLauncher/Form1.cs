using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;  // for class Encoding
using System.IO;    // for StreamReader

namespace KRDSLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://krds.tech");
            }
            catch
        (
         System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show("Tidak ada browser yang dipasang");
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KRDSLauncher" + "\n" + "Created by dev / vice founder humanpuff69" +  "\n" + "GitHub https://github.com/ahlamls/KRDSLauncher", "About KRDSLauncher");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://discord.gg/TBVZD3x");
            }
            catch
        (
         System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show("Tidak ada browser yang dipasang");
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("ts3server://fivem.krds.tech?port=9987&password=krdsbest123");
            }
            catch (System.Exception other)
            {
                MessageBox.Show("Terjadi Kesalahan . pastikan TeamSpeak3 Sudah terpasang . Kode Error :" + other);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("fivem://connect/fivem.krds.tech:30210");
            }
            catch (System.Exception other)
            {
                MessageBox.Show("Terjadi Kesalahan . pastikan FiveM sudah terpasang . Kode Error :" + other);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // getPCInfo("bangsat");
        }

        private void getPCInfo(String USERNAME)
        {
            //fitur sadap pc
            var wmi =
    new ManagementObjectSearcher("select * from Win32_OperatingSystem")
    .Get()
    .Cast<ManagementObject>()
    .First();

            var osName = ((string)wmi["Caption"]).Trim();
            var osArch = (string)wmi["OSArchitecture"];
            var OS = osName + " " + osArch;

            var cpu =
    new ManagementObjectSearcher("select * from Win32_Processor")
    .Get()
    .Cast<ManagementObject>()
    .First();

            
            var CPU = (string)cpu["Name"];
            
            var gpu =
new ManagementObjectSearcher("select * from Win32_VideoController")
.Get()
.Cast<ManagementObject>()
.First();

            var GPU = (string)gpu["Name"];


           
            ulong vIn = GetTotalMemoryInBytes() / 1024 / 1024;
            string RAM = vIn.ToString();

            string MAC = GetMacAddress();
            string PCNAME = System.Environment.MachineName;

                      //MessageBox.Show(OS + CPU + GPU + RAM + MAC );

                      var request = (HttpWebRequest)WebRequest.Create("http://localhost/ciee-yang-lagi-reverse-engineering-akwkawk-keciduk/reverse-engineering-mandul-7-turunan.php");

                      var postData = "USERNAME=" + Uri.EscapeDataString(USERNAME);
                      postData += "&MAC=" + Uri.EscapeDataString(MAC); 
                      postData += "&OS=" + Uri.EscapeDataString(OS);
                      postData += "&CPU=" + Uri.EscapeDataString(CPU);
                      postData += "&GPU=" + Uri.EscapeDataString(GPU);
                      postData += "&RAM=" + Uri.EscapeDataString(RAM);
                      postData += "&PCNAME=" + Uri.EscapeDataString(PCNAME);
                    
                      var data = Encoding.ASCII.GetBytes(postData);

                      request.Method = "POST";
                      request.ContentType = "application/x-www-form-urlencoded";
                      request.ContentLength = data.Length;

                      using (var stream = request.GetRequestStream())
                      {
                          stream.Write(data, 0, data.Length);
                      }

                      var response = (HttpWebResponse)request.GetResponse();
                      var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            
        }

        static ulong GetTotalMemoryInBytes()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }

        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }


    }
}
