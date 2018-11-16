using Domoticz.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domoticz.Auxiliar
{
    public class DomoticzApi
    {
        public DomoticzApi()
        {

        }

        public DevicesDomoticz GetDevices()
        {
            DevicesDomoticz devices = new DevicesDomoticz();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(Configuracion.UrlBase+Configuracion.UrlGetDevices);
                devices = JsonConvert.DeserializeObject<DevicesDomoticz>(json);
            }
            return devices;
        }
        public Temperatures GetTemperatureDevice()
        {
            Temperatures temperatureDevices = new Temperatures();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(Configuracion.UrlBase + string.Format( Configuracion.UrlGetDeviceType,"temp" ));
                temperatureDevices = JsonConvert.DeserializeObject<Temperatures>(json);
            }
            return temperatureDevices;
        }

        public double GetTemperatureDataDevice(string idx)
        {
            Temperatures temperatureDevices = new Temperatures();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(Configuracion.UrlBase + string.Format(Configuracion.UrlGetDevice, idx));
                temperatureDevices = JsonConvert.DeserializeObject<Temperatures>(json);
            }
            return Convert.ToDouble(temperatureDevices.result[0].Data.Replace(" C",""));
        }

        public bool SetTemperatureTermostato(string idx, string value)
        {
            ResultJson result = new ResultJson();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(Configuracion.UrlBase + string.Format(Configuracion.UrlSetDevice, idx, value));
                result = JsonConvert.DeserializeObject<ResultJson>(json);
            }
            return result.status == "OK";
        }

    }
}
