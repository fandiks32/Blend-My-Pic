using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;

namespace PhoneApp4
{
    public partial class Siluet : PhoneApplicationPage
    {
        public static WriteableBitmap wpSil;

        public Siluet()
        {
            InitializeComponent();
        }

        private void gbrS_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            cameraS.Visibility = System.Windows.Visibility.Visible;
            galeriS.Visibility = System.Windows.Visibility.Visible;
            gbrS.Visibility = System.Windows.Visibility.Collapsed;
            textSl.Visibility = System.Windows.Visibility.Collapsed;
            exitS.Visibility = System.Windows.Visibility.Collapsed;
            nextS.Visibility = System.Windows.Visibility.Collapsed;
        }

        

        private void exit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Application.Current.Terminate();
        }

        private void cameraS_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            CameraCaptureTask capture = new CameraCaptureTask();
            capture.Completed += OnCameraCaptureTaskCompleted;
            capture.Show();
        }

        private void galeriS_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhotoChooserTask photo = new PhotoChooserTask();
            photo.Completed += task_Completed;
            photo.Show();
        }

        private void OnCameraCaptureTaskCompleted(object sender, PhotoResult e)
        {
            //wpSil = new WriteableBitmap(460, 460);
            //wpSil.SetSource(e.ChosenPhoto);
            gbrS.Source = background.wp;

            cameraS.Visibility = System.Windows.Visibility.Collapsed;
            galeriS.Visibility = System.Windows.Visibility.Collapsed;
            gbrS.Visibility = System.Windows.Visibility.Visible;
            textSl.Visibility = System.Windows.Visibility.Visible;
            exitS.Visibility = System.Windows.Visibility.Visible;
            nextS.Visibility = System.Windows.Visibility.Visible;

        }

        private void task_Completed(object sender, PhotoResult e)
        {
            wpSil = new WriteableBitmap(460, 460);
            wpSil.SetSource(e.ChosenPhoto);
            gbrS.Source = background.wp;

            cameraS.Visibility = System.Windows.Visibility.Collapsed;
            galeriS.Visibility = System.Windows.Visibility.Collapsed;
            gbrS.Visibility = System.Windows.Visibility.Visible;
            textSl.Visibility = System.Windows.Visibility.Visible;
            exitS.Visibility = System.Windows.Visibility.Visible;
            nextS.Visibility = System.Windows.Visibility.Visible;
        }
    }
}