// App, which help easier send information to user people

using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.ApplicationModel;

namespace mobile1 // ???????? ?? ???? ???????????? ????
{
    public partial class UserCom : ContentPage
    {
        public UserCom()
        {
            InitializeComponent();
        }

        private async void Saada_sms_Clicked(object sender, EventArgs e)
        {
            string phone = PhoneEntry.Text; // ????????? ?????? ???????? ?? ???? ?????
            string message = MessageEntry.Text ?? "Tere tulemast! Saadan s�numi"; // ????????? ?? ?????????

            if (!string.IsNullOrWhiteSpace(phone) && Sms.Default.IsComposeSupported)
            {
                SmsMessage sms = new SmsMessage(message, phone);
                await Sms.Default.ComposeAsync(sms); // ?????????, ??? ???? ????? ?????????? Task
            }
            else
            {
                await DisplayAlert("??????", "??????? ?????????? ????? ????????.", "OK");
            }
        }

        private async void Saada_email_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text; // ????????? ?????? ??????????? ????? ?? ???? ?????
            string message = MessageEntry.Text ?? "Tere tulemast! Saadan email"; // ????????? ?? ?????????

            if (!string.IsNullOrWhiteSpace(email) && Email.Default.IsComposeSupported)
            {
                EmailMessage e_mail = new EmailMessage
                {
                    Subject = "???? ??????",
                    Body = message,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string> { email }
                };

                await Email.Default.ComposeAsync(e_mail); // ?????????, ??? ???? ????? ?????????? Task
            }
            else
            {
                await DisplayAlert("??????", "??????? ?????????? ????? ??????????? ?????.", "OK");
            }
        }

        private void Helista_Clicked(object sender, EventArgs e)
        {
            string phone = PhoneEntry.Text; // ????????? ?????? ???????? ?? ???? ?????

            if (!string.IsNullOrWhiteSpace(phone) && PhoneDialer.IsSupported)
            {
                PhoneDialer.Open(phone); // ?????????? ?????? ??? await
            }
            else
            {
                DisplayAlert("??????", "??????? ?????????? ????? ???????? ??? ??????.", "OK");
            }
        }
    }
}