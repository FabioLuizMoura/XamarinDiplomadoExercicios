using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;

namespace ConversorDeMoedas
{
    [Activity(Label = "VistaBandeiras")]
    public class VistaBandeiras : Activity
    {
        double pesos, dolares;
        ImageView mexico;
        ImageView brasil;
        Button btnConverter;
        EditText txtDolares;
        EditText txtPesos;
        double defaultValue;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VistaBandeiras);
            // Create your application here
            btnConverter = FindViewById<Button>(Resource.Id.btnconvertirV);
            txtDolares = FindViewById<EditText>(Resource.Id.txtdolaresV);
            txtPesos = FindViewById<EditText>(Resource.Id.txtpesoV);

            mexico = FindViewById<ImageView>(Resource.Id.imgMexico);
            brasil = FindViewById<ImageView>(Resource.Id.imgBrasil);

            try
            {
                txtDolares.Text = Intent.GetDoubleExtra("dolar", defaultValue).ToString();
                txtPesos.Text = Intent.GetDoubleExtra("peso", defaultValue).ToString();
                mexico.SetImageResource(Resource.Drawable.Mexico);
                brasil.SetImageResource(Resource.Drawable.Brasil);

                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "Base.db3");
                var conn = new SQLiteConnection(path);
                var elementos = from s in conn.Table<Information>() select s;

                foreach (var fila in elementos)
                {
                    Toast.MakeText(this, fila.Dollar.ToString(), ToastLength.Short).Show();

                    Toast.MakeText(this, fila.Peso.ToString(), ToastLength.Short).Show();
                }

            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
            btnConverter.Click += BtnConverter_Click;
        }

        private void BtnConverter_Click(object sender, EventArgs e)
        {
            dolares = double.Parse(txtDolares.Text);
            pesos = dolares * 19.5;
            txtPesos.Text = pesos.ToString();
        }
    }
}