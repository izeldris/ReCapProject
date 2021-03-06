using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ItemAdded = "Bilgiler Sisteme Eklendi!";
        public static string ItemAddFailed = "Bilgiler Sisteme Eklenemedi!";
        public static string ItemUpdated = "Bilgiler Güncellendi!";
        public static string ItemUpdateFailed = "Bilgiler Güncellenemedi!";
        public static string ItemDeleted = "Veriler Sistemden Kaldırıldı!";
        public static string ItemDeleteFailed = "Veriler Sistemden Kaldırılamadı!";
        public static string CarNameInvalid = "Girilen Araç Adı Geçersizdir!";
        public static string CarPriceInvalid = "Araç Fiyat Bilgisi 0 ve ya -(Eksi) Değer Alamaz";
        public static string ItemsListed = "Bilgiler Listelendi";
        public static string MaintenanceTime = "Sistem Bakımdadır.";
        public static string ItemsListFailed = "Bilgiler Listelenemedi";
        public static string RentalInvalid = "Araç Kiralanamaz";

        public static string ImageLimitExceeded = "Araç Fotoğraf Sayısı 5 Adetten Fazla Olamaz.";
        public static string AuthorizationDenied = "Erişim Reddedildi!";
    }
}
