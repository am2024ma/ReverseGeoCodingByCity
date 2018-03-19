using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace ReversGeoCodeByCity
{
    public partial class Form1 : Form
    {
        /*
         * emri i skedarit 
         */
         string naked;

        /*
         *  Skedari i Excel
         */
        private String excelFile;

        /*
         *  Nurmi i rreshtave
         */
        decimal rowCount;

        /*
        *  Nurmi i rreshtave të përpunuar
        */
        decimal processed;

        /*
        *  Nurmi i rreshtave të papërunuar
        */
        decimal unprocessed;

        /*
        *  Përqindja
        */
        decimal percentage;

        /**
         *  Aplikacioni i Excel
         */
        private Microsoft.Office.Interop.Excel.Application xlApp;

        /*
         *Workbook i skedarit Excel 
         */
        private Workbook xlWorkbook;

        /*
         Shtresa në të cilën do të punojmë
             */
        private _Worksheet xlWorksheet;

        /*
         * Rangu në të cilën i qasemi qelizave për të lexuar dhe shkruar.
         */
        private Range xlRange;

        
        public Form1()
        {
            InitializeComponent();
            rowCount = 0;
           
        }

        private void OpenExcel()
        {

    
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
               
               
              
                ofd.Filter = "Excel |*.xls;*.xlsx"; // Filtri për t'i filtruar vetëm skedarët e Excel
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        excelFile = ofd.FileName; // marrja e shtegut të plotë të skedarit të përzgjedhur nga dialogu
                        naked = Path.GetFileNameWithoutExtension(excelFile); // nxjerrja e emrit nga shtegu
                        txtExcel.Text = naked;
                        btnStart.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Proceso( )
        {
            string country = "";
            string city = "";
            int i = 2 ;

            Process.GetCurrentProcess().PriorityBoostEnabled = true; // Aftësimi i përforcimit të prioritetit të procesit aktual
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime; // Caltimi i prioritetit të procesit aktual në RealTime 

            // Of course this only affects the main thread rather than child threads. 
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            if (File.Exists(excelFile)) // kontrollim nëse skedari ekziston, masë parandaluese
                                 // në rast se rastësisht skedari fshihet ose disku ose usb memoria dëmtohet ose largohet.
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();

                //Krimi i objekteve COM. Krijon një objekt COM për çdo gjë që referencohet

                xlWorkbook = xlApp.Workbooks.Open(excelFile);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                rowCount = xlRange.Rows.Count;
                setTotalCount();
                city = "";
                //qarkullimi nëpër rreshta dhe qeliza për lexim dhe shkrim të vlerës sonë të fituar
                //excel nuk është i bazuar nga zero!! i fillon nga 2 që të anashkalohet titulli
                for (i = 2; i <= rowCount - 2; i++)
                {

                    var cell1 = xlRange.Cells[i, 1]; // nxjerrja e të dhënës në formë objekti COM në rreshtin i dhe shtyllën 1
                    city = cell1.Value2.ToString(); // konvertimi i formës COM në string
                    if (city.Length > 0) // Nëse Emërtim i qytetit mungon atëherë anashkalohet
                    {
                        try
                        {
                            country = LookForCountry(city); // Kërkon për emrin e shtetit
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                        if (country.Length > 0)
                        {
                            processed++;

                            unprocessed = rowCount - processed;
                            percentage =  (processed / rowCount);
                        }
                       
                        setProcessed();
                        setUnprocessed();
                        setPercentage();
                        xlRange.Cells[i, 2] = country; // Nëse gjendet e vëmë emrin e shtetit në qelizën e dytë të rreshtit i.
                    }
                }
            }
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal; // Pas kryerjes së punës e kthejmë 
                                                                                     //vlerën e prioritet në prioritet normal

            // Of course this only affects the main thread rather than child threads.
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // marrja e shtegut të Desktop.
            xlWorkbook.SaveAs(Path.Combine(path, "Exported_" + naked + ".xlsx")); // ruajtja e materialit të përpunuar në emër të ri 
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //mbyllja dhe lirimi i objetkit
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //mbyllja dhe lirimi i objektit 
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private void setTotalCount()
        {
            txtCount.Text = rowCount.ToString("N0");
        }

        private void setProcessed()
        {
            txtProcessesed.Text = processed.ToString("N0");
        }
        private void setUnprocessed()
        {
            txtUnprocessed.Text = unprocessed.ToString("N0");
        }

        private void setPercentage()
        {
              
            txtPercentage.Text = String.Format("{0:P2}", percentage);
            pBPercentage.Value = (int)(percentage * 100);
            lblPerc.Text = String.Format("{0:P2}", percentage); 
        }

        /*
         * Kjo metodë e merr emrin e qytetit dhe e pason kërkesën te google api për marrjen e JSON aktual
         */
        private String GetJSON(string name)
        {
            String json = "";
            if (txtGoogleMapsKey.TextLength > 0)
            {
                json = new WebClient().
                    DownloadString("https://maps.googleapis.com/maps/api/geocode/json?address=" +
                    name + "&sensor=false&key=" + txtGoogleMapsKey.Text);
            }
            return json;
        }

        /*
         * Metodë për kërkimin e shtetit dhe nxjerrja e asaj informate nëse ekziston ai shtet.
         */
        private String LookForCountry(String name)
        {
            RootObject obj = new RootObject(); // objekti ku do të ruhen të dhënat nga JSON
            string c = ""; // ndryshojra c që e ruan emrin e shtetit të gjendur ose jo.
            string json = GetJSON(name); // ruhet JSON i kërkuar në bazë të emrin
            if (!json.Contains("error_message") && !json.Equals("<empty>") && json.Length > 0)
            {// kontrollohet nëse JSON ka ndonjë gabim dhe është bosh dhe  për gjatësi më të madhe se zero të stringut
                try // provohet 
                {
                    // kthimi i json në objekt - Deserializimi
                    var ob2 = (RootObject)JsonConvert.DeserializeObject<RootObject>(json);

                    int cd = 0; // ndryshore për numërim të rreshtave të komponentës Address_component.
                    foreach (var item in ob2.results) // përçdo item të ob2.results
                    {
                        bool found = false; // ndryshore nëse gjendet shteti 

                        foreach (var ac in item.address_components) // qarkullim nëpër address_commponents
                        {
                            if (item.address_components[cd].types[0].ToString() == "country")
                            { // nëse gjendet komponenta e adresës e cila llojin e ka "country"
                                // atëherë lexohet emri i plotë i shtetit
                                c = item.address_components[cd].long_name;

                                found = true; // ndryshorja found bëhet true
                                break; // ndërpritet qarkullimi nëpër item.adress_components
                            }
                            cd++; // e rrit vlerën për një
                        }
                        if (found) // nëse është gjetur
                        {
                            cd = 0; // vlera e numratorit rikthehet në zero
                            break; // ndërpritet qarkullimi npër ob2.results
                        }
                    }
                }
                catch (Exception)
                {// nëse nuk gjendet 
                    c = " Not found ";
                }


            }
            else
            {
                var msg = (ErrorMessage)JsonConvert.DeserializeObject<ErrorMessage>(json);
                throw new Exception(msg.error_message);
            }
            return c;
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtGoogleMapsKey.TextLength > 0)
            {
                OpenExcel(); // hapja e skedarit Excel
            }
            else
            {
                MessageBox.Show("Duhet ta jepni çelësin e Google Maps");
            }
        }

        private void txtPercentage_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Proceso();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Point p = pBPercentage.Location;
            int x, y;
            x  = ((int)p.X + (pBPercentage.Width / 2)) - ((int)lblPerc.Width / 2);
            y = ((int)p.Y +(pBPercentage.Height / 2)) - ((int)lblPerc.Height / 2);
             
            System.Drawing.Point p2 = new System.Drawing.Point(x, y);
            lblPerc.Location = p2; 
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
         
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            this.Opacity = 100;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                this.Opacity = 100 - i;

            }
        }
    }

    public class ErrorMessage
    {
        public string error_message { get; set; }
        public List<String> results { get; set; }
        public string status { get; set; }
    }
}
