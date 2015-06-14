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
    
    public partial class background : PhoneApplicationPage
    {
        public static WriteableBitmap wp;

        public background()
        {
            InitializeComponent();
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            camera.Visibility = System.Windows.Visibility.Visible;
            galeri.Visibility = System.Windows.Visibility.Visible;
            gbr.Visibility = System.Windows.Visibility.Collapsed;
            textBg.Visibility = System.Windows.Visibility.Collapsed;
            exit.Visibility = System.Windows.Visibility.Collapsed;
            next.Visibility = System.Windows.Visibility.Collapsed;

        }


        private void next_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Siluet.xaml", UriKind.Relative));            
        }

        private void exit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Application.Current.Terminate();
        }

        private void camera_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            CameraCaptureTask capture = new CameraCaptureTask();
            capture.Completed += OnCameraCaptureTaskCompleted;
            capture.Show();

        }

        private void galeri_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhotoChooserTask photo = new PhotoChooserTask();
            photo.Completed += task_Completed;
            photo.Show();
        }

            private void OnCameraCaptureTaskCompleted(object sender, PhotoResult e)
            {
                wp = new WriteableBitmap(460, 460);
                wp.SetSource(e.ChosenPhoto);
                gbr.Source = wp;

                camera.Visibility = System.Windows.Visibility.Collapsed;
                galeri.Visibility = System.Windows.Visibility.Collapsed;
                gbr.Visibility = System.Windows.Visibility.Visible;
                textBg.Visibility = System.Windows.Visibility.Visible;
                exit.Visibility = System.Windows.Visibility.Visible;
                next.Visibility = System.Windows.Visibility.Visible;

            }

        private void task_Completed(object sender, PhotoResult e)
        {
            wp = new WriteableBitmap(460, 460);
            wp.SetSource(e.ChosenPhoto);
            gbr.Source = wp;

            camera.Visibility = System.Windows.Visibility.Collapsed;
            galeri.Visibility = System.Windows.Visibility.Collapsed;
            gbr.Visibility = System.Windows.Visibility.Visible;
            textBg.Visibility = System.Windows.Visibility.Visible;
            exit.Visibility = System.Windows.Visibility.Visible;
            next.Visibility = System.Windows.Visibility.Visible;
        }

        

    }
}