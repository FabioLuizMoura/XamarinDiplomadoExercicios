using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace ConversorDeMoedas
{
    [Activity(Label = "ConversorDeMoedas", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double pesos, dolares;
        Button btnConverter;
        EditText txtDolares;
        EditText txtPesos;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it

            btnConverter = FindViewById<Button>(Resource.Id.btnconvertir);
            txtDolares = FindViewById<EditText>(Resource.Id.txtdolares);
            txtPesos = FindViewById<EditText>(Resource.Id.txtpeso);

            btnConverter.Click += BtnConverter_Click;

        }

        private void BtnConverter_Click(object sender, EventArgs e)
        {
            try
            {

                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "Base.db3");
                var conn = new SQLiteConnection(path);
                conn.CreateTable<Information>();

                dolares = double.Parse(txtDolares.Text);
                pesos = dolares * 19.5;
                txtPesos.Text = pesos.ToString();

                var Insertar = new Information() { Peso = pesos, Dollar = dolares };

                conn.Insert(Insertar);
                Toast.MakeText(this, "Guardado no SQLite", ToastLength.Short).Show();

                Cargar();

            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }

        private void Cargar()
        {
            Intent objIntent = new Intent(this, typeof(VistaBandeiras));
            objIntent.PutExtra("dolar", dolares);
            objIntent.PutExtra("peso", pesos);
            StartActivity(objIntent);
        }

    }
    public class Information
    {
        public int ID { get; set; }
        public double Dollar { get; set; }
        public double Peso { get; set; }
      }
}

