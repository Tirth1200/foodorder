using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace foodorder
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner menuNames;
        TextView foodPriceTv;
        ImageView foodImages;
        SeekBar seekfood;
        double[] foodPriceArray = { 3, 8, 12, 2, 2.5, 4 };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            menuNames = (Spinner)FindViewById(Resource.Id.menuSpinner);
            foodPriceTv = (TextView)FindViewById(Resource.Id.priceOutputTv);
            foodImages = (ImageView)FindViewById(Resource.Id.foodImageView);
            seekfood = (SeekBar)FindViewById(Resource.Id.seekBar1);

            var carNamesAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.foodArray, Android.Resource.Layout.SimpleSpinnerItem);
            menuNames.Adapter = carNamesAdapter;
            menuNames.ItemSelected += delegate
            {
                long i = menuNames.SelectedItemId;
                foodPriceTv.Text = foodPriceArray[i].ToString();
                Toast.MakeText(this, "The Selected Food is : " + menuNames.SelectedItem, ToastLength.Long).Show();
                string imgName = "food0" + i;
                int imgId = this.Resources.GetIdentifier(imgName, "mipmap", this.PackageName);
                foodImages.SetImageResource(imgId);
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

    }
}

