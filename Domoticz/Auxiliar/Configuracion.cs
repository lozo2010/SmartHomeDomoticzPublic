using System;
using System.Collections.Generic;
using System.Text;

namespace Domoticz.Auxiliar
{
    public class Configuracion
    {
        public static string UrlBase = "https://IP-HOST/json.htm?username=(UsuarioEncriptado)&password=(ContraseñaEncriptada)";
        public static string UrlGetDevices = "type=devices";
        public static string UrlGetDeviceType = "type=devices&filter={0}&used=true";
        public static string UrlGetDevice = "type=devices&rid={0}";
        public static string UrlSetDevice = "type=command&param=udevice&nvalue=0&idx={0}&svalue={1}";
    }
}
