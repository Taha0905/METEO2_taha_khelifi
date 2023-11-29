using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http; // pour HttpClient
using Newtonsoft.Json; // pour JsonConvert

namespace METEO2_taha_khelifi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        _: GetMeteo("Annecy");
        }

        public async Task<string> GetMeteo(string city)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://www.prevision-meteo.ch/services/json/{city}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);

                    //Info pour ajourd'hui
                    FcstDay0 fcstDay0 = myDeserializedClass.fcst_day_0;
                    CurrentCondition currentCondition = myDeserializedClass.current_condition;

                    TB_temperature.Text = "Actuellement : " + currentCondition.tmp.ToString() + "°C";
                    TB_condition.Text = currentCondition.condition;
                    TB_Aujourdhui.Text = fcstDay0.day_long;
                    TB_Humidité.Text = currentCondition.humidity.ToString() + "% d'humidité";
                    TB_bas.Text = "Min : " + fcstDay0.tmin.ToString() + "°C";
                    TB_haut.Text = "Max : " + fcstDay0.tmax.ToString() + "°C";

                    //Info pour demain
                    FcstDay1 fcstDay1 = myDeserializedClass.fcst_day_1;
                    TB_Demain.Text = fcstDay1.day_long;
                    TB_conditionD.Text = fcstDay1.condition;
                    TB_basD.Text = "Min : " + fcstDay1.tmin.ToString() + "°C";
                    TB_hautD.Text = "Max : " + fcstDay1.tmax.ToString() + "°C";

                    //Info pour après demain
                    FcstDay2 fcstDay2 = myDeserializedClass.fcst_day_2;
                    TB_ApresDemain.Text = fcstDay2.day_long;
                    TB_conditionAD.Text = fcstDay2.condition;
                    TB_basAD.Text = "Min : " + fcstDay2.tmin.ToString() + "°C";
                    TB_hautAD.Text = "Max : " + fcstDay2.tmax.ToString() + "°C";

                    //Info pour après après demain
                    FcstDay3 fcstDay3 = myDeserializedClass.fcst_day_3;
                    TB_Dans3Jours.Text = fcstDay3.day_long;
                    TB_condition3J.Text = fcstDay3.condition;
                    TB_bas3J.Text = "Min : " + fcstDay3.tmin.ToString() + "°C";
                    TB_haut3J.Text = "Max : " + fcstDay3.tmax.ToString() + "°C";

                    //Info pour la ville
                    CityInfo cityInfo = myDeserializedClass.city_info;
                    TB_Ville.Text = cityInfo.name + ", " + cityInfo.country;


                    return "";
                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void CB_Ville_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_Ville.SelectedItem != null)
            {
                string selectedCity = (CB_Ville.SelectedItem as ComboBoxItem).Content.ToString();
                GetMeteo(selectedCity);
            }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


        public class CityInfo
        {
            public string name { get; set; }
            public string country { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
        }

        public class CurrentCondition
        {
            public string date { get; set; }
            public string hour { get; set; }
            public int tmp { get; set; }
            public int wnd_spd { get; set; }
            public int wnd_gust { get; set; }
            public string wnd_dir { get; set; }
            public double pressure { get; set; }
            public int humidity { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
        }

        public class FcstDay0
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
        }

        public class FcstDay1
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
        }

        public class FcstDay2
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
        }

        public class FcstDay3
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
        }

        public class ForecastInfo
        {
            public object latitude { get; set; }
            public object longitude { get; set; }
            public string elevation { get; set; }
        }

       

        public class Root
        {
            public CityInfo city_info { get; set; }
            public ForecastInfo forecast_info { get; set; }
            public CurrentCondition current_condition { get; set; }
            public FcstDay0 fcst_day_0 { get; set; }
            public FcstDay1 fcst_day_1 { get; set; }
            public FcstDay2 fcst_day_2 { get; set; }
            public FcstDay3 fcst_day_3 { get; set; }

        }
    }
}
